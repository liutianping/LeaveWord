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

public partial class UserControls_UC_BlogCollection : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["username"] = "admin";
        string uid = Session["username"].ToString();
        UserInfo_M u = new UserInfo_M();
        u.UID = uid;

        OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        List<BlogCategory> result = bcImpl.GetBlogCategoryListByUser(u, 1);
        this.Repeater1.DataSource = result;
        Repeater1.DataBind();
    }

    protected void ImgButton_Click(object sender, EventArgs e)
    {
        string url = Request.Url.AbsoluteUri;
        OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        if (1 == bcImpl.BlogCategoryDelete(int.Parse(((ImageButton)sender).CommandArgument)))
            Response.Write("<script>javascript:alert('删除成功！');location.href='" + url + "';</script>");
        else
            Response.Write("<script>javascript:alert('删除失败！');location.href='" + url + "';</script>");
    }

    public string GetBlogCountByCategoryID(object o)
    {
        return "2";
    }
}
