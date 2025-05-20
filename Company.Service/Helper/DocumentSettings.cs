using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //1. Get Folder Path
            // var folderPath = @"C:\\Users\\DELL\\source\\repos\\Company.Web\\Company.Web\\wwwroot\\Files\\Images\\";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName);

            //2. Get File Name
            var fileName = $"{Guid.NewGuid}-{file.FileName}";

            //3. Combine FolderPath + FilePath
            var filePath = Path.Combine(folderPath, fileName);

            // Save File 
            using var fileStream = new FileStream(filePath,FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;



        }
    }
}
