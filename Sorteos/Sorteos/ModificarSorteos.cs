using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using Sorteos;

namespace Sorteos
{
    public class ModificarSorteos
    {
        public Respuesta ModificarSorteo(Sorteo s)
        {
            try
            {
                if (s.ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }
                if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                if (s.ID_ITEM.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                else if (s.HORA.Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                else if (s.DIA.Length == 0)
                {
                    throw new ParameterException("ESTATUS");
                }

                if (ConsultarJuego(s.ID_JUEGO) == 0)
                {
                    return new Respuesta("El juego no se encuentra registrado en el sistema");
                }
                if (ConsultarItem(s.ID_ITEM) == 0)
                {
                    return new Respuesta("El item no se encuentra registrado en el sistema");
                }
                if ((ConsultarSorteo(s.ID_SORTEO) == 0) && (ConsultarSJ(s.ID_SORTEO, s.ID_JUEGO) == 0))
                {
                    return new Respuesta("El sorteo que intenta actualizar no se encuentra registrado o no pertenece al Juego" + s.ID_JUEGO);
                }
                if (ConsultarHora(s.ID_JUEGO, s.HORA, s.DIA) == 0)
                {
                    return new Respuesta("El sorteo de hora" + s.HORA + " para el día" + s.DIA + " del juego" + s.ID_JUEGO + " ya se encuentra registrado en el sistema");
                }

                connection.Open();
                int result, cupo = 0;
                float monto = 0;
                string query;

                query = "UPDATE TB_SORTEO SET ID_JUEGO='" + s.ID_JUEGO + "', HORA='" + s.HORA + " WHERE ID_SORTEO=" + s.ID_SORTEO;
                result = Conectar(query);

                ObtenerItem(s.ID_ITEM, ref cupo, ref monto);

                query = "UPDATE TB_SORTEO_ITEM SET ID_ITEM='" + s.ID_ITEM + "', CUPO='" + cupo + "', MONTO='" + monto + " WHERE ID_SORTEO=" + s.ID_SORTEO;
                result = Conectar(query);

                query = "UPDATE TB_DIA A JOIN TB_DIA_SORTEO B ON A.ID_DIA=B.ID_DIA SET A.NOMBRE='" + s.DIA + " WHERE B.ID_SORTEO=" + s.ID_SORTEO;
                result = Conectar(query);

                if (result == 1)
                {
                    return new Respuesta("Actualizado exitosamente");
                }
                else
                {
                    throw new DBException();
                }
            }
            catch (Exception e)
            {
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}