using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.IReply
{
    public interface IReply
    {
        int GetReplyCount(UserInfo_M u);
        IList<Reply_M> GetReply(LeaveWord_M lw);
        int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw);
        int InsertReply(Reply_M r);
    }
}
