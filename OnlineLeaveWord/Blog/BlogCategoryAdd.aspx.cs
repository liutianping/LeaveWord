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

public partial class BlogCategoryAdd : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl bcImpl = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        BlogCategory bc = new BlogCategory();
        bcImpl = new OnlineLeaveWord.BLL.Blog.BlogInterfaceImpl.BlogCategoryImpl();
        if (!string.IsNullOrEmpty(this.txtCategoryName.Text))
        {
            bc.CategoryName = txtCategoryName.Text;
        }
        bc.IsDelte = '0';
        bc.PublishTime = System.DateTime.Now.ToString();
        if (null != Session["username"])
        {
            bc.UId = Session["username"].ToString();
        }

        if (1 == bcImpl.BlogCategorySave(bc))
        {
            Response.Write("添加类别成功！location.href='BlogCategoryAdd.aspx'");
        }
        else
        {
            Response.Write("添加类别失败!");
        }
    }
}
