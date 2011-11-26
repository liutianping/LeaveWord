using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.Model
{
    [Serializable]
    public class LeaveWord_M
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _uId;

        public string UId
        {
            get { return _uId; }
            set { _uId = value; }
        }
        string _subject;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        string _o_Uid;

        public string O_Uid
        {
            get { return _o_Uid; }
            set { _o_Uid = value; }
        }

        string pageViews;

        public string PageViews
        {
            get { return pageViews; }
            set { pageViews = value; }
        }
    
    }
}
