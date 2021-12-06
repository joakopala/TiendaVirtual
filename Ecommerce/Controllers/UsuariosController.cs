using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class UsuariosController : Controller
    {

        public ActionResult Index()
        {
            return View(new Entidades.Usuario());
        }

        [HttpGet]
        public ActionResult Editar(int? Id)

        {
            Entidades.Usuario usuario = new Entidades.Usuario();

            if (Id != null && Id > 0)

                usuario = Negocio.Usuario.Obtener(Id.Value);

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)

        {
            try
            {

                Negocio.Usuario.Eliminar(id,id);

                return RedirectToAction("Administracion","Usuarios");
            }

            catch (Exception ex)
            
            {

                return RedirectToAction("Error", "Usuarios");

            }          
        }

        [HttpGet]
        public ActionResult Ingresar()
        {
            return View(new Entidades.Usuario());
        }

        [HttpGet]
        public ActionResult Salir()
        {
            Session["Usuario"] = null;

            return RedirectToAction("Index","Home");
        }

        public ActionResult Administracion()
        {
           Entidades.Usuario usuario = (Entidades.Usuario)Session["Usuario"];

            if (usuario != null && usuario.TipoPermiso== Entidades.Enumerables.Usuario.TipoPermisos.Admin)

                return View(Negocio.Usuario.Listar());

            else

                return RedirectToAction("Error", "Home");
        }

        // POST: Usuarios/Create
        //[HttpPost]
        //public ActionResult Guardar(Entidades.Usuario usuario)
        //{
        //    try
        //    {
        //        usuario.TipoPermiso = Entidades.Enumerables.Usuario.TipoPermisos.Comprador;
        //        usuario.TipoUsuario = Entidades.Enumerables.Usuario.TipoUsuario.Comprador;

        //        Negocio.Usuario.Grabar(usuario);

        //        return RedirectToAction("Index","Home");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        // POST: Usuarios/Create
        [HttpPost]
        public JsonResult Guardar(Entidades.Usuario usuario)
        {
            try
            {
                usuario.TipoPermiso = Entidades.Enumerables.Usuario.TipoPermisos.Comprador;
                usuario.TipoUsuario = Entidades.Enumerables.Usuario.TipoUsuario.Comprador;

                 Negocio.Usuario.Grabar(usuario);

                Entidades.Resultado resultado = new Entidades.Resultado();
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
                resultado.CantidadIncorrectos = 0;
                resultado.Objeto = usuario;

                return Json(resultado);
            }
            catch(Exception ex)
            {
                Entidades.Resultado resultado = new Entidades.Resultado();
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;
                resultado.CantidadIncorrectos = 1;
                resultado.Objeto = null;

                return Json(resultado);
            }
        }

        [HttpPost]
        public JsonResult Ingresar(Entidades.Usuario usuario)
        {
            try
            {
                //usuario.TipoPermiso = Entidades.Enumerables.Usuario.TipoPermisos.Comprador;
                //usuario.TipoUsuario = Entidades.Enumerables.Usuario.TipoUsuario.Comprador;

                usuario = Negocio.Usuario.Obtener(usuario.Email,usuario.Clave);

                Session["Usuario"] = usuario;

                if (usuario != null && usuario.Estado!= Entidades.Enumerables.Usuario.Estado.Inactivo)
                {

                    Entidades.Resultado resultado = new Entidades.Resultado();
                    resultado.EsCorrecto = true;
                    resultado.Mensaje = "";
                    resultado.CantidadIncorrectos = 0;
                    resultado.Objeto = usuario;

                    return Json(resultado);
                }

                else
                {
                    Entidades.Resultado resultado = new Entidades.Resultado();
                    resultado.EsCorrecto = false;
                    resultado.Mensaje = "El usuario ingresado no existe o se encuentra inactivo";
                    resultado.CantidadIncorrectos = 1;
                    resultado.Objeto = null;

                    return Json(resultado);

                }
            }
            catch (Exception ex)
            {
                Entidades.Resultado resultado = new Entidades.Resultado();
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;
                resultado.CantidadIncorrectos = 1;
                resultado.Objeto = null;

                return Json(resultado);
            }
        }

        //[HttpPost]
        //public JsonResult Editar(Entidades.Usuario usuario)
        //{
        //    try
        //    {
        //        //usuario.TipoPermiso = Entidades.Enumerables.Usuario.TipoPermisos.Comprador;
        //        //usuario.TipoUsuario = Entidades.Enumerables.Usuario.TipoUsuario.Comprador;

        //        usuario = Negocio.Usuario.Obtener(usuario.IdUsuario.Value);

        //        Session["Usuario"] = usuario;

        //        if (usuario.Estado != Entidades.Enumerables.Usuario.Estado.Inactivo)
        //        {

        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = true;
        //            resultado.Mensaje = "";
        //            resultado.CantidadIncorrectos = 0;
        //            resultado.Objeto = usuario;

        //            return Json(resultado);
        //        }

        //        else
        //        {
        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = false;
        //            resultado.Mensaje = "El usuario ingresado no existe o se encuentra inactivo";
        //            resultado.CantidadIncorrectos = 1;
        //            resultado.Objeto = null;

        //            return Json(resultado);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Entidades.Resultado resultado = new Entidades.Resultado();
        //        resultado.EsCorrecto = false;
        //        resultado.Mensaje = ex.Message;
        //        resultado.CantidadIncorrectos = 1;
        //        resultado.Objeto = null;

        //        return Json(resultado);
        //    }
        //}
        [HttpPost]
        public ActionResult Obtener(int IdUsuario)
        {
            return View();
        }
    }
}
