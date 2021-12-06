using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnePage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Entidades.Usuario _usuario = Negocio.Usuario.Obtener("OnePage@gmail.com","123");

            Session["Usuario"] = _usuario;

            return View();
        }
    }
}