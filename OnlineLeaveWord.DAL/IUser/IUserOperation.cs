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

    }
}
