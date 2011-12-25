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

public partial class Blog_UpdateBlog : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL blogBll;
    OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl;
    string blogID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfo_M userInfo = new UserInfo_M();
            //Session["username"] = "admin";
            userInfo.UID = Session["username"].ToString();
            blogID = "5";
            Label2.Text = blogID;
            //blogID = Request.QueryString["blogid"].ToString();
            blogBll = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
            Blog blog = blogBll.GetBlogDetail(int.Parse(blogID))[0];
            this.txtBlogTitle.Text = blog.Blogtitle;
            this.txtBlogContent.Text = blog.Blogcontent;
             bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
            
            List<BlogCategory> myCategory = bcImpl.GetBlogCategoryListByUser(userInfo);
            CheckBoxList1.DataSource = myCategory;
            CheckBoxList1.DataValueField = "id";
            CheckBoxList1.DataTextField = "categoryname";
            CheckBoxList1.DataBind();

            bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
            List<BlogCategory> listCategory = bcImpl.GetBlogCategoryByBlogId(int.Parse(blogID));

            for (int i = 0; i < listCategory.Count; i++)
            {
                for (int j = 0; j < CheckBoxList1.Items.Count; j++)
                {
                    if (listCategory[i].Id.ToString() == CheckBoxList1.Items[j].Value)
                        CheckBoxList1.Items[j].Selected = true;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<int> listCategory = new List<int>(); //存储blog的类别ID
        Blog blog = new Blog();
        blog.Id = int.Parse(Label2.Text);
        blog.Blogcontent = this.txtBlogContent.Text.Trim();
        blog.Blogtitle = this.txtBlogTitle.Text.Trim();
        blog.Isdeleet = "0";
        blog.Lastupdatetime = System.DateTime.Now.ToString();
        blog.Uid = Session["username"].ToString();
        foreach (ListItem var in CheckBoxList1.Items)
        {
            if (var.Selected)
                listCategory.Add(int.Parse(var.Value));
        }
        try
        {
            OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterface.BlogOperationBLL();
            bcImpl.SaveBlogCategory(bcImpl.SaveBlog(blog), listCategory);
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('博客更新成功！');</script>");
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('博客更新失败！请重新编写博客');</script>");
        }
    }
}
