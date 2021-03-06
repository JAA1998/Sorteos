﻿using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.Comunes;
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
    public class ComandoEliminarSorteo : IComando<Respuesta>
    {
        private Sorteo s;

        public ComandoEliminarSorteo(Sorteo sort)
        {
            this.s = sort;
        }

        public Respuesta Ejecutar()
        {
            try
            {
                /**
                 * Comprueba los parámetros
                 */
                if (s == null || s.id_sorteo == null || s.id_sorteo == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }

                int result;
                DaoSorteos dao = FabricaDao.FabricarDaoSorteos();

                /**
                 * Comprueba que el sorteo este registrado en la base de datos
                 */
                result = dao.ConsultarSorteo(s.id_sorteo);

                if (result != 1)
                {
                    throw new ConsultarException("El sorteo " + s.id_sorteo + " no se encuentra registrado en el sistema");
                }

                /**
                 * Comprueba que no haya apuestas asociadas al sorteo
                 */
                result = dao.ConsultarApuestas(s.id_sorteo);

                if (result == 1)
                {
                    throw new ConsultarException("El sorteo que intenta eliminar tiene apuestas activas asociadas");
                }

                /**
                 * Realiza la eliminación del sorteo
                 */
                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    result = dao.EliminarSorteo(s.id_sorteo);
                    result = dao.EliminarSorteoItem(s.id_sorteo);
                    result = dao.EliminarSorteoDia(s.id_sorteo);
                    transaction.Complete();
                }

                /**
                 * Devuelve la respuesta
                 */
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
