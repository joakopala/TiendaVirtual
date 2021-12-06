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
    public class Usuario
    {

        public static int Insertar(Entidades.Usuario usuario)
        {
            //insertar un registro en la base de datos de ecommerce tabla usuarios

            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Insertar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuario.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", usuario.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    cmd.Parameters.Add(new SqlParameter("@IdTipoUsuario", usuario.TipoUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Edad", usuario.Edad));
                    cmd.Parameters.Add(new SqlParameter("@Activo", (int)usuario.Estado));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", (int)usuario.TipoPermiso));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento));

                    // Ejecuto el comando y asigo el valor al DataReader

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    id = Convert.ToInt32(dt.Rows[0][0]);
                }

                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

        public static void Actualizar(Entidades.Usuario usuario)
        {
            //Actualizar un registro en la base de datos de ecommerce tabla usuarios
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Actualizar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", usuario.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", usuario.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", usuario.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Clave", usuario.Clave));
                    cmd.Parameters.Add(new SqlParameter("@IdTipoUsuario", usuario.TipoUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Edad", usuario.Edad));
                    cmd.Parameters.Add(new SqlParameter("@Activo", (int)usuario.Estado));
                    cmd.Parameters.Add(new SqlParameter("@IdPermiso", (int)usuario.TipoPermiso));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }

        public static void ModificarEstado(int idUsuario,Entidades.Enumerables.Usuario.Estado Estado )
        {
            //Eliminar un registro en la base de datos de ecommerce tabla usuarios
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_ModificarEstado", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                    cmd.Parameters.Add(new SqlParameter("@IdEstado", (int)Estado));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }

        public static DataTable Obtener(string email)
        {
            //insertar un registro en la base de datos de ecommerce tabla usuarios

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_ObtenerPorEmail", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Email", email));

                    // Ejecuto el comando y asigo el valor al DataReader

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

        public static DataTable Obtener(string email, string clave)
        {
            //insertar un registro en la base de datos de ecommerce tabla usuarios

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Obtener", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));

                    // Ejecuto el comando y asigo el valor al DataReader

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);

                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

        public static DataTable Obtener(int id)
        {
            //insertar un registro en la base de datos de ecommerce tabla usuarios

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_ObtenerPorId", cn);

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

                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

        public static DataTable Listar()
        {
            //insertar un registro en la base de datos de ecommerce tabla usuarios

            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Usuarios_Listar", cn);

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

                throw new Exception("Error al Guardar el usuario: " + ex.Message);
            }
        }

    }
}
