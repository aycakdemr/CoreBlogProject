using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var v = cm.GetAll().ToPagedList(page,3);

            return View(v);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {
            c.CategoryStatus = true;
            cm.Add(c);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult CategoryDelete(int id)
        {
            var value = cm.GetById(id);
            cm.Delete(value);
            return RedirectToAction("Index");
        }

    }
}
