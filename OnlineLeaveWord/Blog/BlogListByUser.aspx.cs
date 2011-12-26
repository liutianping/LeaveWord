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
using System.Text;

public partial class Blog_BlogListByUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["username"] = "admin";
            OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogbll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
            List<Blog> list = blogbll.GetListByUser(Session["username"].ToString());
            this.Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
    }

    public string GetString(object o)
    {
        Blog blog = (Blog)o;
        StringBuilder sb = new StringBuilder();
        sb.Append("<a href='BlogDetail.aspx?blogid=");
        sb.Append(blog.Id.ToString());
        sb.Append("'>");
        sb.Append(Substring(blog.Blogtitle));
        sb.Append("(");
        sb.Append(blog.Blog_browercount);
        sb.Append(")");
        sb.Append("</a>");
        return sb.ToString();
    }

    private string Substring(string str)
    {
        string result=str;
        if (str.Length >= 15)
        {
            result = str.Substring(0, 8);
            result += "...";
            result += str.Substring(str.Length-5);
        }
        return result;
    }
}
