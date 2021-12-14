using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductosController : Controller
    {

        public ActionResult Index()
        {
            return View(new Entidades.Producto());
        }

        [HttpGet]
        public ActionResult EditarP(int? Id)

        {
            Entidades.Producto Producto = new Entidades.Producto();

            if (Id != null && Id > 0)

                Producto = Negocio.Producto.Obtener(Id.Value);

            return View(Producto);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)

        {
            try
            {

                Negocio.Producto.Eliminar(id,id);

                return RedirectToAction("ListProductos","Productos");
            }

            catch (Exception ex)
            
            {

                return RedirectToAction("Error", "Productos");

            }          
        }

        //[HttpGet]
        //public ActionResult Ingresar()
        //{
        //    return View(new Entidades.Producto());
        //}

        //[HttpGet]
        //public ActionResult Salir()
        //{
        //    Session["Producto"] = null;

        //    return RedirectToAction("Index","Home");
        //}

        public ActionResult ListProductos()
        {
           //Entidades.Producto Producto = (Entidades.Producto)Session["Producto"];

            //if (Producto != null && Producto.TipoPermiso== Entidades.Enumerables.Producto.TipoPermisos.Admin)

                return View(Negocio.Producto.Listar());

            //else

            //    return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public JsonResult Guardar(Entidades.Producto Producto)
        {
            try
            {
                Producto.TipoPermiso = Entidades.Enumerables.Producto.TipoPermisos.Comprador;
                Producto.Estado = Entidades.Enumerables.Producto.Estado.Activo;
                 Negocio.Producto.Grabar(Producto);

                Entidades.Resultado resultado = new Entidades.Resultado();
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
                resultado.CantidadIncorrectos = 0;
                resultado.Objeto = Producto;

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

        //[HttpPost]
        //public JsonResult Ingresar(Entidades.Producto Producto)
        //{
        //    try
        //    {
        //        //Producto.TipoPermiso = Entidades.Enumerables.Producto.TipoPermisos.Comprador;
        //        //Producto.TipoProducto = Entidades.Enumerables.Producto.TipoProducto.Comprador;

        //        Producto = Negocio.Producto.Obtener(Producto.Email,Producto.Clave);

        //        Session["Producto"] = Producto;

        //        if (Producto != null && Producto.Estado!= Entidades.Enumerables.Producto.Estado.Inactivo)
        //        {

        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = true;
        //            resultado.Mensaje = "";
        //            resultado.CantidadIncorrectos = 0;
        //            resultado.Objeto = Producto;

        //            return Json(resultado);
        //        }

        //        else
        //        {
        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = false;
        //            resultado.Mensaje = "El Producto ingresado no existe o se encuentra inactivo";
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

        //[HttpPost]
        //public JsonResult Editar(Entidades.Producto Producto)
        //{
        //    try
        //    {
        //        //Producto.TipoPermiso = Entidades.Enumerables.Producto.TipoPermisos.Comprador;
        //        //Producto.TipoProducto = Entidades.Enumerables.Producto.TipoProducto.Comprador;

        //        Producto = Negocio.Producto.Obtener(Producto.IdProducto.Value);

        //        Session["Producto"] = Producto;

        //        if (Producto.Estado != Entidades.Enumerables.Producto.Estado.Inactivo)
        //        {

        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = true;
        //            resultado.Mensaje = "";
        //            resultado.CantidadIncorrectos = 0;
        //            resultado.Objeto = Producto;

        //            return Json(resultado);
        //        }

        //        else
        //        {
        //            Entidades.Resultado resultado = new Entidades.Resultado();
        //            resultado.EsCorrecto = false;
        //            resultado.Mensaje = "El Producto ingresado no existe o se encuentra inactivo";
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
        public ActionResult Obtener(int IdProducto)
        {
            return View();
        }
    }
}
