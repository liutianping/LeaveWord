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

public partial class Blog_BlogDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["blogid"].ToString());
        OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
        OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl categoryBll = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        List<Blog> blog = blogBll.GetBlogDetail(id);
        lblCategory.Text = GetCategoryByList(categoryBll.GetBlogCategoryByBlogId(id));
        litTitle.Text = blog[0].Blogtitle;
        litContent.Text = blog[0].Blogcontent;
        lblCount.Text = "浏览次数:(" + blog[0].Blog_browercount.ToString() + ")";
    }

    private string GetCategoryByList(List<BlogCategory> list)
    {
        if (0 == list.Count)
            return "默认";
        StringBuilder sb = new StringBuilder();
        foreach (BlogCategory var in list)
        {
            if (var.CategoryName != "默认")
            {
                sb.Append("<a href='BlogListByCategoryID.aspx?categoryid=");
                sb.Append(var.Id);
                sb.Append("'>");

                sb.Append(var.CategoryName);
                sb.Append("</a>");
                sb.Append(" ");
            }
            else
            {
                sb.Append("默认");
            }
        }
        return sb.ToString();
    }
}
