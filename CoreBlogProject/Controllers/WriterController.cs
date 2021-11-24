using BusinessLayer.Concrete;
using CoreBlogProject.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            return View();
        }
        [AllowAnonymous]
        public IActionResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public IActionResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name;
            var value = wm.GetWriterIdByMail(usermail);
            var v = wm.GetById(value);
            return View(v);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer w)
        {
            w.WriterStatus = true;
            wm.Update(w);
            return RedirectToAction("Index", "Dashboard");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage w)
        {
            Writer writer = new Writer();
            if(w.WriterImage != null)
            {
                var extension = Path.GetExtension(w.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerimagefiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                w.WriterImage.CopyTo(stream);
                writer.WriterImage = newimagename;
                writer.WriterMail = w.WriterMail;
                writer.WriterPassword = w.WriterPassword;
                writer.WriterStatus = true;
                writer.WriterAbout = w.WriterAbout;
            }
            w.WriterStatus = true;
            wm.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
