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
using System.Text;

public partial class Blogs : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null == Session["username"])
            Server.Transfer("Login.asxp");
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
            sb.Append("<a href='Default.aspx'><u>注销</u></a>&nbsp;<a href='#' onclick='javascript:window.close()'><u>退出</u></a>");
        }
        else
        {
            sb.Append("<a href='Login.aspx'><u>登录</u></a>&nbsp;<a href='UserRegesiter.aspx'><u>注册</u></a>&nbsp;<a href='#' onclick='javascript:window.close()'><u>退出</u></a>");
        }
        return sb.ToString();
    }
}
