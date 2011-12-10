using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.Model
{
    public class UserInfo_M
    {
        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _uID;

        public string UID
        {
            get { return _uID; }
            set { _uID = value; }
        }
        string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        string _sex;

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        string _webSite;

        public string WebSite
        {
            get { return _webSite; }
            set { _webSite = value; }
        }
        string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        string _qq;

        public string Qq
        {
            get { return _qq; }
            set { _qq = value; }
        }
        string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        int _popedom;

        public int Popedom
        {
            get { return _popedom; }
            set { _popedom = value; }
        }
    }
}
