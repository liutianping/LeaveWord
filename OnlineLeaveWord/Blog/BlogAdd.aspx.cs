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

public partial class BlogAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
            UserInfo_M userInfo = new UserInfo_M();
            userInfo.UID = Session["username"].ToString();
            List<BlogCategory> list = bcImpl.GetBlogCategoryListByUser(userInfo);
            CheckBoxList1.DataSource = list;
            CheckBoxList1.DataTextField = "CategoryName";
            CheckBoxList1.DataValueField = "id";
            CheckBoxList1.DataBind();
        }
    }
    protected void btnTrue_Click(object sender, EventArgs e)
    {
        List<int> listCategory = new List<int>(); //存储blog的类别ID
        Blog blog = new Blog();
        blog.Blogcontent = this.txtBlogContent.Text.Trim();
        blog.Blogtitle = this.txtTitle.Text.Trim();
        blog.Isdeleet = "0";
        blog.Lastupdatetime = System.DateTime.Now.ToString();
        blog.Uid = Session["username"].ToString();
        blog.Publishtim = System.DateTime.Now.ToString();
        foreach (ListItem var in CheckBoxList1.Items)
        {
            if (var.Selected)
                listCategory.Add(int.Parse(var.Value));
        }
        try
        {
            OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
            bcImpl.SaveBlogCategory(bcImpl.SaveBlog(blog), listCategory);
            Response.Write("<script>javascript:alert('发表博客成功！');location.href='BlogListByUser.aspx'</script>");//TODO:路径有待编写
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('发表博客失败！请重新编写博客');</script>");
        }
        
        
    }
}
