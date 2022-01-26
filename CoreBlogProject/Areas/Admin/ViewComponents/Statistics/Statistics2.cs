using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics2 : ViewComponent
    {
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v2 = _context.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = _context.Comments.Count();
            return View();
        }
    }
}
