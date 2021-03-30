using Business.Concrate;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrate;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrate;
using System;
using System.IO;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string newpath = @"D:\Program Files";
            string sourcepath = @"D:\Program Files (x86)\heı.png";

            FileInfo ff = new FileInfo(sourcepath);;
            FileInfo ff2 = new FileInfo(newpath);

            // Create a new file  
            using (FileStream fs = ff2.Create()) { }
            using (FileStream fs = ff.Create()) { }

            if (File.Exists(newpath))
            {
                ff2.Delete();
            }
            ff.CopyTo(newpath);



        }
    }
}

