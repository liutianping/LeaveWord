using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.IUser
{
    public class UserOperation
    {
        OnlineLeaveWord.DAL.IUser.IUserOperation user = null;
        public UserInfo_M GetUserInfo(string username)
        {
            user = new OnlineLeaveWord.DAL.UserImp.UserOperationationImp();
            return user.GetUserInfo(username);
        }

        public int SaveUserInfo(UserInfo_M userInfo)
        {
            user = new OnlineLeaveWord.DAL.UserImp.UserOperationationImp();
            return user.SaveUserInfo(userInfo);
        }
    }
}
