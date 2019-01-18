using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones
{
    public class ConsultarException : Exception
    {
        public ConsultarException(string p)
            : base(p)
        { }
    }
}
