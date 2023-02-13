using BlogWebAppProj.Data;
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

        public HomeController(IRepository repository)
        {
            _repository = repository;
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
    }
}
