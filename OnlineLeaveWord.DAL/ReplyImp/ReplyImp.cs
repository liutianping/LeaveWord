using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OnlineLeaveWord.DAL.ReplyImp
{
    public class ReplyImp : OnlineLeaveWord.DAL.IReply.IReply
    {
        SqlConnection connection = null;
        SqlCommand cmd = null;
        Dictionary<string, object> parematers = null;
        #region IReply 成员

        public IList<OnlineLeaveWord.Model.Reply_M> GetReplyByLeaveWordId(OnlineLeaveWord.Model.Blog lw)
        {
            string strSql = "Select * from tb_reply where blogid=@id";
            parematers = new Dictionary<string, object>();
            
            parematers.Add("@id",lw.Id);
            CreateCommand(connection,strSql);
            IList<OnlineLeaveWord.Model.Reply_M> result = GetReplyList(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        public int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            if (0 != lw.Id)
            {
                string strSql = "SELECT COUNT(ID) FROM TB_Reply where LeaveWordID=@id";
                parematers = new Dictionary<string, object>();
                parematers.Add("@id",lw.Id);
                CreateCommand(connection, strSql);
                int result = int.Parse(cmd.ExecuteScalar().ToString());
                CloseConnection();
                return result;
            }
            return 0;
        }

        #endregion
        private void CreateCommand(SqlConnection cn2, string strSql)
        {
            connection = ConnectionService.GetInstance().GetConnection();
            cmd = new SqlCommand(strSql, connection);
            if (null != parematers)
            {
                foreach (string key in parematers.Keys)
                {
                    if (parematers.ContainsKey(key))
                        cmd.Parameters.AddWithValue(key, parematers[key]);
                }
            }
        }

        private IList<OnlineLeaveWord.Model.Reply_M> GetReplyList(SqlDataReader dr)
        {
            IList<OnlineLeaveWord.Model.Reply_M> result = new List<OnlineLeaveWord.Model.Reply_M>();
            int temp;
            OnlineLeaveWord.Model.Reply_M lw = null;
            while (dr.Read())
            {
                lw = new OnlineLeaveWord.Model.Reply_M();
                lw.Id = int.Parse(dr["id"].ToString());
                lw.Ip = dr["ip"].ToString();
                lw.UserName = dr["uName"].ToString();
                lw.LeaveWordId =dr["blogid"].ToString();
                lw.Content = dr["content"].ToString();
                if(int.TryParse(dr["replyID"].ToString(),out temp))
                    lw.ReplyId = temp;//这是反向外键，也就是TB_REPLY的ID
                lw.Date = DateTime.Parse(dr["datetime"].ToString());
                result.Add(lw);
            }
            try
            {
                dr.Close();
                connection.Close();
            }
            catch (Exception)
            {
            }
            return result;
        }

        #region IReply 成员


        public int InsertReply(OnlineLeaveWord.Model.Reply_M reply)
        {
            if (reply.ReplyId == -1)
                reply.ReplyId = null;
            string strSql="";
            connection=ConnectionService.GetInstance().GetConnection();
            parematers = new Dictionary<string, object>();
            if (reply.ReplyId != null)
            {
                strSql = "Insert into tb_reply (uname,content,datetime,blogid,ip,replyid) values(@username,@content,@datetime,@leavewordid,@ip,@replyid)";
                parematers.Add("@replyid",reply.ReplyId);
            }
                
            else
            {
                strSql = "Insert into tb_reply (uname,content,datetime,blogid,ip) values(@username,@content,@datetime,@leavewordid,@ip)";
            }
            
            parematers.Add("@username",reply.UserName);
            parematers.Add("@content",reply.Content);
            parematers.Add("@datetime",System.DateTime.Now.ToString());
            parematers.Add("@leavewordid",reply.LeaveWordId);
            parematers.Add("@ip",reply.Ip);
            

            CreateCommand(connection, strSql);
            int resultInt = cmd.ExecuteNonQuery();
            CloseConnection();
            return resultInt;
            
        }

        #endregion

        #region IReply 成员

        /// <summary>
        /// 根据用户名来获取此用户的所有Reply
        /// </summary>
        /// <param name="u">要查询的用户</param>
        /// <returns></returns>
        public IList<OnlineLeaveWord.Model.Reply_M> GetReplyByUserName(OnlineLeaveWord.Model.UserInfo_M u)
        {
            string strSql = "Select * from tb_reply where uName=@username";
            parematers = new Dictionary<string, object>();
            parematers.Add("@username", u.UID);
            CreateCommand(connection, strSql);
            IList<OnlineLeaveWord.Model.Reply_M> result = new List<OnlineLeaveWord.Model.Reply_M>();
            result = GetReplyList(cmd.ExecuteReader());
            CloseConnection();
            return result;
        }

        #endregion

        #region IReply 成员


        public int DeleteReply(int replyId)
        {
            string strSql = "update tb_reply set content=@content,isDelete=1 where id=@id";
            parematers = new Dictionary<string, object>();
            parematers.Add("@content","此回复已经被删除！");
            parematers.Add("@id",replyId);
            CreateCommand(connection, strSql);
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        #endregion

        private void CloseConnection()
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    //TODO 记录日志  关闭连接失败。位置：BlogCategoryinterfaceImpl 79行                    Cate
                }
            }
        }
    }
}
