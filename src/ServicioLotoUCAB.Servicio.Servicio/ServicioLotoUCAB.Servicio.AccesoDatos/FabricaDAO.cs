using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos
{
    public class FabricaDAO
    {

        public static DaoSorteos CrearDaoSorteos()
        {
            return new DaoSorteos();
        }
    }
}
