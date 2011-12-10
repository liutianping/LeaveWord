using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.BLL.IUser
{
    public class Regesiter : IRegesiter
    {
        #region IRegesiter ≥…‘±

        public bool IsRegesiter(OnlineLeaveWord.Model.UserInfo_M u)
        {
            OnlineLeaveWord.DAL.UserImp.UserOperationationImp uo = new OnlineLeaveWord.DAL.UserImp.UserOperationationImp();
            if (1 == uo.AddUser(u))
                return true;
            else
                return false;
        }

        #endregion
    }
}
