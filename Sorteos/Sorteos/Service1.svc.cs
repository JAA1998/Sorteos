using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using Sorteos;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        MySqlConnection connection;
        MySqlConnectionStringBuilder builder;

        public Service1()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "jalejandro541";
            builder.Database = "proyecto";

            connection = new MySqlConnection(builder.ToString());
        }

        public Respuesta CrearSorteo(Sorteo s)
        {
            try
            {

                if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                else if (s.HORA.ToString().Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                else if (s.ESTATUS.ToString().Length == 0)
                {
                    throw new ParameterException("ESTATUS");
                }

                //validar validar hora y dia disponible

                string query = "INSERT INTO TB_SORTEO (ID_SORTEO, ID_JUEGO, HORA, ESTATUS) VALUES (NULL, '" + s.ID_JUEGO + "', '" + s.HORA + "', " + s.ESTATUS + ")";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                int result = command.ExecuteNonQuery();

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

        public Respuesta ConsultarSorteoxJuego(Sorteo s)
        {
            try
            {

                if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                //validar si está el juego y su estatus

                string query = "SELECT A.ID_SORTEO, A.ID_JUEGO, A.HORA, A.ESTATUS FROM TB_SORTEO A join TB_JUEGO B on A.ID_JUEGO=B.ID_JUEGO WHERE B.ID_JUEGO=" + s.ID_JUEGO;
                Respuesta result = new Respuesta(string.Empty);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Mensaje = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3);
                    }

                    return result;
                }
                else
                {
                    return new Respuesta("No se encontró");
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

        public int ConsultarSorteo(int ID_SORTEO)
        {

            try
            {

                if (ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                //validar si está el juego y su estatus

                string query = "SELECT A.ID_SORTEO FROM TB_SORTEO A WHERE A.ID_SORTEO=" + ID_SORTEO;
                Respuesta result = new Respuesta(string.Empty);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }

        }

        public int ConsultarSorteoEstatus(int ID_SORTEO)
        {

            try
            {

                if (ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                //validar si está el juego y su estatus

                string query = "SELECT A.ID_SORTEO FROM TB_SORTEO A WHERE A.ID_SORTEO=" + ID_SORTEO + "or A.ESTATUS=Eliminado";
                Respuesta result = new Respuesta(string.Empty);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }

        }

        public Respuesta EliminarSorteo(Sorteo s)
        {
            try
            {

                if (s.ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                if (ConsultarSorteo(s.ID_SORTEO) == )
                {
                    return new Respuesta("El sorteo que intenta eliminar no se encuentra registrado en el sistema");
                }

                //validar apuestas activas

                string query = "UPDATE TB_SORTEO SET ESTATUS=Eliminado WHERE ID_SORTEO = " + s.ID_SORTEO;
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                int result = command.ExecuteNonQuery();

                if (result == 1)
                {
                    return new Respuesta("Eliminado exitosamente");
                }
                else
                {
                    return new Respuesta("No pudo ser eliminado");
                    //throw new DBException();
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

        public Respuesta ModificarSorteo(Sorteo s)
        {
            try
            {
                if (s.ID_SORTEO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }
                else if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                else if (s.HORA.ToString().Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                else if (s.ESTATUS.ToString().Length == 0)
                {
                    throw new ParameterException("ESTATUS");
                }

                string query = "UPDATE TB_SORTEO SET ID_JUEGO='" + s.ID_JUEGO + "', HORA='" + s.HORA + "', ESTATUS=" + s.ESTATUS + " WHERE ID_SORTEO=" + s.ID_SORTEO;
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                int result = command.ExecuteNonQuery();

                if (result == 1)
                {
                    return new Respuesta("Actualizado exitosamente");
                }
                else
                {
                    return new Respuesta("No pudo ser actualizado");
                    //throw new DBException();
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
