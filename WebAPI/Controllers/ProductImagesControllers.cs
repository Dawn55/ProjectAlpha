using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesControllers : ControllerBase
    {
        IProductImageService _productImageService;
        public ProductImagesControllers(IProductImageService productImageService)
        {
            _productImageService = productImageService; 
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile formFile , [FromForm] ProductImage productImage)
        {
            var result = _productImageService.Add(formFile,productImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
          
          
        }
    }
}
