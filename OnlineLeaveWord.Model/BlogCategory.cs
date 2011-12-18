using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.Model
{
    public class BlogCategory
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _categoryName;

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        string _uId;

        public string UId
        {
            get { return _uId; }
            set { _uId = value; }
        }
        string _publishTime;

        public string PublishTime
        {
            get { return _publishTime; }
            set { _publishTime = value; }
        }
        string _isDelte;

        public string IsDelte
        {
            get { return _isDelte; }
            set { _isDelte = value; }
        }
    }
}
