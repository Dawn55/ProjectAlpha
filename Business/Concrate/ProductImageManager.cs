using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public IResult Add(IFormFile formFile,ProductImage productImage)
        {
            BusinessRules.Run(CheckProductImageLimit(productImage));
            productImage.Path = FileHelper.Add(formFile);
            productImage.Date = DateTime.Now;
            
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(string path)
        {
            throw new NotImplementedException();
        }

        public IResult Update(string path, IFormFile formFile)
        {
            throw new NotImplementedException();
        }
        //Business Rules
        public IResult CheckProductImageLimit(ProductImage productImage)
        {
           var result = _productImageDal.GetAll(p=>p.ProductId == productImage.ProductId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExtended);
            }
            return new SuccessResult(Messages.Added);
        }
    }
}
