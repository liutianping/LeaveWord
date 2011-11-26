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

public partial class LeaveWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLeaveWord_Click(object sender, EventArgs e)
    {
        Session["userName"] = "textUser";
        LeaveWord_M lw = new LeaveWord_M();
        OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord bllLw = new OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord();
        if (!string.IsNullOrEmpty(this.txtTitle.Text))
            lw.Subject = txtTitle.Text;
        if (!string.IsNullOrEmpty(txtLeaveContent.Text))
            lw.Content = txtLeaveContent.Text;
        if (string.IsNullOrEmpty(Session["userName"].ToString()))
            lw.O_Uid = "匿名网友";
        else
            lw.O_Uid = Session["userName"].ToString();
        lw.Ip = Request.UserHostAddress;
        lw.Date = DateTime.Now;

        if (bllLw.AddLeaveWord(lw))
            Response.Write("<script>alert('留言成功')</script>");
        
    }
}
