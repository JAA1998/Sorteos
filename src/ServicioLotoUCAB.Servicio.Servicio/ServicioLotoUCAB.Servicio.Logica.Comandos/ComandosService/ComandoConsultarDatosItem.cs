using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarDatosItem : Comando<int>
    {
        private int idItem;
        private int cupo;
        private float monto;

        public ComandoConsultarDatosItem(int idI, ref int c, ref float m)
        {
            this.idItem = idI;
            this.cupo = c;
            this.monto = m;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarDatosItem(idItem, ref cupo, ref monto);
        }
    }
}
