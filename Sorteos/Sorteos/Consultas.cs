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
    public class Consultas
    {
         /**
         * Método: ConsultarJuego
         * ----------------------------------------------------------
         * Esta funcion permite conocer el estatus de un juego (Activo o Inactivo)
         * 
         * @param idJuego: entero que representa el id del juego en la base de datos
         * @return retorna 1 si se consigue en la tabla la fila que contenga el estatus (Activo) del juego
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
        /**
          * Metodo: ConsultarItem
          * ------------------------------------------------------
          * Esta funcion es para consultar un item 
          * @param idItem: Identificador del item que se quiere consultar
          * @return: retorna 1 si se logra obtener el item
          * @return: retorna 0 si ocurre un error
          */
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

        /**
          * Metodo: ConsultarSorteo
          * ---------------------------------------------------------
          * Esta funcion es para consultar un sorteo  
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @return: retorna 1 si se logra obtener el sorteo
          * @return: retorna 0 si ocurre un error o no se encontro
          */
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

        /**
          * Metodo: ConsultarSJ
          * ------------------------------------------------------------------
          * Esta funcion es para consultar un sorteo de un determinado juego
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @param idJuego: Identificador del juego al que se le buscara un sorteo 
          * @return: retorna 1 si se logra obtener el sorteo
          * @return: retorna 0 si ocurre un error o no se encontro
          */
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

        /**
          * Metodo: ConsultarDia
          * ------------------------------------------------------------------
          * Esta funcion es para consultar el dia de un sorteo y verificar si
          * es igual al dia que se le pasa como parametro
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @param dia: Es el dia que se quiere revisar
          * @return: retorna 0 los dias del sorteo y la variable "dia" son iguales
          * @return: retorna 1 si ocurre un error o no son iguales
          */
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

        /**
          * Metodo: ConsultarHora
          * ------------------------------------------------------------------
          * Esta funcion es para consultar si hay un sorteo del juego 
          * a la hora que se le pasa por parametro 
          * @param idJuego: Identificador del juego al que 
          * @param hora: Es la hora que se quiere revisar
          * @param dia: es el dia del sorteo que se quiere revisar
          * @return: retorna 0 ya existe un sorteo en esa hora 
          * @return: retorna 1 si ocurre un error o no existe un sorteo a esa hora
          */
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
                        if ( !ConsultarSorteo(result1)) return 1;
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
        public int ConsultarApuestas(int idSorteo)
        {
            try
            {
                string query = "SELECT ESTATUS FROM TB_JUGADA WHERE ID_SORTEO=" + idSorteo;
                string result = string.Empty;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader;

                connection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = reader.GetString(0);
                    if (Convert.ToInt32(result) != 0)
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
        
    }
}