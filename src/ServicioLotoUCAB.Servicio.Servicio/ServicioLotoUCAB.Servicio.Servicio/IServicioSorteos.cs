using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Entidades;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServicioLotoUCAB.Servicio.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicioSorteos
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/CrearSorteo", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Respuesta CrearSorteo(Sorteo s);

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
