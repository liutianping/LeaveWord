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

using OnlineLeaveWord.BLL.ReplyImpl;
using OnlineLeaveWord.Model;
using System.Collections.Generic;

public partial class LeaveWordManager : System.Web.UI.Page
{
    List<Reply_M> replyList = null;
    OnlineLeaveWord.BLL.ReplyImpl.ReplyImp replyImp = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (null != Session["username"])
            {
                replyImp = new ReplyImp();
                UserInfo_M u = new UserInfo_M();


                u.UID = Session["username"].ToString();

                replyList = (List<Reply_M>)replyImp.GetReplyByUserName(u);
                this.dlLeaveWord.DataSource = replyList;
                this.dlLeaveWord.DataBind();
            }
        }
    }

    protected void btnDelete_OnClick(object sender, EventArgs e)
    {
        string datakey = (sender as Button).CommandArgument.ToString();
        replyImp = new ReplyImp();
        if (1 == replyImp.DeleteReply(int.Parse(datakey)))
        {
            Response.Write("<script>alert('留言已经删除')</script>");
        }
        else
        {
            Response.Write("<script>alert('留言删除失败')</script>");
        }
        Server.Transfer("LeaveWordManager.aspx");
    }
}
