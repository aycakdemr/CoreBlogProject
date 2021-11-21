using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class WriterController : Controller
    {
       
        public IActionResult Index()
        {
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
    }
}
