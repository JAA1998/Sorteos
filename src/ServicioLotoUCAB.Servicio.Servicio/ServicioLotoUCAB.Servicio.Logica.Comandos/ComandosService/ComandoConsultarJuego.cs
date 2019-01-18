using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarJuego : Comando<int>
    {
        private int idJuego;

        public ComandoConsultarJuego(int idJ)
        {
            this.idJuego = idJ;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarJuego(idJuego);
        }
    }
}
