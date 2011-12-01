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

        public IList<OnlineLeaveWord.Model.Reply_M> GetReplyByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            string strSql = "Select * from tb_reply where leaveWordid=@id";
            parematers = new Dictionary<string, object>();
            
            parematers.Add("@id",lw.Id);
            CreateCommand(connection,strSql);
            return GetReplyList(cmd.ExecuteReader());
        }

        public int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            if (0 != lw.Id)
            {
                string strSql = "SELECT COUNT(ID) FROM TB_Reply where LeaveWordID=@id";
                parematers = new Dictionary<string, object>();
                parematers.Add("@id",lw.Id);
                CreateCommand(ConnectionService.GetInstance().GetConnection(), strSql);
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            return 0;
        }

        #endregion
        private void CreateCommand(SqlConnection cn, string strSql)
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
                lw.LeaveWordId =dr["LeaveWordID"].ToString();
                lw.Content = dr["content"].ToString();
                if(int.TryParse(dr["replyID"].ToString(),out temp))
                    lw.ReplyId = temp;//这是反向外键，也就是TB_REPLY的ID
                lw.Date = DateTime.Parse(dr["DateTime"].ToString());
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

            int result = 0;
            string strSql="";
            connection=ConnectionService.GetInstance().GetConnection();
            parematers = new Dictionary<string, object>();
            if (reply.ReplyId != null)
            {
                strSql = "Insert into tb_reply (uname,content,datetime,leavewordid,ip,replyid) values(@username,@content,@datetime,@leavewordid,@ip,@replyid)";
                parematers.Add("@replyid",reply.ReplyId);
            }
                
            else
            {
                strSql = "Insert into tb_reply (uname,content,datetime,leavewordid,ip) values(@username,@content,@datetime,@leavewordid,@ip)";
            }
            parematers = new Dictionary<string, object>();
            parematers.Add("@username",reply.UserName);
            parematers.Add("@content",reply.Content);
            parematers.Add("@datetime",System.DateTime.Now.ToString());
            parematers.Add("@leavewordid",reply.LeaveWordId);
            parematers.Add("@ip",reply.Ip);
            

            CreateCommand(connection, strSql);
            return cmd.ExecuteNonQuery();
            
        }

        #endregion
    }
}
