using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.ILeaveWord
{
    public interface ILeave
    {
        IList<OnlineLeaveWord.Model.LeaveWord_M> GetAllLeaveWord(UserInfo_M u);
        bool AddLeaveWord(LeaveWord_M lw);
        bool DeleteLeaveWord(LeaveWord_M[] lw);
        OnlineLeaveWord.Model.LeaveWord_M GetLeaveDetail(int leaveWordId);
    }
}
