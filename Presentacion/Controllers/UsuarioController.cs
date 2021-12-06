using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        #region Metodos Get
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Entidades.Usuario());
        }


        [HttpPost]
        public ActionResult Validar(Entidades.Usuario usuario)
        {
            try
            {
                Entidades.Usuario _usuario = Negocio.Usuario.Obtener(usuario.Email, usuario.Clave);


                Session["Usuario"] = _usuario;


                if (_usuario != null)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("Error", "Home");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home", new {Error= ex.Message });
            }

        }
        #endregion


    }
}
