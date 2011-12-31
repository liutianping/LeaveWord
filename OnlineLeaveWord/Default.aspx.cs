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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindingRptNewBlog();

    }


    private void BindingRptNewBlog()
    {
        OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogbll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
        List<Blog> list = blogbll.GetListTop(10);
        rptNewBlog.DataSource = list;
        rptNewBlog.DataBind();
    }

    public string GetString(object o)
    {
        Blog blog = (Blog)o;
        StringBuilder sb = new StringBuilder();
        sb.Append("<a href='Blog/BlogDetail.aspx?blogid=");
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
        string result = str;
        if (str.Length >= 15)
        {
            result = str.Substring(0, 8);
            result += "...";
            result += str.Substring(str.Length - 5);
            int i=  result.Length;
        }
        else
        {
            for (int i = 0; i < 17-str.Length; i++)
            {
                result += "&nbsp;";
            }
        }
        return result;
    }
}
