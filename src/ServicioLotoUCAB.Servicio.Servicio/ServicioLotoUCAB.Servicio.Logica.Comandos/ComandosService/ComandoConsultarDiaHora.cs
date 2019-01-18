using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarDiaHora : Comando<int>
    {
        private int idSorteo;
        private int idDia;
        private string hora;
        private int idJuego;

        public ComandoConsultarDiaHora(int idS, int idD, string h, int idJ)
        {
            this.idSorteo = idS;
            this.idDia = idD;
            this.hora = h;
            this.idJuego = idJ;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarDiaHora(idSorteo, idDia, hora, idJuego);
        }
    }
}
