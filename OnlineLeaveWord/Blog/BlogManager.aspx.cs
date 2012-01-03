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

public partial class Blog_BlogManager : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            blogBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
            //Session["username"] = "admin";
            List<Blog> listBlog = blogBll.GetListByUser(Session["username"].ToString());
            if (listBlog.Count != 0)
            {
                Repeater1.DataSource = listBlog;
                Repeater1.DataBind();
            }
            else
            {
                Label1.Visible = true;
                linkBlogAdd.Visible = true;
                Label1.Text = "您没有博客。";
            }
        }
    }
    protected void ImgDelete_Click(object sender, EventArgs e)
    {
        string blodID = ((ImageButton)sender).CommandArgument;
        blogBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
        try
        {
            blogBll.DeleteBlog(int.Parse(blodID));
            Response.Write("<script>javascript:alert('博客删除成功！');location.href='BlogManager.aspx'</script>");
        }
        catch (Exception)
        {
            Response.Write("<script>javascript:alert('可能由于系统原因，博客删除失败！');location.href='BlogManager.aspx'</script>");
        }

    }

    protected string SubString(string str)
    {
        if (str.Length > 25)
        {
            string result = str.Substring(0, 15);
            result += "...";
            result += str.Substring(str.Length - 10);
            return Server.HtmlEncode(result);
        }
        return Server.HtmlEncode(str);
    }
}


