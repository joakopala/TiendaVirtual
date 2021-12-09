using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Enumerables.Producto;

namespace Entidades
{
    public class Producto
    {
        #region Propiedades

        public int? IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Stock { get; set; }
        public int? PrecioUnitario { get; set; }
        public string Descripcion { get; set; }
        public TipoPermisos TipoPermiso { get; set; }
        public Estado Estado { get; set; }
        public List<Menu> ListaMenu { get; set; }

        public Producto()
        { }
        public Producto(string nombre, string marca, string modelo, int stock, int precioUnitario, string descripcion, TipoPermisos tipoPermiso)
        {
            Nombre = nombre;
            Marca = marca;
            Modelo = modelo;
            Stock = stock;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
            TipoPermiso = tipoPermiso;
            ListaMenu = new List<Menu>();
            Estado = Estado.Activo;
        }

        #endregion

    }
}
