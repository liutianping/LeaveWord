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
using System.Collections.Generic;

public partial class UserControls_UC_BlogListByPublishTime : System.Web.UI.UserControl
{
    OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogOperationBll = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        blogOperationBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
        Session["username"] = "admin";
        List<Time_M> list = blogOperationBll.GetTimeListByUser(Session["username"].ToString());
        this.Repeater1.DataSource = list;
        Repeater1.DataBind();
    }

    public string GetContent(object time_M)
    {
        Time_M time = (Time_M)time_M;
        return time.Year +"_"+ time.Month;
    }

}
