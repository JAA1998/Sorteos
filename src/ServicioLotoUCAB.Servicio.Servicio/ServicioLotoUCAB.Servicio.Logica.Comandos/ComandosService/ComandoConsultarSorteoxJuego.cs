using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarSorteoxJuego : IComando<Respuesta>
    {
        private Sorteo s;

        public ComandoConsultarSorteoxJuego(Sorteo sort)
        {
            this.s = sort;
        }

        public Respuesta Ejecutar()
        {
            try
            {
                if (s.juego.id_juego == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                int result;
                DaoSorteos dao = FabricaDao.FabricarDaoSorteos();

                result = dao.ConsultarJuego(s.juego.id_juego);

                if (result != 1)
                {
                    throw new ConsultarException("El juego " + s.juego.id_juego + " no se encuentra registrado en el sistema");
                }

                string r1 = string.Empty, r2 = string.Empty;

                List<int> listaSorteos = dao.ConsultarSorteosdeJuego(s.juego.id_juego);

                if (listaSorteos == null || listaSorteos.Count == 0)
                {
                    throw new ConsultarException("No se encontraron sorteos");
                }

                foreach (int idSorteo in listaSorteos)
                {
                    r2 = dao.ConsultarSorteoxJuego(idSorteo);
                    r1 = string.Concat(r1, r2, "||");
                    r2 = string.Empty;
                    r2 = dao.ConsultarSorteoItemxJuego(idSorteo);
                    r1 = string.Concat(r1, r2, "|");
                    r2 = string.Empty;
                    r2 = dao.ConsultarSorteoDiaxJuego(idSorteo);
                    r1 = string.Concat(r1, r2, "||");
                    r2 = string.Empty;
                }

                return new Respuesta(r1);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
