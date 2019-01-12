using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorteos
{
    public class ConsultarException : Exception
    {
        public ConsultarException(string p)
            : base(p)
        {}
    }
}