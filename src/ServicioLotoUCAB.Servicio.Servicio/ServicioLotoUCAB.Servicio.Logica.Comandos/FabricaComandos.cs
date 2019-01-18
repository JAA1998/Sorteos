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

        public static ComandoConsultarJuego FabricarComandoConsultarJuego(int idJuego)
        {
            return new ComandoConsultarJuego(idJuego);
        }

        public static ComandoConsultarSorteo FabricarComandoConsultarSorteo(int idSorteo)
        {
            return new ComandoConsultarSorteo(idSorteo);
        }

        public static ComandoConsultarItem FabricarComandoConsultarItem(int idItem, int idJuego)
        {
            return new ComandoConsultarItem(idItem, idJuego);
        }

        public static ComandoConsultarDia FabricarComandoConsultarDia(int idDia)
        {
            return new ComandoConsultarDia(idDia);
        }

        public static ComandoConsultarDiaHora FabricarComandoConsultarDiaHora(int idSorteo, int idDia, string hora, int idJuego)
        {
            return new ComandoConsultarDiaHora(idSorteo, idDia, hora, idJuego);
        }

        public static ComandoConsultarHora FabricarComandoConsultarHora(int idJuego, string hora)
        {
            return new ComandoConsultarHora(idJuego, hora);
        }

        public static ComandoConsultarSJ FabricarComandoConsultarSJ(int idSorteo, int idJuego)
        {
            return new ComandoConsultarSJ(idSorteo, idJuego);
        }

        public static ComandoConsultarApuestas FabricarComandoConsultarApuestas(int idSorteo)
        {
            return new ComandoConsultarApuestas(idSorteo);
        }

        public static ComandoConsultarDatosItem FabricarComandoConsultarDatosItem(int idItem, ref int cupo, ref float monto)
        {
            return new ComandoConsultarDatosItem(idItem, ref cupo, ref monto);
        }
    }
}
