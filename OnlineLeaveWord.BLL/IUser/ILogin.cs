using System;
using System.Collections.Generic;
using System.Text;
using OnlineLeaveWord.Model;

namespace OnlineLeaveWord.BLL.ILogin
{
    public interface ILogin
    {
        bool IsLogin(UserInfo_M userInfo);
    }
}
