using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OnlineLeaveWord.DAL
{
    public class CommandService
    {
        private CommandService() { }
        static SqlCommand cmd = null;
        public static SqlCommand CreateCommand(SqlConnection cn, string strSql, Dictionary<string, object> parematers)
        {
            cn = ConnectionService.GetInstance().GetConnection();
            cmd = new SqlCommand(strSql, cn);
            if (null != parematers)
            {
                foreach (string key in parematers.Keys)
                {
                    if (parematers.ContainsKey(key))
                        cmd.Parameters.AddWithValue(key, parematers[key]);
                }
            }
            return cmd;
        }
    }
}
