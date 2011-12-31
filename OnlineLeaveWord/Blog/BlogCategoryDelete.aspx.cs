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

public partial class Blog_BlogCategoryDelete : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Binding();
        }
    }
    private void Binding()
    {
        bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        UserInfo_M user = new UserInfo_M();
        user.UID = Session["username"].ToString();
        user.UID = "admin";
        this.GridView1.DataSource = bcImpl.GetBlogCategoryListByUser(user,-1);
        this.GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        BlogCategory blogCategory = new BlogCategory();
        blogCategory.Id =int.Parse(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
        blogCategory.CategoryName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
        blogCategory.UId = Session["username"].ToString();
        blogCategory.IsDelte = "0";
        if(1== bcImpl.BlogCategorySave(blogCategory))
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('更新成功!');</script>");
        else
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('更新失败!');</script>");
        GridView1.EditIndex = -1;
        Binding();
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        if(1== bcImpl.BlogCategoryDelete(int.Parse(id)))
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('删除成功!');location.href='BlogCategoryDelete.aspx';</script>");
        else
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "demo", "<script>alert('删除失败!');location.href='BlogCategoryDelete.aspx';</script>");
        Binding();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Binding();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        Binding();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        //当前编辑行背景色高亮
        this.GridView1.EditRowStyle.BackColor = System.Drawing.Color.FromName("#F7CE90");
        Binding();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}
