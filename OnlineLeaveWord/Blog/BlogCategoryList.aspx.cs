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

public partial class Blog_BlogCategoryList : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo_M ui = new UserInfo_M();
        //Session["username"] = "admin";
        if (null != Session["username"])
        {
            ui.UID = Session["username"].ToString();
        }
        
        List<BlogCategory> listPage = (List<BlogCategory>)bcImpl.GetBlogCategoryListByUser(ui);
        DataList1.DataSource = listPage;
        DataList1.DataBind();
    }


    public string GetBlogCountByCategoryID(object o)
    {
        return "2";
    }
}
