using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ILogeable
    {
        void LoguearEvento(Object objeto);

        void Saltar(Object objeto);
    }
}
