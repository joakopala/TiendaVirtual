using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["Usuario"] != null)
            
                return View();

            else

                return RedirectToAction("Error", "Home");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}