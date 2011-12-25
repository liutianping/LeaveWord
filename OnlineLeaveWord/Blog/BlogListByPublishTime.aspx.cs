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
using System.Collections.Generic;
using OnlineLeaveWord.Model;
using System.Text;

public partial class Blog_BlogListByPublishTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dateTimeString = Request.QueryString["publishtime"];
        OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
        //Session["username"] = "admin";
        List<Blog> list = blogBll.GetListByPublishTime(Session["username"].ToString(),dateTimeString);
        this.Repeater1.DataSource = list;
        Repeater1.DataBind();
        
    }


    public string GetString(object o)
    {
        Blog blog = (Blog)o;
        StringBuilder sb = new StringBuilder();
        sb.Append("<a href='BlogDetail.aspx?blogid=");
        sb.Append(blog.Id.ToString());
        sb.Append("'>");
        sb.Append(blog.Blogtitle);
        sb.Append("(");
        sb.Append(blog.Blog_browercount);
        sb.Append(")");
        sb.Append("</a>");
        return sb.ToString();
    }
}
