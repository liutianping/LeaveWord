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

public partial class LeaveWordDeatil : System.Web.UI.Page
{
    OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord leaveWord = null;
    OnlineLeaveWord.BLL.ReplyImpl.ReplyImp reply = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int articleID = 0;
            leaveWord = new OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord();
            //articleID =int.Parse(Request.QueryString["articleid"].ToString());
            articleID = 23;
            LeaveWord_M lw = leaveWord.GetLeaveDetail(articleID);

          
            if (lw != null)
            {
               
                lblTitle.Text = lw.Subject;
                lrContent.Text = lw.Content;
            }
            reply = new OnlineLeaveWord.BLL.ReplyImpl.ReplyImp();
            List<OnlineLeaveWord.Model.Reply_M> replyList = (List<OnlineLeaveWord.Model.Reply_M>)reply.GetReply(lw);
            replyList.Sort(OnlineLeaveWord.Model.Reply_M.GetComparer());	// 倒序排列
            ViewState["List"] = replyList;					// 设置ViewState
            ltPageViews.Text = "";
            rpComment.DataSource = replyList;
            rpComment.DataBind();
        }
    }



    protected void AddComment(List<Reply_M> list, List<Reply_M> quoteList, Reply_M cmt)
    {
        int temp;
        if (null != cmt)
            if (int.TryParse(cmt.ReplyId.ToString(), out temp))
            {
                Reply_M find = list.Find(new Predicate<Reply_M>(cmt.MatchRule));
                if (null != find)
                    quoteList.Add(find);

                // 递归调用，只要CommentId不为零，就加入到引用评论列表
                AddComment(list, quoteList, find);
            }
            else
                return;
    }
    public string GetContent(object dataItem)
    {
        string output = "";
        List<Reply_M> list = (List<Reply_M>)rpComment.DataSource;	// 获取全部列表

        Reply_M cmt = (Reply_M)dataItem;					// 获取当前评论
        List<Reply_M> quoteList = new List<Reply_M>();	// 创建当前评论所引用的评论列表

        AddComment(list, quoteList, cmt);		// 为当前评论的引用列表添加项目

        quoteList.Sort(Reply_M.GetComparer());	// 对列表排序，顺序排列

        foreach (Reply_M quote in quoteList)	// 生成引用的评论列表
        {
            if (null != quote)
                output = String.Format(
                        "<div>{0}<span>{1} 原贴：</span><br />{2}</div>",
                        output, quote.UserName, quote.Content);
        }

        // 添加当前引用
        output = String.Format(
                "<div class='comment'><p class='title'><span>{0} 发表</span>{1}</p>{2}<p>{3}<span style='margin-left:15px;'><input type='button' value='回复' onclick='alertWin(\"留言回复\",\"原文:{5}\",400,300,{4},{6})'/> </span></p></div>",
                cmt.Date, cmt.UserName, output, cmt.Content,cmt.Id,cmt.Content,cmt.LeaveWordId);
        return output;
    }
}
