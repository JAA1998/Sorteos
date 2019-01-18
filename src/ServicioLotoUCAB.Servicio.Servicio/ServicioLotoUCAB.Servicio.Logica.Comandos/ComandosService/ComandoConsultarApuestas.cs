using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarApuestas : Comando<int>
    {
        private int idSorteo;

        public ComandoConsultarApuestas(int idS)
        {
            this.idSorteo = idS;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarApuestas(idSorteo);
        }
    }
}
