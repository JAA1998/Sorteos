using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarItem : Comando<int>
    {
        private int idItem;
        private int idJuego;

        public ComandoConsultarItem(int idI, int idJ)
        {
            this.idItem = idI;
            this.idJuego = idJ;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarItem(idItem, idJuego);
        }
    }
}
