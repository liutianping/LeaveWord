<%@ WebHandler Language="C#" Class="InsertReply" %>

using System;
using System.Web;
using OnlineLeaveWord.BLL.ReplyImpl;
using System.Web.SessionState;

public class InsertReply : IHttpHandler,IRequiresSessionState
{
    OnlineLeaveWord.Model.Reply_M reply_m = null;
    ReplyImp replyImp = null;
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string content = context.Request.QueryString["replyContent"];
        int id;
        int leaveWordid;

        if (int.TryParse(context.Request.QueryString["id"], out id) && int.TryParse(context.Request.QueryString["LeaveWordId"], out leaveWordid))
        {
            reply_m = new OnlineLeaveWord.Model.Reply_M();
            reply_m.Content = content;
            reply_m.ReplyId = id;
            try
            {
                reply_m.LeaveWordId = leaveWordid.ToString();
                reply_m.Ip = context.Request.UserHostAddress;
                //context.Session["username"] = "userName";
                if (null != context.Session["username"])
                    reply_m.UserName = context.Session["username"].ToString();
                else
                    reply_m.UserName = "匿名网友";
                replyImp = new ReplyImp();
                if (1 == replyImp.InsertReply(reply_m))
                    context.Response.Write("200");
            }
            catch (Exception)
            {
                context.Response.Redirect("Default.aspx");
            }
            
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}