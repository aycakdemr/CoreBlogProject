using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;  
            var value = wm.GetWriterIdByMail(usermail);
            var values = wm.GetWriterById(value);
            return View(values);
        }
    }
}
