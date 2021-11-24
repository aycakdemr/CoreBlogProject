using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        public IActionResult InBox()
        {
            var v = mm.GetInboxListByWriter(1);
            return View(v);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }
    }
}
