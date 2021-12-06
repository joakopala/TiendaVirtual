using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Enumerables.Usuario;

namespace Entidades
{
    public class Usuario
    {
        #region Propiedades

        public int? IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public TipoPermisos TipoPermiso { get; set; }
        public Estado Estado { get; set; }
        public List<Menu> ListaMenu { get; set; }

        public Usuario()
        { }
        public Usuario(string nombre, string apellido, string email, string direccion, string clave, int edad, TipoUsuario tipoUsuario, TipoPermisos tipoPermiso)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Clave = clave;
            Edad = edad;
            FechaNacimiento = DateTime.Now.AddYears(-edad);
            TipoUsuario = tipoUsuario;
            Direccion = direccion;
            ListaMenu = new List<Menu>();
            TipoPermiso = tipoPermiso;
            Estado = Estado.Activo;
        }

        #endregion

    }
}
