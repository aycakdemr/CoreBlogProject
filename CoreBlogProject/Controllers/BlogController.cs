using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetListWithCategory();
            return View(values);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.id = id;
            var values = bm.GetAll(id);
            return View(values);
        }
    }
}
