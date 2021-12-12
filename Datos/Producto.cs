using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Producto
    {

        public static int Insertar(Entidades.Producto Producto)
        {
            //insertar un registro en la base de datos de ecommerce tabla Productos

            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Productos_Insertar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Producto.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Marca", Producto.Marca));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Producto.Modelo));
                    cmd.Parameters.Add(new SqlParameter("@Stock", (int)Producto.Stock));
                    cmd.Parameters.Add(new SqlParameter("@PrecioUnitario", (int)Producto.PrecioUnitario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Producto.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", (int)Producto.TipoPermiso));
                    cmd.Parameters.Add(new SqlParameter("@Activo", (int)Producto.Estado));


                    // Ejecuto el comando y asigo el valor al DataReader

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    id = Convert.ToInt32(dt.Rows[0][0]);
                }

                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el Producto: " + ex.Message);
            }
        }

        public static void Actualizar(Entidades.Producto Producto)
        {
            //Actualizar un registro en la base de datos de ecommerce tabla Productos
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Productos_Actualizar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@IdProducto", Producto.IdProducto));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Producto.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Marca", Producto.Marca));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Producto.Modelo));
                    cmd.Parameters.Add(new SqlParameter("@Stock", (int)Producto.Stock));
                    cmd.Parameters.Add(new SqlParameter("@PrecioUnitario", (int)Producto.PrecioUnitario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Producto.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", (int)Producto.TipoPermiso));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar el Producto: " + ex.Message);
            }
        }

        public static void ModificarEstado(int idProducto,Entidades.Enumerables.Producto.Estado Estado )
        {
            //Eliminar un registro en la base de datos de ecommerce tabla Productos
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Productos_ModificarEstado", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@IdProducto", idProducto));
                    cmd.Parameters.Add(new SqlParameter("@IdEstado", (int)Estado));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar el Producto: " + ex.Message);
            }
        }

        //public static DataTable Obtener(string email)
        //{
        //    //insertar un registro en la base de datos de ecommerce tabla Productos

        //    try
        //    {

        //        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
        //        {
        //            DataTable dt = new DataTable();

        //            cn.Open();

        //            // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
        //            SqlCommand cmd = new SqlCommand("SP_Productos_ObtenerPorEmail", cn);

        //            // 2. Especifico el tipo de Comando
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            // 3. Agrego el Valor al Procedimiento almacenado
        //            cmd.Parameters.Add(new SqlParameter("@Email", email));

        //            // Ejecuto el comando y asigo el valor al DataReader

        //            var dataReader = cmd.ExecuteReader();
        //            dt.Load(dataReader);

        //            return dt;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error al Guardar el Producto: " + ex.Message);
        //    }
        //}

        //public static DataTable Obtener(string email, string clave)
        //{
        //    //insertar un registro en la base de datos de ecommerce tabla Productos

        //    try
        //    {

        //        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
        //        {
        //            DataTable dt = new DataTable();

        //            cn.Open();

        //            // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
        //            SqlCommand cmd = new SqlCommand("SP_Productos_Obtener", cn);

        //            // 2. Especifico el tipo de Comando
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            // 3. Agrego el Valor al Procedimiento almacenado
        //            cmd.Parameters.Add(new SqlParameter("@Email", email));
        //            cmd.Parameters.Add(new SqlParameter("@Clave", clave));

        //            // Ejecuto el comando y asigo el valor al DataReader

        //            var dataReader = cmd.ExecuteReader();
        //            dt.Load(dataReader);

        //            return dt;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error al Guardar el Producto: " + ex.Message);
        //    }
        //}

        public static DataTable Obtener(int id)
        {
            //insertar un registro en la base de datos de ecommerce tabla Productos

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Productos_ObtenerPorId", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    // Ejecuto el comando y asigo el valor al DataReader

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el Producto: " + ex.Message);
            }
        }

        public static DataTable Listar()
        {
            //insertar un registro en la base de datos de ecommerce tabla Productos

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Productos_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el Producto: " + ex.Message);
            }
        }

    }
}
