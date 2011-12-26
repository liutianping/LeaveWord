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
using Word;
using System.Text;

public partial class UserRegesiter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetLoginState()
    {
        StringBuilder sb = new StringBuilder();
        //Session["username"] = "abc";
        if (null != Session["username"])
        {
            //已经登录
            sb.Append("欢迎登录:" + Session["username"].ToString());
            sb.Append("&nbsp;&nbsp;");
            sb.Append("<a href='ShareLeaveWordList.aspx'><u>注销</u></a>&nbsp;<a href='#' onclick='javascript:window.close()'><u>退出</u></a>");
        }
        else
        {
            sb.Append("<a href='Login.aspx'><u>登录</u></a>&nbsp;<a href='UserRegesiter.aspx'><u>注册</u></a>&nbsp;<a href='#' onclick='javascript:window.close()'><u>退出</u></a>");
        }
        return sb.ToString();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        UserInfo_M u = new UserInfo_M();
        if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
        {
            u.UID = txtUserName.Text;
            u.Password = txtPassword.Text;
            u.Qq = txtQQ.Text;
            u.Email = txtEmail.Text;
            if (RadioButton1.Checked)
                u.Sex = "男";
            else
                u.Sex = "女";
            u.WebSite = txtWebsite.Text;
            u.Popedom = 1;//普通用户
            u.Ip = Request.UserHostAddress;
            OnlineLeaveWord.BLL.IUser.Regesiter rg= new OnlineLeaveWord.BLL.IUser.Regesiter();
            if (rg.IsRegesiter(u))
            {
                Session["username"] = u.UID;
                Response.Write("注册成功！;location.href='ShareLeaveWordList.aspx'");
            }
            else
            {
                Response.Write("注册失败，请重试！");
            }
        }
    }
}
