using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarHora : Comando<List<int>>
    {
        private int idJuego;
        private string hora;

        public ComandoConsultarHora(int idJ, string h)
        {
            this.idJuego = idJ;
            this.hora = h;
        }

        public override List<int> Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarHora(idJuego, hora);
        }
    }
}
