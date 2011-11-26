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
using OnlineLeaveWord.BLL.LeaveWordImpl;
using OnlineLeaveWord.Model;
using System.Collections.Generic;
using System.Text;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindDlLeaveWord();
        }
    }

    private void bindDlLeaveWord()
    {
        OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord lw = new OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord();
        UserInfo_M u = new UserInfo_M();
        List<OnlineLeaveWord.Model.LeaveWord_M> list = (List<OnlineLeaveWord.Model.LeaveWord_M>)lw.GetAllLeaveWord(u);
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }

    public string SubString(string str,int length)
    {
        if (str.Length > length)
            return str.Substring(0, length)+"...";
        else
            return str;
    }

    //public string GetContent(Object item)
    //{
    //    LeaveWord_M lw = (LeaveWord_M)item;
    //    int articleID = lw.Id;
    //    int replyCount = 0;
    //    string pageViews = "1";
    //    OnlineLeaveWord.BLL.ReplyImpl.ReplyImp reply = new OnlineLeaveWord.BLL.ReplyImpl.ReplyImp();
    //    replyCount = reply.GetReplyCountByLeaveWordId(lw);
    //    pageViews=lw.PageViews == "0" ? "1" : lw.PageViews;
    //    if (lw.Subject.Length > 15)
    //    {
    //        lw.Subject = lw.Subject.Substring(0,10)+"...";
    //    }
    //    if (lw.Content.Length > 20)
    //    {
    //        lw.Content = lw.Content.Substring(0,15)+"...";
    //    }
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("<span style='text-align:center;margin-left: 10px;'>");
    //    sb.Append(lw.Subject);
    //    sb.Append("</span>");
    //    sb.Append("<span style='text-align:left'>");
    //    sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
    //    sb.Append(lw.Content);
    //    sb.Append("</span>");
    //    sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
    //    sb.Append("评论(<a href=LeaveWordDeatil.aspx?articleid=");
    //    sb.Append(lw.Id.ToString());
    //    sb.Append(">"+replyCount.ToString());
    //    sb.Append("</a>");
    //    sb.Append("|浏览(");
    //    sb.Append(pageViews);
    //    sb.Append(")");
    //    return sb.ToString();
    //}
}
