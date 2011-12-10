using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.DAL.UserImp
{
    public class UserOperationationImp : OnlineLeaveWord.DAL.IUser.IUserOperation
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        Dictionary<string, object> parematers = null;
        #region IUserOperation 成员

        public int CheckLogin(UserInfo_M userInfo)
        {
            string sql = "SELECT COUNT(*) FROM tb_User WHERE Uid=@uid AND Pwd = @password";
            cmd = new SqlCommand(sql, cn);
            parematers=new Dictionary<string,object>();
            parematers.Add("@uid",userInfo.UID);
            parematers.Add("@password", userInfo.Password);
            CreateCommand(cn, sql);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            cn.Close();
            return count;
        }

        public int AddUser(UserInfo_M userInfo)
        {
            string sql = "INSERT INTO tb_User VALUES(@uid,@pwd,@sex,@website,@email,@qq,@ip,@popedom)";
           
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", userInfo.UID);
            parematers.Add("@pwd", userInfo.Password);
            parematers.Add("@sex",userInfo.Sex);
            parematers.Add("@website",userInfo.WebSite);
            parematers.Add("@email",userInfo.Email);
            parematers.Add("@qq",userInfo.Qq);
            parematers.Add("@ip",userInfo.Ip);
            parematers.Add("@popedom",userInfo.Popedom);
            CreateCommand(cn, sql);
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery();
                if(null!=cn && cn.State==System.Data.ConnectionState.Open)
                cn.Close();
            }
            catch (Exception)
            {
                //TODO 用户插入失败
                throw;
            }
            
            return count;
        }
 
        #endregion
        private void CreateCommand(SqlConnection cn2, string strSql)
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
        }
        private void CloseConnection()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    cn.Close();
                }
                catch (Exception)
                {
                    //TODO 记录日志  关闭连接失败。位置：BlogCategoryinterfaceImpl 79行                    Cate
                }
            }
        }
       
    }
}
