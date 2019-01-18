using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService;


namespace ServicioLotoUCAB.Servicio.Logica.Comandos
{
    public class FabricaComandos
    {
        public static ComandoCrearSorteo FabricarComandoCrearSorteo(Sorteo s)
        {
            return new ComandoCrearSorteo(s);
        }

        public static ComandoModificarSorteo FabricarComandoModificarSorteo(Sorteo s)
        {
            return new ComandoModificarSorteo(s);
        }

        public static ComandoEliminarSorteo FabricarComandoEliminarSorteo(Sorteo s)
        {
            return new ComandoEliminarSorteo(s);
        }

        public static ComandoConsultarSorteoxJuego FabricarComandoConsultarSorteoxJuego(Sorteo s)
        {
            return new ComandoConsultarSorteoxJuego(s);
        }
    }
}
