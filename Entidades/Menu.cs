using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {
        #region Propiedades
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Activo { get; set; }
        public bool TieneSubMenu { get; set; }
        public List<SubMenu> SubMenu { get; set; }
        public int Orden { get; set; }
        #endregion
    }
}
