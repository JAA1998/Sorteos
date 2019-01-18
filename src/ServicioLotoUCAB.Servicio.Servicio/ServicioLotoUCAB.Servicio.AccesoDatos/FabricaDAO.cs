using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos
{
    public class FabricaDao
    {

        public static DaoSorteos FabricarDaoSorteos()
        {
            return new DaoSorteos();
        }
    }
}
