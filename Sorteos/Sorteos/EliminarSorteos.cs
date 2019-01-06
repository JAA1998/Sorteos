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
    public class EliminarSorteo
    {
        public Respuesta EliminarSorteo(Sorteo s)
        {
            try
            {

                if (s.ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                if (ConsultarSorteo(s.ID_SORTEO) == 0)
                {
                    return new Respuesta("El sorteo que intenta eliminar no se encuentra registrado en el sistema");
                }

                if (ConsultarApuestas(s.ID_SORTEO) == 0)
                {
                    return new Respuesta("El sorteo que intenta eliminar tiene apuestas activas asociadas");
                }

                connection.Open();

                string query = "UPDATE TB_SORTEO SET ESTATUS=0 WHERE ID_SORTEO = " + s.ID_SORTEO;

                int result = Conectar(query);

                if (result == 1)
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
                return new Respuesta ("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}