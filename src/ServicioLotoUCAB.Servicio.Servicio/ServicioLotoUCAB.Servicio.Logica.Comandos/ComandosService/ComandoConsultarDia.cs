using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoConsultarDia : Comando<int>
    {
        private int idDia;

        public ComandoConsultarDia(int idD)
        {
            this.idDia = idD;
        }

        public override int Ejecutar()
        {
            DaoSorteos dao = new DaoSorteos();
            return dao.ConsultarDia(idDia);
        }
    }
}
