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
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.AccesoDatos;

namespace ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService
{
    public class ComandoCrearSorteo : IComando<Respuesta>
    {
        private Sorteo s;

        public ComandoCrearSorteo(Sorteo sort)
        {
            this.s = sort;
        }

        public Respuesta Ejecutar()
        {
            try
            {
                if (s.juego.id_juego == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                if (s.items == null || s.items.Count == 0)
                {
                    throw new ParameterException("ID_ITEM");
                }
                if (s.hora.Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                if (s.dias == null || s.dias.Count == 0)
                {
                    throw new ParameterException("ID_DIA");
                }

                int result;

                DaoSorteos dao = FabricaDao.FabricarDaoSorteos();

                result = dao.ConsultarJuego(s.juego.id_juego);

                if (result != 1)
                {
                    throw new ConsultarException("El juego " + s.juego.id_juego + " no se encuentra registrado en el sistema");
                }

                foreach (Item i in s.items)
                {
                    result = dao.ConsultarItem(i.id_item, s.juego.id_juego);
                    if (result != 1)
                    {
                        throw new ConsultarException("El item " + i.id_item + " no se encuentra registrado en el sistema o no pertenece al juego " + s.juego.id_juego);
                    }
                }

                foreach (Dia d in s.dias)
                {
                    result = dao.ConsultarDia(d.id_dia);
                    if (result != 1)
                    {
                        throw new ConsultarException("El dia " + d.id_dia + " no se encuentra registrado en el sistema");
                    }
                }

                List<int> sorteosHora =  dao.ConsultarHora(s.juego.id_juego, s.hora);

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

                int cupo = 0;
                float monto = 0;

                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    int idSorteo = dao.InsertarSorteo(s.juego.id_juego, s.hora);
                    foreach (Item i in s.items)
                    {
                        result = dao.ConsultarDatosItem(i.id_item, ref cupo, ref monto);
                        if (result != 1)
                        {
                            throw new ConsultarException("El item " + i.id_item + " no se encuentra registrado en el sistema");
                        }
                        result = dao.InsertarSorteoItem(i.id_item, idSorteo, cupo, monto);
                    }
                    foreach (Dia d in s.dias)
                    {
                        result = dao.InsertarSorteoDia(d.id_dia, idSorteo);
                    }
                    transaction.Complete();
                }

                if (result > 0)
                {
                    return new Respuesta("Sorteo Creado Exitosamente");
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
