using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sorteos
{
    [DataContract]
    public class Sorteo
    {
        [DataMember]
        public int ID_SORTEO { get; set; }

        [DataMember]
        public int ID_JUEGO { get; set; }

        [DataMember]
        public int HORA { get; set; }

        [DataMember]
        public int ESTATUS { get; set; }

    }
}