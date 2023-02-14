using BlogWebAppProj.Data;
using BlogWebAppProj.Data.FileManager;
using BlogWebAppProj.Data.Repository;
using BlogWebAppProj.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAppProj.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private IFileManager _fileManager;

        public HomeController(IRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _repository.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repository.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.')+1);
            return new FileStreamResult(_fileManager.ImageStream(image),$"image/{mime}");
        }
    }
}
