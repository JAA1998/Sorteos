using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorteos
{
    public class DBException:Exception
    {

        public DBException()
            : base("No se conectó")
        { }

    }
}