using MySql.Data.MySqlClient;
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
         * @return: retorna 1 si se consigue en la tabla la fila que contenga el estatus (Activo) del juego
         * @return: retorna 0 si se consigue en la tabla la fila que contenga el estatus (Inactivo) del juego
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
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El juego " + idJuego + " no se encuentra registrado en el sistema");
                }
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
          * @return: retorna 1 si se logra obtener el item
          * @return: retorna 0 si ocurre un error
          */
        public int ConsultarItem(int idItem, int idJuego)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query = "SELECT ESTATUS, ID_JUEGO FROM TB_ITEM WHERE ID_ITEM=" + idItem;
                int result1 = 0, result2 = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetInt32(1);
                }
                if (result1 == 1 && result2 == idJuego) return 1;
                else
                {
                    throw new ConsultarException("El item " + idItem + " no se encuentra registrado en el sistema o no pertenece al juego " + idJuego);
                }
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
          * @return: retorna 1 si se logra obtener el sorteo
          * @return: retorna 0 si ocurre un error o no se encontro
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
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El sorteo " + idSorteo + " no se encuentra registrado en el sistema");
                }

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
          * @return: retorna 1 si se logra obtener el dia
          * @return: retorna 0 si ocurre un error o no se encontro
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
                if (result == 1) return 1;
                else
                {
                    throw new ConsultarException("El dia " + idDia + " no se encuentra registrado en el sistema");
                }

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
                int result1 = 0, result2 = 0;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result1 = reader.GetInt32(0);
                    result2 = reader.GetInt32(1);
                }
                if (result1 == 1 && result2 == idJuego) return 1;
                else
                {
                    throw new ConsultarException("El sorteo que intenta actualizar no se encuentra registrado o no pertenece al juego " + idJuego);
                }

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
          * Esta funcion permite consultar el dia de un sorteo y verificar si
          * es igual al dia que se le pasa como parametro
          * @param idSorteo: Identificador del sorteo que se quiere consultar
          * @param dia: Es el dia que se quiere revisar
          * @return: retorna 0 los dias del sorteo y la variable "dia" son iguales
          * @return: retorna 1 si ocurre un error o no son iguales
          */
        public int ConsultarDiaHora(int idSorteo, int idDia, string hora, int idJuego)
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
                if (result == idDia)
                    throw new ConsultarException("El sorteo de hora " + hora + " para el día " + idDia + " del juego " + idJuego + " ya se encuentra registrado en el sistema");
                else return 1;

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
          * @param dia: es el dia del sorteo que se quiere revisar
          * @return: retorna 0 ya existe un sorteo en esa hora 
          * @return: retorna 1 si ocurre un error o no existe un sorteo a esa hora
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
         * @return: 1 si consigue la fila en la base de datos el id
         * @retrun: 0 si no consigue la fila o existe un error
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
                if (result == 1)
                {
                    throw new ConsultarException("El sorteo que intenta eliminar tiene apuestas activas asociadas");
                }
                else
                {
                    return 0;
                }
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
                int result1 = 0;
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
                    return 1;
                }
                else
                {
                    throw new ConsultarException("El item " + idItem + " no se encuentra registrado en el sistema");
                }
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
         * Método: CrearSorteo
         * ---------------------------------------------------------------------------
         * Este metodo realiza la creacion de un sorteo y lo ingresa a base de datos
         * @param s: Contiene los datos necesarios para poder crear el sorteo
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se inserto exitosamente el sorteo o si no
         * se pudo insertar
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
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se elimino exitosamente el sorteo o si no
         * se pudo eliminar
         */

        public int EliminarSorteo(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_SORTEO SET ESTATUS=0 WHERE ID_SORTEO=" + idSorteo;
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

        public int EliminarSorteoItem(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_SORTEO_ITEM SET ESTATUS=0 WHERE ID_SORTEO=" + idSorteo;
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

        public int EliminarSorteoDia(int idSorteo)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                int result = 0;
                string query;

                query = "UPDATE TB_DIA_SORTEO SET ESTATUS=0 WHERE ID_SORTEO=" + idSorteo;
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
         * @return retorna un tipo de dato llamado Respuesta el cual contiene 
         * un string el cual indica si se modifico exitosamente el sorteo o si no
         * se pudo modificar
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

        public int ModificarSorteoItem(int idSorteo, int idItem, int cupo, float monto)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;
                int result = 0;

                query = "UPDATE TB_SORTEO_ITEM SET ID_ITEM=" + idItem + ", CUPO=" + cupo + ", MONTO=" + monto + " WHERE ID_SORTEO=" + idSorteo;
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

        public int ModificarSorteoDia(int idSorteo, int idDia)
        {
            try
            {
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                string query;
                int result = 0;

                query = "UPDATE TB_DIA_SORTEO SET ID_DIA=" + idDia + " WHERE ID_SORTEO=" + idSorteo;
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
                log.Debug("Método: " + MethodBase.GetCurrentMethod().Name);

                Conectar();

                if (s.juego.id_juego == 0)
                {
                    throw new ParameterException("ID_JUEGO");
                }

                string query = "SELECT A.ID_SORTEO, A.ID_JUEGO, A.HORA, C.ID_DIASORTEO, C.ID_DIA, D.NOMBRE, E.ID_SORTEOITEM, E.ID_ITEM, E.CUPO, E.MONTO, A.ESTATUS FROM TB_SORTEO A JOIN TB_JUEGO B ON A.ID_JUEGO=B.ID_JUEGO JOIN TB_DIA_SORTEO C ON A.ID_SORTEO=C.ID_SORTEO JOIN TB_DIA D ON C.ID_DIA=D.ID_DIA JOIN TB_SORTEO_ITEM E ON A.ID_SORTEO=E.ID_SORTEO WHERE B.ID_JUEGO=" + s.juego.id_juego;
                string result1 = string.Empty, result2;
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result2 = string.Empty;
                        result2 = reader.GetString(0) + "-" + reader.GetString(1) + "-" + reader.GetString(2) + "-" + reader.GetString(3) + "-" + reader.GetString(4) + "-" + reader.GetString(5) + "-" + reader.GetString(6) + "-" + reader.GetString(7) + reader.GetString(8) + "-" + reader.GetString(9) + "-" + reader.GetString(10);
                        result1 = result1 + Environment.NewLine + result2;
                    }
                    Respuesta resp = new Respuesta(result1);
                    return resp;
                }
                else
                {
                    throw new ConsultarException("No se encontró");
                }

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
