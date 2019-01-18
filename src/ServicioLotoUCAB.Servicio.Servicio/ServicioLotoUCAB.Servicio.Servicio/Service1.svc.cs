using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;
using System;
using System.Net;
using System.Reflection;
using System.ServiceModel.Web;


namespace ServicioLotoUCAB.Servicio.Servicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /**
         * Método: CrearSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la creacion de un sorteo y lo ingresa a base de datos
         * @param s: Contiene los datos necesarios para poder crear el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se inserto exitosamente el sorteo o si no
         * se pudo insertar
         */
        public Respuesta CrearSorteo(Sorteo s)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                ComandoCrearSorteo cs = FabricaComandos.FabricarComandoCrearSorteo(s);
                return cs.Ejecutar();
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message);
                return new Respuesta("Error: " + e.Message);
            }
        }

        /**
         * Método: EliminarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la eliminacion de un sorteo y cambia su status de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder eliminar el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se elimino exitosamente el sorteo o si no
         * se pudo eliminar
         */
        public Respuesta EliminarSorteo(Sorteo s)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                ComandoEliminarSorteo es = FabricaComandos.FabricarComandoEliminarSorteo(s);
                return es.Ejecutar();
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message);
                return new Respuesta("Error: " + e.Message);
            }
        }

        /**
         * Método: ModificarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la modificacion de un sorteo y cambia sus datos de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder modificar el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se modifico exitosamente el sorteo o si no
         * se pudo modificar
         */
        public Respuesta ModificarSorteo(Sorteo s)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                ComandoModificarSorteo ms = FabricaComandos.FabricarComandoModificarSorteo(s);
                return ms.Ejecutar();
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message);
                return new Respuesta("Error: " + e.Message);
            }
        }

        /**
         * Método: ConsultarSorteoxJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de todos los sorteos de un juego en la 
         * base de datos
         * @param s: Contiene los datos necesarios para poder buscar los sorteos
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica los datos de los sorteos o si hubo un error 
         * o no se encontro el juego
         */
        public Respuesta ConsultarSorteoxJuego(Sorteo s)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                ComandoConsultarSorteoxJuego csxj = FabricaComandos.FabricarComandoConsultarSorteoxJuego(s);
                return csxj.Ejecutar();
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message);
                return new Respuesta("Error: " + e.Message);
            }
        }
    }
}
