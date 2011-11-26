using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.DAL.ILeaveWord
{
    public interface ILeaveWord
    {
        int DeleteMyWords(LeaveWord_M[] ms);
        IList<LeaveWord_M> GetMyLeaveWord(UserInfo_M u);
        int InsertMyWord(LeaveWord_M m);
        int GetWordCount(UserInfo_M u);
        LeaveWord_M GetDetail(int leaveWordId);
    }
}
