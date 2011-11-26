using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.BLL.ReplyImpl
{
    public class ReplyImp : OnlineLeaveWord.BLL.IReply.IReply
    {
        OnlineLeaveWord.DAL.IReply.IReply reply = null;
        #region IReply 成员

        public int GetReplyCount(OnlineLeaveWord.Model.UserInfo_M u)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<OnlineLeaveWord.Model.Reply_M> GetReply(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            reply = new OnlineLeaveWord.DAL.ReplyImp.ReplyImp();
            return reply.GetReplyByLeaveWordId(lw);
        }

        #endregion

        #region IReply 成员


        public int InsertReply(OnlineLeaveWord.Model.Reply_M r)
        {
            reply = new OnlineLeaveWord.DAL.ReplyImp.ReplyImp();
            return reply.InsertReply(r);
        }

        #endregion

        #region IReply 成员


        public int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            reply = new OnlineLeaveWord.DAL.ReplyImp.ReplyImp();
            return reply.GetReplyCountByLeaveWordId(lw);
        }

        #endregion
    }
}
