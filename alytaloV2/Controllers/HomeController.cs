using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alytaloV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return base.View();
        }

         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return base.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return base.View();
        }
    }
}