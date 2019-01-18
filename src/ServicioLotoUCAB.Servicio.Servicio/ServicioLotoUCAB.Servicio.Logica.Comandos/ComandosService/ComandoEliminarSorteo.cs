using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoEliminarSorteo : Comando<Respuesta>
    {
        private Sorteo s;

        public ComandoEliminarSorteo(Sorteo sort)
        {
            this.s = sort;
        }

        public override Respuesta Ejecutar()
        {
            try
            {
                if (s.id_sorteo == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }

                ComandoConsultarSorteo cs = FabricaComandos.FabricarComandoConsultarSorteo(s.id_sorteo);
                cs.Ejecutar();

                ComandoConsultarApuestas ca = FabricaComandos.FabricarComandoConsultarApuestas(s.id_sorteo);
                ca.Ejecutar();

                int result = 0;
                DaoSorteos dao = new DaoSorteos();
                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    result = dao.EliminarSorteo(s.id_sorteo);
                    result = dao.EliminarSorteoItem(s.id_sorteo);
                    result = dao.EliminarSorteoDia(s.id_sorteo);
                    transaction.Complete();
                }
                if (result > 0)
                {
                    return new Respuesta("Eliminado exitosamente");
                }
                else
                {
                    throw new DBException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
