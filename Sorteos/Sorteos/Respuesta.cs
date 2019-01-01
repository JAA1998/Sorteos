using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sorteos
{
    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public string Mensaje { get; set; }

        public Respuesta(string msg)
        {
            this.Mensaje = msg;
        }
    }
}
