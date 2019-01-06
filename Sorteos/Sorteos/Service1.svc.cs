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
            /*string cx = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
             *ESTO VA EN EL WEB.CONFIG:
             *<connectionStrings>
             *  <add name="cn" connectionString="Server=127.0.0.1;Port=3306;Database=proyecto;Uid=root;Pwd=jalejandro541" providerName="MySql.Data.MySqlClient.MySqlConnection"/>
             *</connectionStrings>*/
            builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1";
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "proyecto";
            connection = new MySqlConnection(builder.ToString());
        }
        /**
         * Método: Conectar
         * -----------------------------------------------
         * @param query: query de ejecuion sobre la base de datos
         * @return retorna la validez de la ejecución del query en la base de datos
         */
            public int Conectar(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteNonQuery();
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


        
     
    }
}
