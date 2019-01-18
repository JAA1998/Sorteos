using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarSorteoxJuego : Comando<Respuesta>
    {
        private Sorteo s;

        public ComandoConsultarSorteoxJuego(Sorteo sort)
        {
            this.s = sort;
        }

        public override Respuesta Ejecutar()
        {
            try
            {
                if (s.juego.id_juego == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                ComandoConsultarJuego cj = FabricaComandos.FabricarComandoConsultarJuego(s.juego.id_juego);
                cj.Ejecutar();

                DaoSorteos dao = new DaoSorteos();
                return dao.ConsultarSorteoxJuego(s);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
