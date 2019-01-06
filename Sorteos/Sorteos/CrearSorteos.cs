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

namespace  Sorteos
{
    public class CrearSorteos
    {
        public Respuesta CrearSorteo(Sorteo s)
        {
            try
            {

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
                if (ConsultarHora(s.ID_JUEGO, s.HORA, s.DIA) == 0)
                {
                    return new Respuesta("El sorteo de hora" + s.HORA + " para el día" + s.DIA + " del juego" + s.ID_JUEGO + " ya se encuentra registrado en el sistema");
                }

                int result, cupo = 0;
                float monto = 0;
                string query;

                connection.Open();

                query = "INSERT INTO TB_SORTEO (ID_SORTEO, ID_JUEGO, HORA, ESTATUS) VALUES (NULL, '" + s.ID_JUEGO + "', '" + s.HORA + "', " + 1 + ")";
                result = Conectar(query);

                string ID_SORTEO = "SELECT DISTINCT LAST_INSERT_ID() FROM TB_SORTEO";
                ObtenerItem(s.ID_ITEM, ref cupo, ref monto);

                query = "INSERT INTO TB_SORTEO_ITEM (ID_SORTEO_ITEM, ID_ITEM, ID_SORTEO, CUPO, MONTO, ESTATUS) VALUES (NULL, '" + s.ID_ITEM + "', '" + Convert.ToInt32(ID_SORTEO) + "', " + cupo + "', " + monto + "', " + 1 + ")";
                result = Conectar(query);

                query = "INSERT INTO TB_DIA (ID_DIA, NOMBRE, ESTATUS) VALUES (NULL, '" + s.DIA + "', " + 1 + ")";
                result = Conectar(query);

                string ID_DIA = "SELECT DISTINCT LAST_INSERT_ID() FROM TB_DIA";

                query = "INSERT INTO TB_DIA_SORTEO (ID_DIASORTEO, ID_DIA, ID_SORTEO, ESTATUS) VALUES (NULL, '" + Convert.ToInt32(ID_DIA) + "', '" + Convert.ToInt32(ID_SORTEO) + "', " + 1 + ")";
                result = Conectar(query);

                if (result == 1)
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
                return new Respuesta("Error: "+ e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}