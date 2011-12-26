using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.DAL.IReply
{
    public interface IReply
    {
        IList<OnlineLeaveWord.Model.Reply_M> GetReplyByLeaveWordId(OnlineLeaveWord.Model.Blog lw);
        int GetReplyCountByLeaveWordId(OnlineLeaveWord.Model.LeaveWord_M lw);
        int InsertReply(OnlineLeaveWord.Model.Reply_M reply);
        IList<OnlineLeaveWord.Model.Reply_M> GetReplyByUserName(OnlineLeaveWord.Model.UserInfo_M u);
        int DeleteReply(int replyId);
    }
}
