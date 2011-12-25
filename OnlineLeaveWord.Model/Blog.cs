using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.Model
{
    [Serializable]
    public class Blog
    {
        int? _id ;

        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _uid;

        public string Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        string _blogcontent;

        public string Blogcontent
        {
            get { return _blogcontent; }
            set { _blogcontent = value; }
        }
        string _blogtitle;

        public string Blogtitle
        {
            get { return _blogtitle; }
            set { _blogtitle = value; }
        }
        string _publishtim;

        public string Publishtim
        {
            get { return _publishtim; }
            set { _publishtim = value; }
        }
        string _lastupdatetime;

        public string Lastupdatetime
        {
            get { return _lastupdatetime; }
            set { _lastupdatetime = value; }
        }
        int _blog_browercount;

        public int Blog_browercount
        {
            get { return _blog_browercount; }
            set { _blog_browercount = value; }
        }
        string _isdeleet;

        public string Isdeleet
        {
            get { return _isdeleet; }
            set { _isdeleet = value; }
        }
    }
}
