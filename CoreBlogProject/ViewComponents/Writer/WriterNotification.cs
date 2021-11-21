using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {


        public IViewComponentResult Invoke(int id)
        {
            return View();

        }

    }
}
