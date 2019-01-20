using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Comunes
{
    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public Object Objeto { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        //CONSTRUCTOR PARA ERRORES
        public Respuesta (string m)
        {
            this.Mensaje = m;
        }

        //CONSTRUCTOR PARA OBJETOS
        public Respuesta(Object o)
        {
            this.Objeto = o;
        }

        //OTRO CONSTRUCTOR
        public Respuesta(Object o, String m)
        {
            this.Objeto = o;
            this.Mensaje = m;
        }
    }
}
