using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLeaveWord.Model
{
    [Serializable]
    public class Time_M
    {
        string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        string month;

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public override string ToString()
        {
            return year + "Äê" + month + "ÈÕ";
        }
    }
}
