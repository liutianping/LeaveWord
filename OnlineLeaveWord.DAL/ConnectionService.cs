using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OnlineLeaveWord.DAL
{
    public class ConnectionService
    {
        static SqlConnection connection = null;
        static ConnectionService cs;
        private ConnectionService() 
        {
            string connectionString = OnlineLeaveWord.DAL.Properties.Settings.Default.Properties["connectionString"].DefaultValue.ToString();
            connection = new SqlConnection(connectionString);
        }

        public static ConnectionService GetInstance()
        {
            cs = new ConnectionService();
            return cs;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                OpenConnection();
            }
            catch (Exception)
            {
                return null;
            }
            
            return connection;
        }

        private static void OpenConnection()
        {
            if (null != connection)
            {
                if (ConnectionState.Closed == connection.State)
                {
                    connection.Open();
                }
            }
        }

        public static void CloseConnection()
        {
            if (ConnectionState.Open == connection.State)
            {
                connection.Close();
            }
        }
    }
}
