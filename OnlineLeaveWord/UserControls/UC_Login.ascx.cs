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

public partial class UserControls_UC_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserInfo_M userInfo = new UserInfo_M();
        OnlineLeaveWord.BLL.Login login = new OnlineLeaveWord.BLL.Login();
        userInfo.Password = txtPassword.Text.Trim();
        userInfo.UID = txtUserName.Text.Trim();
        if (login.IsLogin(userInfo))
        {
            Session["username"] = userInfo.UID;
            Response.Write("<script>alert('登录成功！！！！！！！');location.href='Default.aspx'</script>");
        }
        else
            Response.Write("<script>alert('登录失败！！！！！！！')</script>");

    }
}
