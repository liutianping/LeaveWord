using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.DAL.IUser
{
    public interface IUserOperation
    {
        int CheckLogin(UserInfo_M userInfo);
        int AddUser(UserInfo_M m);
        UserInfo_M GetUserInfo(string userName);
        int SaveUserInfo(UserInfo_M u);
    }
}
