using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics1 : ViewComponent
    {

        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = _blogManager.GetAll().Count();
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();
            string api = "d3494ca056c740e293c4e72988ba7b31";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
         //   XDocument xDocument = XDocument.Load(connection);
         //   ViewBag.v4 = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
