using Microsoft.AspNetCore.Http;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class FileService : IFileService
    {
        public string ConvertToString(IFormFile file)
        {
            //extention
            List<string> validExtentions = new List<string>() { ".jpg", ".png", ".gif" };
            string extention = Path.GetExtension(file.FileName);
            if (!validExtentions.Contains(extention))
            {
                return $"Extention is not valid({string.Join(',', validExtentions)})";
            }
            //file size
            long size = file.Length;
            if (size > (10 * 1024 * 1024))
            {
                return "Maximum Size can be 10Mb";
            }
            //name changing
            string fileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(path + fileName, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

    }
}
