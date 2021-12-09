using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Enumerables
{
    public class Producto
    {
        public enum TipoProducto
        { 
            Admin=1,
            Comprador=2,
            Vendedor=3
        
        }

        public enum TipoPermisos
        {
            Admin = 1,
            Comprador = 2,
            Vendedor = 3
        }

        public enum Estado
        {
            Activo = 1,
            Inactivo = 0
        }

    }
}
