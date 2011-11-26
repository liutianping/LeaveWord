using System;
using System.Collections.Generic;

using System.Text;

namespace OnlineLeaveWord.Model
{
    public class Log_M
    {
        int _logId;

        public int LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }
        int _uId;

        public int UId
        {
            get { return _uId; }
            set { _uId = value; }
        }
        string _event;

        public string _event1
        {
            get { return _event; }
            set { _event = value; }
        }
    }
}
