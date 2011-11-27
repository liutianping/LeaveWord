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
    private static int currentIndex = 1;
    private static int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"].ToString());
    private static ListPager<OnlineLeaveWord.Model.LeaveWord_M> list = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindDlLeaveWord(currentIndex,pageSize);
        }
    }

    private void bindDlLeaveWord(int currIndex,int pagesize)
    {
        OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord lw = new OnlineLeaveWord.BLL.LeaveWordImpl.LeaveWord();
        UserInfo_M u = new UserInfo_M();
        list = new ListPager<OnlineLeaveWord.Model.LeaveWord_M>((List<OnlineLeaveWord.Model.LeaveWord_M>)lw.GetAllLeaveWord(u), currIndex, pagesize);
        Repeater1.DataSource = list;    
        Repeater1.DataBind();
        BindPagerControls();
        
    }

    private void BindPagerControls()
    {
        // 判断上一页，下一页按钮是否启用.
        btnPrevious.Enabled = currentIndex != 1;
        btnNext.Enabled = currentIndex != list.PageCount;

        lblCurrentpage.Text = list.CurrentIndex.ToString();
        lblTotalPage.Text = list.PageCount.ToString();
        lblPageinfo.Text = String.Format("共{0}条记录，每页显示{1}条", list.TotalItem, list.PageSize);
    }


    public string SubString(string str,int length)
    {
        if (str.Length > length)
            return str.Substring(0, length)+"...";
        else
            return str;
    }

    protected void btnfirstpage_click(object sender, EventArgs e)
    {
        currentIndex = 1; //修正为1，第一次发的时候写成0了，2B了～
        bindDlLeaveWord(currentIndex, pageSize);
        BindPagerControls();
    }
    protected void btnprevious_click(object sender, EventArgs e)
    {
        --currentIndex;
        bindDlLeaveWord(currentIndex, pageSize);
        BindPagerControls();
        
    }
    protected void btnnext_click(object sender, EventArgs e)
    {
        ++currentIndex;
        bindDlLeaveWord(currentIndex, pageSize);
        BindPagerControls();
        
    }
    protected void btnlastpage_click(object sender, EventArgs e)
    {
        currentIndex = list.PageCount;
        bindDlLeaveWord(currentIndex, pageSize);
        BindPagerControls();
    }
}
