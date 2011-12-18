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

public partial class Blog_BlogListByCategoryID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImp = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        string categoryId = null == Request.QueryString["categoryname"] ? Request.QueryString["categoryname"] : null;
        //if (null == categoryId)
        //    Server.Transfer("../error.htm");
        //else
        //{
            
        //}
    }
}
