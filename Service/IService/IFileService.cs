using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IFileService
    {
        /*Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtentions);
        void DeleteFile(string fileNameWithExtention);*/
        string ConvertToString(IFormFile file);
        /*byte[] ConvertToByteArray(IFormFile file);*/


    }
}
