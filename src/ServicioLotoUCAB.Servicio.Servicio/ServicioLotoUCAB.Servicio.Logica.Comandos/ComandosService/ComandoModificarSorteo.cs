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
    public class ComandoModificarSorteo : Comando<Respuesta>
    {
        private Sorteo s;

        public ComandoModificarSorteo(Sorteo sort)
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

                ComandoConsultarJuego cj = FabricaComandos.FabricarComandoConsultarJuego(s.juego.id_juego);
                cj.Ejecutar();

                foreach (Item i in s.items)
                {
                    ComandoConsultarItem ci = FabricaComandos.FabricarComandoConsultarItem(i.id_item, s.juego.id_juego);
                    ci.Ejecutar();
                }

                ComandoConsultarSJ csj = FabricaComandos.FabricarComandoConsultarSJ(s.id_sorteo, s.juego.id_juego);
                csj.Ejecutar();

                foreach (Dia d in s.dias)
                {
                    ComandoConsultarDia cd = FabricaComandos.FabricarComandoConsultarDia(d.id_dia);
                    cd.Ejecutar();
                }

                ComandoConsultarHora ch = FabricaComandos.FabricarComandoConsultarHora(s.juego.id_juego, s.hora);
                List<int> sorteosHora = ch.Ejecutar();

                if (sorteosHora != null || sorteosHora.Count != 0)
                {
                    foreach (int idS in sorteosHora)
                    {
                        foreach (Dia i in s.dias)
                        {
                            ComandoConsultarDiaHora cdh = FabricaComandos.FabricarComandoConsultarDiaHora(idS, i.id_dia, s.hora, s.juego.id_juego);
                            cdh.Ejecutar();
                        }
                    }
                }

                int result = 0, cupo = 0;
                float monto = 0;
                DaoSorteos dao = new DaoSorteos();
                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    result = dao.ModificarSorteo(s.id_sorteo, s.juego.id_juego, s.hora);
                    foreach (Item i in s.items)
                    {
                        ComandoConsultarDatosItem cdi = FabricaComandos.FabricarComandoConsultarDatosItem(i.id_item, ref cupo, ref monto);
                        cdi.Ejecutar();
                        result = dao.ModificarSorteoItem(s.id_sorteo, i.id_item, cupo, monto);
                    }
                    foreach (Dia d in s.dias)
                    {
                        result = dao.ModificarSorteoDia(s.id_sorteo, d.id_dia);
                    }
                    transaction.Complete();
                }

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
