using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.DAL.LeaveWordImp
{
    public class LeaveWordImpl : ILeaveWord.ILeaveWord
    {
        SqlCommand cmd = null;
        SqlConnection cn = null;
        Dictionary<string, object> parematers = null;
        private SqlCommand CreateCommand(SqlConnection cn, string strSql, Dictionary<string, object> paremater1)
        {
            SqlCommand result = new SqlCommand(strSql, cn);
            if (null != paremater1)
            {
                foreach (string key in paremater1.Keys)
                {
                    if (paremater1.ContainsKey(key))
                        result.Parameters.Add(new SqlParameter(key, paremater1[key]));
                }
            }
            return result;
        }
        #region ILeaveWord 成员

        public int DeleteMyWords(OnlineLeaveWord.Model.LeaveWord_M[] ms)
        {
            int resut = 0;
            for (int i = 0; i < ms.Length; i++)
            {
                string strSql = "DELETE FROM tb_LeaveWord where ID=@id";
                parematers = new Dictionary<string, object>();
                parematers.Add("@id", ms[i].Id);
                CreateCommand(cn, strSql,parematers);
                resut = cmd.ExecuteNonQuery();
                cn.Close();
            }
            return resut;
        }

        public IList<OnlineLeaveWord.Model.LeaveWord_M> GetMyLeaveWord(OnlineLeaveWord.Model.UserInfo_M u)
        {
            string strSql = "SELECT * FROM tb_LeaveWord";
            if (!string.IsNullOrEmpty(u.UID))
                strSql += " WHERE Uid=@uid";
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", u.Id);
            cn = ConnectionService.GetInstance().GetConnection();
            
            IList<LeaveWord_M> result= GetLeaveList(CreateCommand(cn, strSql,parematers).ExecuteReader());
            CloseConnection();
            return result;
        }

        public int InsertMyWord(OnlineLeaveWord.Model.LeaveWord_M m)
        {
            cn = ConnectionService.GetInstance().GetConnection();
            string strSql = "INSERT INTO tb_LeaveWord(uid,subject,content,ip,o_uid) VALUES(@uid,@subject,@content,@ip,@o_id)";
            int result = 0;
            parematers = new Dictionary<string, object>();
            parematers.Add("@uid", m.UId);
            parematers.Add("@subject", m.Subject);
            parematers.Add("@content", m.Content);
            parematers.Add("@ip", m.Ip);
            parematers.Add("@o_id", m.O_Uid);
            cmd =CreateCommand(cn, strSql,parematers);
            result =  cmd.ExecuteNonQuery();
            cn.Close();
            return result;
        }

        public int GetWordCount(OnlineLeaveWord.Model.UserInfo_M u)
        {
            string strSql = "SELECT COUNT(ID) FROM LeaveWord";
            if (u.Id != 0)
            {
                strSql += " WHERE Uid=@uid";
                parematers = new Dictionary<string, object>();
                parematers.Add("uid", u.Id);
            }
            
            CreateCommand(cn, strSql,parematers);
            cn.Close();
            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        #endregion

        private IList<OnlineLeaveWord.Model.LeaveWord_M> GetLeaveList(SqlDataReader dr)
        {
            IList<OnlineLeaveWord.Model.LeaveWord_M> result = new List<OnlineLeaveWord.Model.LeaveWord_M>();
            OnlineLeaveWord.Model.LeaveWord_M lw = null;
            while (dr.Read())
            {
                lw = new OnlineLeaveWord.Model.LeaveWord_M();
                lw.Id = int.Parse(dr["id"].ToString());
                //lw.Ip = dr["ip"].ToString();
                lw.Subject = dr["subject"].ToString();
                lw.UId = dr["Uid"].ToString();
                lw.Content = dr["content"].ToString();
                lw.Date = DateTime.Parse(dr["datetime"].ToString());
                //lw.PageViews = dr["pageViews"].ToString();
                result.Add(lw);
            }
            try
            {
                dr.Close();
                cn.Close();
            }
            catch (Exception)
            {
                //TODO 记录日志，关闭连接失败
            }
            return result;
        }

        #region ILeaveWord 成员


        public OnlineLeaveWord.Model.LeaveWord_M GetDetail(int leaveWordId)
        {
            IList < LeaveWord_M > result=null;
            cn=ConnectionService.GetInstance().GetConnection();
            string strSql = "SELECT * FROM tb_blog WHERE ID=@id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@id", leaveWordId);
            cmd = CreateCommand(cn, strSql, parematers);
            result= GetLeaveList(cmd.ExecuteReader());
            CloseConnection();
            if (0 != result.Count)
                return result[0];
            return null;
        }

        #endregion

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
