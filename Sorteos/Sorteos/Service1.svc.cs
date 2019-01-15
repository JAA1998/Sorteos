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
            //string cx = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            connection = new MySqlConnection(builder.ToString());
        }

        /**
         * Método: ConsultarJuego
         * -------------------------------------------------------------------------------------------------
         * Esta funcion permite consultar el estatus de un juego (Activo o Inactivo)
         * @param idJuego: entero que representa el id del juego en la base de datos
         * @return: retorna 1 si se consigue en la tabla la fila que contenga el estatus (Activo) del juego
         * @return: retorna 0 si se consigue en la tabla la fila que contenga el estatus (Inactivo) del juego
         */
        public int ConsultarJuego(int idJuego)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_JUEGO WHERE ID_JUEGO=" + idJuego;
                int result = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt16(0);
                }
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El juego " + idJuego + " no se encuentra registrado en el sistema");
                }
                
            }
            finally
            {
                connection.Close();
            }
        }
        /**
          * Metodo: ConsultarItem
          * -------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un item
          * @param idItem: Identificador del item que se quiere consultar
          * @return: retorna 1 si se logra obtener el item
          * @return: retorna 0 si ocurre un error
          */
        public int ConsultarItem(int idItem, int idJuego)
        {
            try
            {
                string query = "SELECT ESTATUS, ID_JUEGO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                int result1 = 0, result2 = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    result1 = reader.GetInt16(0);
                    result2 = reader.GetInt32(1);
                }
                if (result1 == 1 && result2 == idJuego) return 1;
                else
                {
                    throw new ConsultarException("El item " + idItem + " no se encuentra registrado en el sistema o no pertenece al juego " + idJuego);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /**
          * Metodo: ConsultarSorteo
          * -----------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un sorteo
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @return: retorna 1 si se logra obtener el sorteo
          * @return: retorna 0 si ocurre un error o no se encontro
          */
        public int ConsultarSorteo(int idSorteo)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo;
                int result = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt16(0);
                }
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El sorteo " + idSorteo + " no se encuentra registrado en el sistema");
                }

            }
            finally
            {
                connection.Close();
            }
        }

        /**
          * Metodo: ConsultarDia
          * -----------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un dia
          * @param idDia: Identificador del dia que se quiere consultar
          * @return: retorna 1 si se logra obtener el dia
          * @return: retorna 0 si ocurre un error o no se encontro
          */
        public int ConsultarDia(int idDia)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_DIA WHERE ID_DIA=" + idDia;
                int result = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt16(0);
                }
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El dia " + idDia + " no se encuentra registrado en el sistema");
                }

            }
            finally
            {
                connection.Close();
            }
        }

        /**
          * Metodo: ConsultarSJ
          * ----------------------------------------------------------------------
          * Esta funcion permite consultar un sorteo de un determinado juego
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @param idJuego: Identificador del juego al que se le buscara un sorteo 
          * @return: retorna 1 si se logra obtener el sorteo
          * @return: retorna 0 si ocurre un error o no se encontro
          */
        public int ConsultarSJ(int idSorteo, int idJuego)
        {
            try
            {
                string query = "SELECT ESTATUS, ID_JUEGO FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo;
                int result1 = 0, result2 = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result1 = reader.GetInt16(0);
                    result2 = reader.GetInt16(1);
                }
                if (result1 == 1 && result2 == idJuego) return 1;
                else
                {
                    throw new ConsultarException("El sorteo que intenta actualizar no se encuentra registrado o no pertenece al juego " + idJuego);
                }

            }
            finally
            {
                connection.Close();
            }
        }

        /**
          * Metodo: ConsultarDiaHora
          * ------------------------------------------------------------------
          * Esta funcion permite consultar el dia de un sorteo y verificar si
          * es igual al dia que se le pasa como parametro
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @param dia: Es el dia que se quiere revisar
          * @return: retorna 0 los dias del sorteo y la variable "dia" son iguales
          * @return: retorna 1 si ocurre un error o no son iguales
          */
        public int ConsultarDiaHora(int idSorteo, int idDia, int con)
        {
            try
            {
                string query = "SELECT ID_DIA FROM TB_DIA_SORTEO WHERE ID_SORTEO=" + idSorteo;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                if (con == 0)
                    connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read()) {
                    result = reader.GetString(0);
                }
                if (Convert.ToInt32(result) == idDia)
                    return 1;
                else return 0;
                
            }
            finally
            {
                if (con == 0)
                    connection.Close();
            }
        }

        /**
          * Metodo: ConsultarHora
          * -----------------------------------------------------------------------
          * Esta funcion permite consultar si hay un sorteo del juego a la hora que es 
          * pasada por parametro 
          * @param idJuego: Identificador del juego al que 
          * @param hora: Es la hora que se quiere revisar
          * @param dia: es el dia del sorteo que se quiere revisar
          * @return: retorna 0 ya existe un sorteo en esa hora 
          * @return: retorna 1 si ocurre un error o no existe un sorteo a esa hora
          */
        public int ConsultarHora(int idJuego, string hora, int idDia)
        {
            try
            {
                string query = "SELECT ID_SORTEO, HORA, ESTATUS FROM TB_SORTEO WHERE ID_JUEGO=" + idJuego;
                string result1 = string.Empty, result2 = string.Empty, result3 = string.Empty; ;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    result1 = reader.GetString(0);
                    result2 = reader.GetString(1);
                    result3 = reader.GetString(2);
        
                    if (string.Equals(result2, hora) && Convert.ToInt32(result3) == 1)
                    {
                        //reader.Close();
                        if (ConsultarDiaHora(Convert.ToInt32(result1), idDia, 1) == 1)
                        {
                            return 0;
                            //throw new ConsultarException("El sorteo de hora especificada para el día especificado del juego especificado ya se encuentra registrado en el sistema");
                        }
                        
                        
                    }
                }
                return 1;
                
            }
            finally
            {
                connection.Close();
            }
        }

        /**
         * Metodo: ConsultarApuestas
         * ------------------------------------------------------------------------------
         * Esta función permite consultar el estatus de una apuesta realizada según el
         * sorteo que es pasado por parametro
         * @param idSorteo: Identificador del sorteo a consultar
         * @return: 1 si consigue la fila en la base de datos el id
         * @retrun: 0 si no consigue la fila o existe un error
         */
        public int ConsultarApuestas(int idSorteo)
        {
            try
            {
                connection.Open();
                string query = "SELECT ESTATUS FROM TB_JUGADA WHERE ID_SORTEO=" + idSorteo;
                int result = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt16(0);
                }
                if (result == 1)
                {
                    throw new ConsultarException("El sorteo que intenta eliminar tiene apuestas activas asociadas"); 
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
        /**
         * Método: ConsultarDatosItem
         * ---------------------------------------------------------------------------
         * Este metodo realiza la consulta de los datos tales como cupo y monto segun
         * el item pasados por parametro
         * @param idItem: Identificador de referencia en la base de datos
         * @param cupo: cupo del juego a consultar
         * @param monto: monto a consultar
         */
        public int ConsultarDatosItem(int idItem, ref int cupo, ref float monto)
        {
            try
            {
                string query = "SELECT CUPO, MONTO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                int result1 = 0;
                float result2 = 0;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt16(0);
                    result2 = reader.GetFloat(1);
                        
                }
                if (result1 != 0 && result2 != 0)
                {
                    cupo = result1;
                    monto = result2;
                    return 1;
                }
                else
                {
                    throw new ConsultarException("El item " + idItem + " no se encuentra registrado en el sistema");
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /**
         * Método: CrearSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la creacion de un sorteo y lo ingresa a base de datos
         * @param s: Contiene los datos necesarios para poder crear el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se inserto exitosamente el sorteo o si no
         * se pudo insertar
         */
        public int CrearSorteo(Sorteo s)
        {
            try
            {

                if (s.ID_JUEGO == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                if (s.ID_ITEM == 0)
                {
                    throw new ParameterException("ID_ITEM");
                }
                else if (s.HORA.Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                else if (s.ID_DIA == 0)
                {
                    throw new ParameterException("ID_DIA");
                }

                ConsultarJuego(s.ID_JUEGO);
                ConsultarItem(s.ID_ITEM, s.ID_JUEGO);
                ConsultarDia(s.ID_DIA);
                ConsultarHora(s.ID_JUEGO, s.HORA, s.ID_DIA);

                int result, cupo = 0;
                float monto = 0;
                string query;
                ConsultarDatosItem(s.ID_ITEM, ref cupo, ref monto);

                MySqlCommand command;
                connection.Open();

                query = "INSERT INTO TB_SORTEO (ID_SORTEO, ID_JUEGO, HORA, ESTATUS) VALUES (NULL, " + s.ID_JUEGO + ", '" + s.HORA + "', " + 1 + "); SELECT LAST_INSERT_ID()";
                command = new MySqlCommand(query, connection);

                int ID_SORTEO = Convert.ToInt32(command.ExecuteScalar());

                query = "INSERT INTO TB_SORTEO_ITEM (ID_SORTEOITEM, ID_ITEM, ID_SORTEO, CUPO, MONTO, ESTATUS) VALUES (NULL, " + s.ID_ITEM + ", " + ID_SORTEO + ", " + cupo + ", " + monto + ", " + 1 + ")";
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                query = "INSERT INTO TB_DIA_SORTEO (ID_DIASORTEO, ID_DIA, ID_SORTEO, ESTATUS) VALUES (NULL, " + s.ID_DIA + ", " + ID_SORTEO + ", " + 1 + ")";
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                if (result == 1)
                {
                    return 0;
                    //return new Respuesta("Sorteo Creado Exitosamente");
                }
                else
                {
                    throw new DBException();
                }

            }
            catch (Exception e)
            {
                Console.Write(e);
                return 1;
                //return new Respuesta("Error: "+ e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        /**
         * Método: EliminarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la eliminacion de un sorteo y cambia su status de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder eliminar el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se elimino exitosamente el sorteo o si no
         * se pudo eliminar
         */
        public Respuesta EliminarSorteo(Sorteo s)
        {
            try
            {

                if (s.ID_SORTEO == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }

                ConsultarSorteo(s.ID_SORTEO);

                ConsultarApuestas(s.ID_SORTEO);

                int result;
                MySqlCommand command;
                connection.Open();

                string query = "UPDATE TB_SORTEO SET ESTATUS=0 WHERE ID_SORTEO=" + s.ID_SORTEO;

                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

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

        /**
         * Método: ModificarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la modificacion de un sorteo y cambia sus datos de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder modificar el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se modifico exitosamente el sorteo o si no
         * se pudo modificar
         */
        public Respuesta ModificarSorteo(Sorteo s)
        {
            try
            {
                if (s.ID_SORTEO == 0)
                {
                    throw new ParameterException("ID_SORTEO");
                }
                if (s.ID_JUEGO == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }
                if (s.ID_ITEM == 0)
                {
                    throw new ParameterException("ID_ITEM");
                }
                else if (s.HORA.Length == 0)
                {
                    throw new ParameterException("HORA");
                }
                else if (s.ID_DIA == 0)
                {
                    throw new ParameterException("ID_DIA");
                }

                ConsultarJuego(s.ID_JUEGO);
                ConsultarItem(s.ID_ITEM, s.ID_JUEGO);
                ConsultarDia(s.ID_DIA);
                ConsultarSJ(s.ID_SORTEO, s.ID_JUEGO);
                ConsultarHora(s.ID_JUEGO, s.HORA, s.ID_DIA);

                int result, cupo = 0;
                float monto = 0;
                string query;
                ConsultarDatosItem(s.ID_ITEM, ref cupo, ref monto);

                MySqlCommand command;
                connection.Open();

                query = "UPDATE TB_SORTEO SET ID_JUEGO=" + s.ID_JUEGO + ", HORA='" + s.HORA + "' WHERE ID_SORTEO=" + s.ID_SORTEO;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                query = "UPDATE TB_SORTEO_ITEM SET ID_ITEM=" + s.ID_ITEM + ", CUPO=" + cupo + ", MONTO=" + monto + " WHERE ID_SORTEO=" + s.ID_SORTEO;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                query = "UPDATE TB_DIA_SORTEO SET ID_DIA=" + s.ID_DIA + " WHERE ID_SORTEO=" + s.ID_SORTEO;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

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

        /**
         * Método: ConsultarSorteoxJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de todos los sorteos de un juego en la 
         * base de datos
         * @param s: Contiene los datos necesarios para poder buscar los sorteos
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica los datos de los sorteos o si hubo un error 
         * o no se encontro el juego
         */
        public Respuesta ConsultarSorteoxJuego(Sorteo s)
        {
            try
            {

                if (s.ID_JUEGO.ToString().Length == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                ConsultarJuego(s.ID_JUEGO);

                string query = "SELECT A.ID_SORTEO, A.HORA, D.NOMBRE, A.ESTATUS, E.ID_ITEM, F.NOMBRE, F.VALOR, E.CUPO, E.MONTO FROM TB_SORTEO A JOIN TB_JUEGO B ON A.ID_JUEGO=B.ID_JUEGO JOIN TB_DIA_SORTEO C ON A.ID_SORTEO=C.ID_SORTEO JOIN TB_DIA D ON C.ID_DIA=D.ID_DIA JOIN TB_SORTEO_ITEM E ON A.ID_SORTEO=E.ID_SORTEO JOIN TB_ITEM F ON E.ID_ITEM=F.ID_ITEM WHERE B.ID_JUEGO=" + s.ID_JUEGO;
                Respuesta result = new Respuesta(string.Empty);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Mensaje = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3) + "-" + reader.GetString(4) + "-" + reader.GetString(5) + "-" + reader.GetString(6) + "-" + reader.GetString(7) + "-" + reader.GetString(8);
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
    }
}
