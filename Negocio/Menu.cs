using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Menu
    {
        

        #region Metodos publicos
        public static List<Entidades.Menu> Listar()
        {
            List<Entidades.Menu> listaMenu = new List<Entidades.Menu>();

            foreach (DataRow item in Datos.Menu.Listar().Rows)
            {
                listaMenu.Add(ArmarDatos(item));
            }     

            return listaMenu;
        }

        public static List<Entidades.Menu> ListarPorUsuario(int IdUsuario)
        {
            List<Entidades.Menu> listaMenu = new List<Entidades.Menu>();

            foreach (DataRow item in Datos.Menu.ListarPorUsuario(IdUsuario).Rows)
            {
                listaMenu.Add(ArmarDatos(item));
            }

            return listaMenu;
        }

        public static List<Entidades.Menu> ListarPorProducto(int IdProducto)
        {
            List<Entidades.Menu> listaMenu = new List<Entidades.Menu>();

            foreach (DataRow item in Datos.Menu.ListarPorProducto(IdProducto).Rows)
            {
                listaMenu.Add(ArmarDatos(item));
            }

            return listaMenu;
        }
        #endregion

        #region metodos privados
        private static Entidades.Menu ArmarDatos(DataRow dr)
        {
            Entidades.Menu menu = new Entidades.Menu();

            menu.IdMenu = Convert.ToInt32(dr["IdMenu"]);
            menu.Accion = dr["Accion"].ToString();
            menu.Controlador= dr["Controlador"].ToString();
            menu.Activo = Convert.ToBoolean(dr["Activo"]);
            menu.Descripcion= dr["Descripcion"].ToString();
            menu.SubMenu = Negocio.SubMenu.Listar().Where(x=> x.IdMenu== menu.IdMenu).ToList();
            menu.TieneSubMenu = menu.SubMenu.Count > 0;

            return menu;        
        }
        #endregion

    }


}
