using MySql.Data.MySqlClient;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Excepciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLotoUCAB.Servicio.AccesoDatos.Dao
{
    public class DaoSorteos
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MySqlConnection connection { get; set; }

        public string cx { get; set; }

        public MySqlCommand command { get; set; }

        public MySqlDataReader reader { get; set; }

        /**
         * Método: Conectar
         * -------------------------------------------------------------------------------------------------
         * Realiza la conexión a la base de datos
         */
        public void Conectar()
        {
            try
            {
                connection = new MySqlConnection(cx);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /**
         * Método: Desconectar
         * -------------------------------------------------------------------------------------------------
         * Realiza la desconexión a la base de datos
         */
        public void Desconectar()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public DaoSorteos()
        {
            cx = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }

        /**
         * Método: ConsultarJuego
         * -------------------------------------------------------------------------------------------------
         * Esta funcion permite consultar el estatus de un juego (Activo o Inactivo)
         * @param idJuego: entero que representa el id del juego en la base de datos
         * @return: retorna el estatus del juego
         */
        public int ConsultarJuego(int idJuego)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query = "SELECT ESTATUS FROM TB_JUEGO WHERE ID_JUEGO=" + idJuego;               
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Metodo: ConsultarItem
          * -------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un item
          * @param idItem: Identificador del item que se quiere consultar
          * @param idJuego: Identificador del juego que se quiere consultar
          * @return: retorna 1 si se logra obtener el item y si pertenece al juego
          * @return: retorna 0 si ocurre un error
          */
        public int ConsultarItem(int idItem, int idJuego)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ESTATUS, ID_JUEGO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                int result1 = 0, result2 = 0, result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetInt32(1);
                }
                if (result1 == 1 && result2 == idJuego) result = 1;

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Metodo: ConsultarSorteo
          * -----------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un sorteo
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @return: retorna el estatus del sorteo
          */
        public int ConsultarSorteo(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ESTATUS FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo;
                int result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Metodo: ConsultarDia
          * -----------------------------------------------------------------
          * Esta funcion permite consultar el estatus de un dia
          * @param idDia: Identificador del dia que se quiere consultar
          * @return: retorna 1 el estatus del día
          */
        public int ConsultarDia(int idDia)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ESTATUS FROM TB_DIA WHERE ID_DIA=" + idDia;
                int result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
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
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ESTATUS, ID_JUEGO FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo;
                int result1 = 0, result2 = 0, result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetInt32(1);
                }
                if (result1 == 1 && result2 == idJuego) result = 1;

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Metodo: ConsultarDiaHora
          * ------------------------------------------------------------------
          * Esta funcion permite consultar el dia de un sorteo
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @return: retorna el día del sorteo
          */
        public int ConsultarDiaHora(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ID_DIA FROM TB_DIA_SORTEO WHERE ID_SORTEO=" + idSorteo;
                int result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Metodo: ConsultarHora
          * -----------------------------------------------------------------------
          * Esta funcion permite consultar si hay un sorteo del juego a la hora que es 
          * pasada por parametro 
          * @param idJuego: Identificador del juego al que 
          * @param hora: Es la hora que se quiere revisar
          * @return: retorna una lista con los sorteos de esa misma hora y del mismo juego
          */
        public List<int> ConsultarHora(int idJuego, string hora)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ID_SORTEO, HORA, ESTATUS FROM TB_SORTEO WHERE ID_JUEGO=" + idJuego;
                string result2 = string.Empty;
                int result1 = 0, result3 = 0;
                List<int> listaSorteos = new List<int>();
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetString(1);
                    result3 = reader.GetInt32(2);

                    if (string.Equals(result2, hora) && result3 == 1)
                    {
                        listaSorteos.Add(result1);
                    }
                }

                return listaSorteos;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Metodo: ConsultarApuestas
         * ------------------------------------------------------------------------------
         * Esta función permite consultar el estatus de una apuesta realizada según el
         * sorteo que es pasado por parametro
         * @param idSorteo: Identificador del sorteo a consultar
         * @return: el estatus de la jugada
         */
        public int ConsultarApuestas(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT A.ESTATUS FROM TB_JUGADA A JOIN TB_DIA_SORTEO B ON A.ID_DIASORTEO=B.ID_DIASORTEO WHERE B.ID_SORTEO=" + idSorteo;
                int result = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
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
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT CUPO, MONTO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                int result1 = 0, result = 0;
                float result2 = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetFloat(1);

                }
                if (result1 != 0 && result2 != 0)
                {
                    cupo = result1;
                    monto = result2;
                    result = 1;
                }

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }
        
        /**
          * Método: InsertarSorteo
          * ---------------------------------------------------------------------------
          * Este metodo inserta un sorteo en la tabla sorteo
          * @param s: Contiene los datos necesarios para poder insertar el sorteo
          * @return retorna el identificador del sorteo insertado
          */
        public int InsertarSorteo (int idJuego, string hora)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;

                query = "INSERT INTO TB_SORTEO (ID_SORTEO, ID_JUEGO, HORA, ESTATUS) VALUES (NULL, " + idJuego + ", '" + hora + "', " + 1 + "); SELECT LAST_INSERT_ID()";
                command = new MySqlCommand(query, connection);

                int idSorteo = Convert.ToInt32(command.ExecuteScalar());

                return idSorteo;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Método: InsertarSorteoItem
          * ---------------------------------------------------------------------------
          * Este metodo inserta un item de un sorteo en la tabla sorteoitem
          * @param s: Contiene los datos necesarios para poder insertar el sorteo
          * @return retorna el número de filas afectadas
          */
        public int InsertarSorteoItem(int idItem, int idSorteo, int cupo, float monto)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;
                int result = 0;

                query = "INSERT INTO TB_SORTEO_ITEM (ID_SORTEOITEM, ID_ITEM, ID_SORTEO, CUPO, MONTO, ESTATUS) VALUES (NULL, " + idItem + ", " + idSorteo + ", " + cupo + ", " + monto + ", " + 1 + ")";
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
          * Método: InsertarSorteoDia
          * ---------------------------------------------------------------------------
          * Este metodo inserta un dia de un sorteo en la tabla sorteodia
          * @param s: Contiene los datos necesarios para poder insertar el sorteo
          * @return retorna número de filas afectadas
          */
        public int InsertarSorteoDia(int idDia, int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;
                int result = 0;

                query = "INSERT INTO TB_DIA_SORTEO (ID_DIASORTEO, ID_DIA, ID_SORTEO, ESTATUS) VALUES (NULL, " + idDia + ", " + idSorteo + ", " + 1 + ")";
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Método: EliminarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la eliminacion de un sorteo y cambia su status de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder eliminar el sorteo
         * @return retorna el número de filas afectadas
         */
        public int EliminarSorteo(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_SORTEO SET ESTATUS=3 WHERE ID_SORTEO=" + idSorteo;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Método: EliminarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la eliminacion de los item de un sorteo y cambia su status de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder eliminar los item del sorteo
         * @return retorna el número de filas afectadas
         */
        public int EliminarSorteoItem(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_SORTEO_ITEM SET ESTATUS=3 WHERE ID_SORTEO=" + idSorteo;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }
        
        /**
         * Método: EliminarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la eliminacion de los dias de un sorteo y cambia su status de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder eliminar los dias del sorteo
         * @return retorna el número de filas afectadas
         */
        public int EliminarSorteoDia(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_DIA_SORTEO SET ESTATUS=3 WHERE ID_SORTEO=" + idSorteo;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Método: ModificarSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la modificacion de un sorteo y cambia sus datos de la
         * base de datos
         * @param s: Contiene los datos necesarios para poder modificar el sorteo
         * @return retorna el número de filas afectadas
         */
        public int ModificarSorteo(int idSorteo, int idJuego, string hora)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;
                int result = 0;

                query = "UPDATE TB_SORTEO SET ID_JUEGO=" + idJuego + ", HORA='" + hora + "' WHERE ID_SORTEO=" + idSorteo;
                command = new MySqlCommand(query, connection);
                result = command.ExecuteNonQuery();

                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Método: ConsultarSorteosdeJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de todos los sorteos de un juego en la 
         * base de datos
         * @param s: Contiene los datos necesarios para poder buscar los sorteos
         * @return retorna una lista con los id de los sorteos
         */
        public List<int> ConsultarSorteosdeJuego(int idJuego)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ID_SORTEO FROM TB_SORTEO WHERE ID_JUEGO=" + idJuego;
                int result1 = 0;
                List<int> listaSorteos = new List<int>();
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);

                    listaSorteos.Add(result1);
                }

                return listaSorteos;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }
        }

        /**
         * Método: ConsultarSorteoxJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de un sorteo
         * @param s: Contiene los datos necesarios para poder buscar el sorteo
         * @return retorna un string con todos los datos del sorteo
         */
        public string ConsultarSorteoxJuego(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ID_SORTEO, ID_JUEGO, HORA, ESTATUS FROM TB_SORTEO WHERE ID_SORTEO=" + idSorteo;
                string result = string.Empty;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3);
                    }
                }

                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }

        }

        /**
         * Método: ConsultarSorteoItemxJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de los item de un sorteo
         * @param s: Contiene los datos necesarios para poder buscar los item del sorteo
         * @return retorna un string con todos los datos de los item del sorteo
         */
        public string ConsultarSorteoItemxJuego(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ID_SORTEOITEM, ID_ITEM, CUPO, MONTO, ESTATUS FROM TB_SORTEO_ITEM A WHERE ID_SORTEO=" + idSorteo;
                string result1 = string.Empty, result2;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result2 = string.Empty;
                        result2 = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3) + "-" + reader.GetString(4);
                        result1 = string.Concat(result1, result2, "|");
                    }
                }

                return result1;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }

        }

        /**
         * Método: ConsultarSorteoDiaxJuego
         * ---------------------------------------------------------------------------
         * Este metodo realiza la busqueda de los item de un sorteo
         * @param s: Contiene los datos necesarios para poder buscar los días del sorteo
         * @return retorna un string con todos los datos de los días del sorteo
         */
        public string ConsultarSorteoDiaxJuego(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT A.ID_DIASORTEO, A.ID_DIA, B.NOMBRE, A.ESTATUS FROM TB_DIA_SORTEO A JOIN TB_DIA B ON A.ID_DIA=B.ID_DIA WHERE A.ID_SORTEO=" + idSorteo;
                string result1 = string.Empty, result2;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result2 = string.Empty;
                        result2 = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3);
                        result1 = string.Concat(result1, result2, "|");
                    }
                }

                return result1;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
