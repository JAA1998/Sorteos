using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorteos
{
    public class ParameterException:Exception
    {

        public ParameterException(string p)
            : base("El parámetro " + p + " es un parámetro obligatorio. Por favor verifique e intente de nuevo.")
        {}

    }
}