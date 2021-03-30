using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
   public static class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
           var path = NewPath(formFile);
            using (FileStream fileStream = new FileStream(path,FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return path;
        }
        public static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string ff = fileInfo.Extension;
            string path = Environment.CurrentDirectory + @"\Images";
            string newpath = Guid.NewGuid().ToString() + ff;
            return $@"{path}\{newpath}";
        }
    }
}
