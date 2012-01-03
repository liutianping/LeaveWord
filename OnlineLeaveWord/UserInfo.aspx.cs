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

public partial class UserInfo : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.IUser.UserOperation userOperation = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["username"] = "admin";
        try
        {
            userOperation = new OnlineLeaveWord.BLL.IUser.UserOperation();
            string userName = Session["username"].ToString();
            UserInfo_M userInfo = userOperation.GetUserInfo(userName);
            if (userInfo == null)
                throw new Exception();
            txtUserInfo.Text = userInfo.UID;
            txtQQ.Text = userInfo.Qq;
            txtEmail.Text = userInfo.Email;
            txtWebsite.Text = userInfo.WebSite;
            if (userInfo.Sex == "男")
            {
                RadioButtonList1.Items[0].Selected = true;
            }
            else
            {
                RadioButtonList1.Items[1].Selected = false;
            }
        }
        catch (Exception)
        {
            Page.RegisterClientScriptBlock("demo", "alert('您是微博登录用户，数据库不存储您的用户信息!')");
        }
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfo_M userInfo = userOperation.GetUserInfo(Session["username"].ToString());
        userInfo.UID = txtUserInfo.Text;
        userInfo.Email = txtEmail.Text;
        userInfo.Qq = txtQQ.Text;
        userInfo.Sex = RadioButtonList1.SelectedItem.Text;
        userInfo.WebSite = userInfo.WebSite;
        OnlineLeaveWord.BLL.IUser.UserOperation uo = new OnlineLeaveWord.BLL.IUser.UserOperation();
        uo.SaveUserInfo(userInfo);

    }
}
