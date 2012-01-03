using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnlineLeaveWord.Model;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (this.TextBox2.Text.Equals(this.TextBox3.Text))
        {
            string password = TextBox3.Text.Trim();
            OnlineLeaveWord.BLL.IUser.UserOperation uo = new OnlineLeaveWord.BLL.IUser.UserOperation();
            UserInfo_M userInfo = uo.GetUserInfo(Session["username"].ToString());
            userInfo.Password = password;
            if (1==uo.SaveUserInfo(userInfo))
            {
                Label1.Text = "密码修改成功";
            }
            else
            {
                Label1.Text = "密码修改失败";
            }
        }
    }
}
