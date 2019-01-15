using Sorteos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Sorteos
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CrearSorteo", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CrearSorteo(Sorteo s);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/ConsultarSorteoxJuego", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Respuesta ConsultarSorteoxJuego(Sorteo s);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/EliminarSorteo", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Respuesta EliminarSorteo(Sorteo s);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/ModificarSorteo", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Respuesta ModificarSorteo(Sorteo s);

    }

}
