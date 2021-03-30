
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;
        public ProductManager(IProductDal productDal)
        {
            _productdal = productDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           var result = BusinessRules.Run(CheckCategoryProductLimit(product.CategoryId), CheckProductNameExists(product.ProductName));
            if (result != null)
            {
                return result;
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Product product)
        {
            _productdal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(p => p.CategoryId == id), Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productdal.Get(p=>p.ProductId == 1),Messages.ProductGet);
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productdal.GetProductDetails(),Messages.ProductListed);
        }

        public IResult Update(Product product)
        {
            _productdal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckCategoryProductLimit(int categoryid)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryid);
            if (result.Count >= 10)
            {
                return new ErrorResult(Messages.MaxProductForCategoryType);
            }
            return new SuccessResult();
        }
        private IResult CheckProductNameExists(string productname)
        {
           var result =  _productdal.Get(p => p.ProductName == productname);
            if (result != null)
            {
                return new ErrorResult(Messages.ProductNameDouble);
            }
            return new SuccessResult();
        }
    }
}
