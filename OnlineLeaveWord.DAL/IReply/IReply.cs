using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.DAL.IReply
{
    public interface IReply
    {
        IList<OnlineLeaveWord.Model.Reply_M> GetReplyByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw);
        int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw);
        int InsertReply(OnlineLeaveWord.Model.Reply_M reply);
    }
}
