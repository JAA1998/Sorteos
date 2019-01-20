using ServicioLotoUCAB.Servicio.AccesoDatos;
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
    public class ComandoModificarSorteo : IComando<Respuesta>
    {
        private Sorteo s;

        public ComandoModificarSorteo(Sorteo sort)
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
                if (s == null || s.juego == null || s.juego.id_juego == null)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                if (s.id_sorteo == null)
                {
                    throw new ParameterException("ID_SORTEO");
                }
                if (s.items == null || s.items.Count == 0)
                {
                    throw new ParameterException("ID_ITEM");
                }
                if (s.hora.Length == 0 || s.hora == null)
                {
                    throw new ParameterException("HORA");
                }
                if (s.dias == null || s.dias.Count == 0)
                {
                    throw new ParameterException("ID_DIA");
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
                 * Comprueba que el juego este registrado en la base de datos
                 */
                result = dao.ConsultarJuego(s.juego.id_juego);

                if (result != 1)
                {
                    throw new ConsultarException("El juego " + s.juego.id_juego + " no se encuentra registrado en el sistema");
                }

                /**
                 * Comprueba que los items esten registrados en la base de datos
                 */
                foreach (Item i in s.items)
                {
                    result = dao.ConsultarItem(i.id_item, s.juego.id_juego);
                    if (result != 1)
                    {
                        throw new ConsultarException("El item " + i.id_item + " no se encuentra registrado en el sistema o no pertenece al juego " + s.juego.id_juego);
                    }
                }

                /**
                 * Comprueba que el sorteo este registrado y asociado al juego
                 */
                result = dao.ConsultarSJ(s.id_sorteo, s.juego.id_juego);
                if (result != 1)
                {
                    throw new ConsultarException("El sorteo que intenta actualizar no se encuentra registrado o no pertenece al juego " + s.juego.id_juego);
                }

                /**
                 * Comprueba que los días esten registrados en la base de datos
                 */
                foreach (Dia d in s.dias)
                {
                    result = dao.ConsultarDia(d.id_dia);
                    if (result != 1)
                    {
                        throw new ConsultarException("El dia " + d.id_dia + " no se encuentra registrado en el sistema");
                    }
                }

                /**
                 * Comprueba que no haya un sorteo del mismo juego, la misma hora y el mismo día registrado en la base de datos
                 */
                List<int> sorteosHora = dao.ConsultarHora(s.juego.id_juego, s.hora);

                if (sorteosHora != null || sorteosHora.Count != 0)
                {
                    foreach (int idS in sorteosHora)
                    {
                        foreach (Dia i in s.dias)
                        {
                            result = dao.ConsultarDiaHora(idS);
                            if (result == i.id_dia)
                            {
                                throw new ConsultarException("El sorteo de hora " + s.hora + " para el día " + i.id_dia + " del juego " + s.juego.id_juego + " ya se encuentra registrado en el sistema");
                            }
                        }
                    }
                }

                /**
                 * Comprueba que no haya apuestas asociadas al sorteo
                 */
                result = dao.ConsultarApuestas(s.id_sorteo);

                if (result == 1)
                {
                    throw new ConsultarException("El sorteo que intenta modificar tiene apuestas activas asociadas");
                }

                int cupo = 0;
                float monto = 0;

                /**
                 * Realiza la insersión del sorteo
                 */
                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    result = dao.ModificarSorteo(s.id_sorteo, s.juego.id_juego, s.hora);
                    result = dao.EliminarSorteoItem(s.id_sorteo);
                    foreach (Item i in s.items)
                    {
                        result = dao.ConsultarDatosItem(i.id_item, ref cupo, ref monto);
                        if (result != 1)
                        {
                            throw new ConsultarException("El item " + i.id_item + " no se encuentra registrado en el sistema");
                        }
                        result = dao.InsertarSorteoItem(i.id_item, s.id_sorteo, cupo, monto);
                    }
                    result = dao.EliminarSorteoDia(s.id_sorteo);
                    foreach (Dia d in s.dias)
                    {
                        result = dao.InsertarSorteoDia(d.id_dia, s.id_sorteo);
                    }
                    transaction.Complete();
                }

                /**
                 * Devuelve la respuesta
                 */
                if (result > 0)
                {
                    return new Respuesta("Actualizado Exitosamente");
                }
                else
                {
                    throw new DBException();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
