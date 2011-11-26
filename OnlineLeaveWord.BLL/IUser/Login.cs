using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

using OnlineLeaveWord.DAL;
namespace OnlineLeaveWord.BLL
{
    public class Login : ILogin.ILogin
    {
        OnlineLeaveWord.DAL.UserImp.UserOperationationImp loginImpl = null;

        #region ILogin ≥…‘±
        public bool IsLogin(UserInfo_M userInfo)
        {
            loginImpl=new  OnlineLeaveWord.DAL.UserImp.UserOperationationImp();
            if (1 == loginImpl.CheckLogin(userInfo))
                return true;
            else
                return false;
        }

        #endregion
    }
}
