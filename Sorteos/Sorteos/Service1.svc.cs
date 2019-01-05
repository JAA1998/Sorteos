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
        /* Método: Conectar
         * 
         * @param query: query de ejecuion sobre la base de datos
         * @return retorna la validez de la ejecución del query en la base de datos
         */
        public int Conectar(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }

        /*
         * Método: ConsultarJuego
         * ----------------------
         * Esta funcion permite conocer el estatus de un juego (Activo o Inactivo)
         * 
         * @param idJuego: entero que representa el id del juego en la base de datos
         * @retrun retorna 1 si se consigue en la tabla la fila que contenga el estatus (Activo) del juego
         * @return retorna 0 si se consigue en la tabla la fila que contenga el estatus (Inactivo) del juego
         * @return retorna 0 si no consigue la fila en la base de datos
         * 
         */
        public int ConsultarJuego(int idJuego)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_JUEGO WHERE ID_JUEGO=" + idJuego;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = reader.GetString(0);
                    if (Convert.ToInt32(result) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            finally{
                connection.Close();
            }
        }



        public int ConsultarItem(int idItem)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = reader.GetString(0);
                    if (Convert.ToInt32(result) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public int ConsultarSorteo(int idSorteo)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_SORTEO WHERE ID_SORTEO=" +  idSorteo;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = reader.GetString(0);
                    if (Convert.ToInt32(result) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public int ConsultarSJ(int idSorteo, int idJuego)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo + "AND ID_JUEGO=" + idJuego;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = reader.GetString(0);
                    if (Convert.ToInt32(result) == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public int ConsultarDia(int idSorteo, string dia)
        {
            try
            {
                string query = "SELECT A.NOMBRE FROM TB_DIA A JOIN TB_DIA_SORTEO B ON A.ID_DIA=B.ID_DIA WHERE B.ID_SORTEO=" + idSorteo;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                        if (string.Equals(result, dia))
                        {
                            return 0;
                        }
                    }
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public int ConsultarHora(int idJuego, string hora, string dia)
        {
            try
            {
                string query = "SELECT ID_SORTEO, HORA FROM TB_SORTEO WHERE ID_JUEGO=" + idJuego;
                string result1 = string.Empty, result2 = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result1 = reader.GetString(0);
                        result2 = reader.GetString(1);
                        if (string.Equals(result2, hora))
                        {
                            if (ConsultarDia(Convert.ToInt32(result1), dia) == 0)
                            {
                                return 0;
                            }
                        }
                    }
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void ObtenerItem(int idItem, ref int cupo, ref float monto)
        {
            try
            {
                string query = "SELECT CUPO, MONTO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                string result1 = string.Empty, result2 = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result1 = reader.GetString(0);
                    result2 = reader.GetString(1);
                    cupo = Convert.ToInt32(result1);
                    monto = (float) Convert.ToDouble(result1);
                }
                else
                {
                    throw new Exception();
                }
            }
            finally
            {
                connection.Close();
            }
        }

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

        public Respuesta ConsultarSorteoxJuego(Sorteo s)
        {
            try
            {

                if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                if (ConsultarJuego(s.ID_JUEGO) == 0)
                {
                    return new Respuesta("El juego que intenta consultar no se encuentra registrado en el sistema");
                }

                string query = "SELECT A.ID_SORTEO, A.HORA, D.NOMBRE, A.ESTATUS, F.NOMBRE, F.VALOR, F.CUPO, F.MONTO FROM TB_SORTEO A JOIN TB_JUEGO B ON A.ID_JUEGO=B.ID_JUEGO JOIN TB_DIA_SORTEO C ON A.ID_SORTEO=C.ID_SORTEO JOIN TB_DIA D ON C.ID_DIA=D.ID_DIA JOIN TB_SORTEO_ITEM E ON A.ID_SORTEO=E.ID_SORTEO JOIN TB_ITEM F ON E.ID_ITEM=F.ID_ITEM WHERE B.ID_JUEGO=" + s.ID_JUEGO;
                Respuesta result = new Respuesta(string.Empty);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Mensaje = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3) + "-" + reader.GetString(4) + "-" + reader.GetString(5) + "-" + reader.GetString(6) + "-" + reader.GetString(7);
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

                //validar apuestas activas

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
