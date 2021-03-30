using Core.Utilities.Results;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductImageService
    {
        IResult Add(IFormFile formFile,ProductImage productImage);
        IResult Delete(string path);
        IResult Update(string path,IFormFile formFile);
    }
}
