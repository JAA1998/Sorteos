using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarSJ : Comando<int>
    {
        private int idSorteo;
        private int idJuego;

        public ComandoConsultarSJ(int idS, int idJ)
        {
            this.idSorteo = idS;
            this.idJuego = idJ;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarSJ(idSorteo, idJuego);
        }
    }
}
