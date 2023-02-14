using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAppProj.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string imageName);
        Task<string> SaveImage(IFormFile image);

    }
}
