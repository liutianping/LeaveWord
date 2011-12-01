using System;
using System.Collections.Generic;

using System.Text;

namespace OnlineLeaveWord.Model
{
    [Serializable]
    public class Reply_M
    {
        int _id=0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        int? _replyId;

        public int? ReplyId
        {
            get { return _replyId; }
            set { _replyId = value; }
        }
        string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _leaveWordId;

        public string LeaveWordId
        {
            get { return _leaveWordId; }
            set { _leaveWordId = value; }
        }

        // 实现 Predicate<T> 委托，搜索Id 等于当前评论的CommentId的评论
        public bool MatchRule(Reply_M cmt)
        {
            return (this._replyId == cmt.Id);
        }

        public static CommentComparer GetComparer(bool isAscending)
        {
            return new CommentComparer(isAscending);
        }

        public static CommentComparer GetComparer()
        {
            return GetComparer(true);
        }

        public class CommentComparer : IComparer<Reply_M>
        {
            private bool isAscending;

            public CommentComparer(bool isAscending)
            {
                this.isAscending = isAscending;
            }

            public int Compare(Reply_M x, Reply_M y)
            {
                if (null != x && null != y)
                {
                    if (isAscending)
                        return x.Id.CompareTo(y.Id);
                    else
                        return y.Id.CompareTo(x.Id);
                }
                else
                {
                    return 0;
                }
                
            }
        }
    }
}
