using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Newtonsoft.Json;

namespace Negocio
{
    public class Producto
    {
        
        #region Metodos publicos
        public static void Grabar(Entidades.Producto Producto)
        {
            try
            {

                if (Validar(Producto,out string error))
                {
                    if (Producto.IdProducto != null)
                        Actualizar(Producto);
                    else
                        Insertar(Producto);
                }
                else
                {
                    throw new Exception(error);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static Entidades.Resultado GrabarLote(List<Entidades.Producto> listaProductos)
        {

            Entidades.Resultado resultado = new Entidades.Resultado();

            foreach (var item in listaProductos)
            {
                try
                {
                    resultado.CantidadCorrectos += 1;
                    Producto.Grabar(item);
                }
                catch (Exception ex)
                {
                    resultado.CantidadIncorrectos += 1;
                    resultado.Mensaje = "error en el Producto con id: " + item.IdProducto + " " + ex.Message;
                    throw;
                }
            }

            resultado.Procesados = listaProductos.Count();

            return resultado;

        }

        public static void Eliminar(int id, int IdProductoLogueado)
        {

            Entidades.Producto Productos = Obtener(id);
            Datos.Producto.ModificarEstado(id,Entidades.Enumerables.Producto.Estado.Inactivo);
           
        }

        /// <summary>
        /// Obtiene el Producto.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="clave">Clave sin Encriptar</param>
        /// <returns></returns>
        //public static Entidades.Producto Obtener(string email, string clave)
        //{
        //    DataTable dt = Datos.Producto.Obtener(email,Negocio.Utilidades.Seguridad.Encriptar(clave));
        //    Entidades.Producto Producto = new Entidades.Producto();

            
        //    if (dt.Rows.Count > 0)
        //    {
        //        return ArmarDatos(dt.Rows[0]);
        //    }
        //    else
        //    {
        //        throw new Exception("No existen Productos con los datos ingresados");
        //    }

        //}

        //public static Entidades.Producto Obtener(string email)
        //{
        //    DataTable dt = Datos.Producto.Obtener(email);
        //    Entidades.Producto Producto = new Entidades.Producto();
        //    if (dt.Rows.Count > 0)
        //    {
        //        return ArmarDatos(dt.Rows[0]);
        //    }
        //    else
        //    {
        //        throw new Exception("No existen Productos con los datos ingresados");
        //    }

        //}

        public static Entidades.Producto Obtener(int id)
        {
            DataTable dt = Datos.Producto.Obtener(id);
            Entidades.Producto Producto = new Entidades.Producto();
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existen Productos con los datos ingresados");
            }

        }

        public static List<Entidades.Producto> Listar()
        {
            DataTable dt = Datos.Producto.Listar();

            List<Entidades.Producto> listaProducto = new List<Entidades.Producto>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    listaProducto.Add(ArmarDatos(fila));
                }
                return listaProducto;
            }
            else
            {
                return new List<Entidades.Producto>();
            }

        }

        #endregion

        #region Metodos privados
        private static int Insertar(Entidades.Producto Producto)
        {
            int idProducto=Datos.Producto.Insertar(Producto);
            Producto.IdProducto = idProducto;

            return idProducto;
        }

        private static void Actualizar(Entidades.Producto Producto)
        {
            Datos.Producto.Actualizar(Producto);
        }

        private static bool Validar(Entidades.Producto Producto,out string error)
        {
            error = "";


            if (string.IsNullOrEmpty(Producto.Nombre))
                error = error + "El campo nombre se encuentra vacio ";

            if (string.IsNullOrEmpty(Producto.Marca))
                error = error + "El campo Marca se encuentra vacio  ";

            if (string.IsNullOrEmpty(Producto.Modelo))
                error = error + "El campo Modelo se encuentra vacio  ";

            if (Producto.Stock == null)
            {
                error = error + "El campo Stock se encuentra vacio  ";
            }

            else
            {
                if(!int.TryParse(Producto.Stock.Value.ToString(), out int numero))
                {
                    error = error + "El campo Stock no es de tipo entero";
                }

            }

            if (Producto.PrecioUnitario == null)
            {
                error = error + "El campo PrecioUnitario se encuentra vacio  ";
            }

            else
            {
                if (!int.TryParse(Producto.PrecioUnitario.Value.ToString(), out int numero))
                {
                    error = error + "El campo PrecioUnitario no es de tipo entero";
                }

            }
            if (string.IsNullOrEmpty(Producto.Descripcion))
                error = error + "El campo Descripcion se encuentra vacio ";

            if (String.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Producto ArmarDatos(DataRow fila)
        {
            Entidades.Producto Producto = new Entidades.Producto();

            Producto.Nombre = fila["Nombre"].ToString();
            Producto.Marca = fila["Marca"].ToString();
            Producto.Modelo = fila["Modelo"].ToString();
            Producto.Stock = Convert.ToInt32(fila["Stock"]);
            Producto.PrecioUnitario = Convert.ToInt32(fila["PrecioUnitario"]);
            Producto.IdProducto = Convert.ToInt32(fila["IdProducto"]);
            Producto.Descripcion = fila["Descripcion"].ToString();
            Producto.ListaMenu = Menu.ListarPorProducto(Producto.IdProducto.Value);
            Producto.Estado = (Entidades.Enumerables.Producto.Estado)Convert.ToInt32(fila["IdEstado"]);

            return Producto;
        }

        public void LoguearEvento(object objeto)
        {
            Entidades.Producto Producto = (Entidades.Producto)objeto;
            string ProductoXML = JsonConvert.SerializeObject(Producto);
        }
        #endregion

    }
}
