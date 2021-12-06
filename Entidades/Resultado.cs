using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Resultado
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public Object Objeto { get; set; }
        public int CantidadCorrectos { get; set; }
        public int CantidadIncorrectos { get; set; }
        public int Procesados { get; set; }

    }
}
