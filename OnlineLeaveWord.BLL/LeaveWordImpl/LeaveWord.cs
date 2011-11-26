using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.DAL.LeaveWordImp;


namespace OnlineLeaveWord.BLL.LeaveWordImpl
{
    public class LeaveWord : OnlineLeaveWord.BLL.ILeaveWord.ILeave
    {
        OnlineLeaveWord.DAL.LeaveWordImp.LeaveWordImpl lwDao = null;
        #region ILeave ≥…‘±

        public IList<OnlineLeaveWord.Model.LeaveWord_M> GetAllLeaveWord(OnlineLeaveWord.Model.UserInfo_M u)
        {
            lwDao = new OnlineLeaveWord.DAL.LeaveWordImp.LeaveWordImpl();
            return lwDao.GetMyLeaveWord(u);
        }

        public bool AddLeaveWord(OnlineLeaveWord.Model.LeaveWord_M lw)
        {
            lwDao = new OnlineLeaveWord.DAL.LeaveWordImp.LeaveWordImpl();
            if (1 == lwDao.InsertMyWord(lw))
                return true;
            return false;
        }

        public bool DeleteLeaveWord(OnlineLeaveWord.Model.LeaveWord_M[] lw)
        {
            lwDao=new OnlineLeaveWord.DAL.LeaveWordImp.LeaveWordImpl();
            return (1 == lwDao.DeleteMyWords(lw));
        }

        public OnlineLeaveWord.Model.LeaveWord_M GetLeaveDetail(int leaveWordId)
        {
            lwDao = new OnlineLeaveWord.DAL.LeaveWordImp.LeaveWordImpl();
            return lwDao.GetDetail(leaveWordId);
        }

        #endregion
    }
}
