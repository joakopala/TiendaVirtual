using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SubMenu
    {

        #region Metodos publicos
        public static List<Entidades.SubMenu> Listar()
        {
            List<Entidades.SubMenu> listaSubMenu = new List<Entidades.SubMenu>();

            foreach (DataRow item in Datos.SubMenu.Listar().Rows)
            {
                listaSubMenu.Add(ArmarDatos(item));
            }     

            return listaSubMenu;
        }
        #endregion

        #region metodos privados
        private static Entidades.SubMenu ArmarDatos(DataRow dr)
        {
            Entidades.SubMenu SubMenu = new Entidades.SubMenu();

            SubMenu.IdSubMenu = Convert.ToInt32(dr["IdSubMenu"]);
            SubMenu.Accion = dr["Accion"].ToString();
            SubMenu.Controlador= dr["Controlador"].ToString();
            SubMenu.Activo = Convert.ToBoolean(dr["Activo"]);
            SubMenu.IdMenu = Convert.ToInt32(dr["IdMenu"]);
            SubMenu.Descripcion= dr["Descripcion"].ToString();

            return SubMenu;        
        }
        #endregion

    }


}
