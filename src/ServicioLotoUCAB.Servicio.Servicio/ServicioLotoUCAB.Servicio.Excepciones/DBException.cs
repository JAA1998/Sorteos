using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Excepciones
{
    public class DBException : Exception
    {

        public DBException()
            : base("Error con la base de datos")
        { }

    }
}
