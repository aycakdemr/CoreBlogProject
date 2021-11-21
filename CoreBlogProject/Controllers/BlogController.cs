using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.cv = categoryvalue;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.WriterId = 1;
            bm.Add(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        public IActionResult BlogDelete(int id)
        {
            var value = bm.GetById(id);
            bm.Delete(value);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = bm.GetById(id);
            List<SelectListItem> categoryvalue = (from x in cm.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.cv = categoryvalue;
            return View(value);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var value = bm.GetById(blog.BlogId);
            blog.BlogStatus = value.BlogStatus;
            blog.BlogCreateDate = value.BlogCreateDate;
            blog.WriterId = value.WriterId;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
