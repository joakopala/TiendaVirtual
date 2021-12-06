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
    public class Usuario
    {
        
        #region Metodos publicos
        public static void Grabar(Entidades.Usuario usuario)
        {
            try
            {

                if (Validar(usuario,out string error))
                {
                    if (usuario.IdUsuario != null)
                        Actualizar(usuario);
                    else
                        Insertar(usuario);
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

        public static Entidades.Resultado GrabarLote(List<Entidades.Usuario> listaUsuarios)
        {

            Entidades.Resultado resultado = new Entidades.Resultado();

            foreach (var item in listaUsuarios)
            {
                try
                {
                    resultado.CantidadCorrectos += 1;
                    Usuario.Grabar(item);
                }
                catch (Exception ex)
                {
                    resultado.CantidadIncorrectos += 1;
                    resultado.Mensaje = "error en el usuario con id: " + item.IdUsuario + " " + ex.Message;
                    throw;
                }
            }

            resultado.Procesados = listaUsuarios.Count();

            return resultado;

        }

        public static void Eliminar(int id, int IdUsuarioLogueado)
        {

            Entidades.Usuario usuarios = Obtener(id);
            Datos.Usuario.ModificarEstado(id,Entidades.Enumerables.Usuario.Estado.Inactivo);
           
        }

        /// <summary>
        /// Obtiene el usuario.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="clave">Clave sin Encriptar</param>
        /// <returns></returns>
        public static Entidades.Usuario Obtener(string email, string clave)
        {
            DataTable dt = Datos.Usuario.Obtener(email,Negocio.Utilidades.Seguridad.Encriptar(clave));
            Entidades.Usuario usuario = new Entidades.Usuario();

            
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existen Usuarios con los datos ingresados");
            }

        }

        public static Entidades.Usuario Obtener(string email)
        {
            DataTable dt = Datos.Usuario.Obtener(email);
            Entidades.Usuario usuario = new Entidades.Usuario();
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existen Usuarios con los datos ingresados");
            }

        }

        public static Entidades.Usuario Obtener(int id)
        {
            DataTable dt = Datos.Usuario.Obtener(id);
            Entidades.Usuario usuario = new Entidades.Usuario();
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existen Usuarios con los datos ingresados");
            }

        }

        public static List<Entidades.Usuario> Listar()
        {
            DataTable dt = Datos.Usuario.Listar();

            List<Entidades.Usuario> listaUsuario = new List<Entidades.Usuario>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    listaUsuario.Add(ArmarDatos(fila));
                }
                return listaUsuario;
            }
            else
            {
                return new List<Entidades.Usuario>();
            }

        }

        public static Resultado RecuperarClave(string email)
        {
            Resultado resultado= new Resultado();
           
            try
            {
                Entidades.Usuario usuario = Obtener(email);

                if (usuario != null)
                {
                    Negocio.Utilidades.Email.Enviar(
                        ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                        email,
                        "Esba",
                        usuario.Nombre,
                        ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                        ConfigurationManager.AppSettings["Clave"].ToString(),
                        "Recuperar Contraseña",
                        email + " Tu clave es: " + Negocio.Utilidades.Seguridad.DesEncriptar(usuario.Clave),
                        false,
                        ConfigurationManager.AppSettings["Host"].ToString(),
                        Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"].ToString()),
                        Convert.ToBoolean(ConfigurationManager.AppSettings["UsaSSL"].ToString()));

                    resultado.EsCorrecto = true;
                }
                else
                {
                    resultado.EsCorrecto = false;
                    resultado.Mensaje = "El email ingresado no se encuentra registrado";
                }

            
            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;
                throw;
            }

            return resultado;
        }
        #endregion

        #region Metodos privados
        private static int Insertar(Entidades.Usuario usuario)
        {
            usuario.Clave = Utilidades.Seguridad.Encriptar(usuario.Clave);
            int idUsuario=Datos.Usuario.Insertar(usuario);
            usuario.IdUsuario = idUsuario;


            return idUsuario;
        }

        private static void Actualizar(Entidades.Usuario usuario)
        {
            usuario.Clave = Utilidades.Seguridad.Encriptar(usuario.Clave);
            Datos.Usuario.Actualizar(usuario);
        }

        private static bool Validar(Entidades.Usuario usuario,out string error)
        {
            error = "";


            if (string.IsNullOrEmpty(usuario.Nombre))
                error = error + "El campo nombre se encuentra vacio ";

            if (string.IsNullOrEmpty(usuario.Apellido))
                error = error + "El campo Apellido se encuentra vacio  ";

            if (string.IsNullOrEmpty(usuario.Email))
                error = error + "El campo Email se encuentra vacio  ";

            if (string.IsNullOrEmpty(usuario.Direccion))
                error = error + "El campo Direccion se encuentra vacio  ";

            if (string.IsNullOrEmpty(usuario.Clave))
                error = error + "El campo Clave se encuentra vacio ";
           
            if (String.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Usuario ArmarDatos(DataRow fila)
        {
            Entidades.Usuario usuario = new Entidades.Usuario();

            usuario.Nombre = fila["Nombre"].ToString();
            usuario.Apellido = fila["Apellido"].ToString();
            usuario.Clave = fila["Clave"].ToString();
            usuario.Direccion = fila["Direccion"].ToString();
            usuario.Email = fila["Email"].ToString();
            usuario.IdUsuario = Convert.ToInt32(fila["IdUsuario"]);
            usuario.TipoPermiso = (Entidades.Enumerables.Usuario.TipoPermisos)Convert.ToInt32(fila["IdPermiso"]);
            usuario.ListaMenu = Menu.ListarPorUsuario(usuario.IdUsuario.Value);
            usuario.Estado = (Entidades.Enumerables.Usuario.Estado)Convert.ToInt32(fila["IdEstado"]);

            //usuario.Edad = Convert.ToInt32(fila["Edad"]);
            //usuario.FechaNacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
            //usuario.TipoUsuario = (Entidades.Enumerables.Usuario.TipoUsuario)(Convert.ToInt32(fila["TipoUsuario"]));

            return usuario;
        }

        public void LoguearEvento(object objeto)
        {
            Entidades.Usuario usuario = (Entidades.Usuario)objeto;
            string usuarioXML = JsonConvert.SerializeObject(usuario);
        }
        #endregion

    }
}
