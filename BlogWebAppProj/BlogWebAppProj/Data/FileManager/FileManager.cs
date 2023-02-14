using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAppProj.Data.FileManager
{
    public class FileManager: IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration configuration)
        {
            _imagePath = configuration["Path:Images"];
            
        }

        public FileStream ImageStream(string imageName)
        {
            return new FileStream(Path.Combine(_imagePath, imageName), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return fileName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }
        }
    }
}
