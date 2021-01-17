using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kronos_Manager
{

    public class Assignment
    {
        private string date;
        private string subject;
        private string name;
        private string description;
        private string starttime;
        private string endtime;
        private int duration;
        private int index;

        public Assignment()
        {
            date = "";
            subject = "";
            name = "";
            description = "";
            starttime = "";
            endtime = "";
            duration = 0;
            index = 0;
        }
        public Assignment(string newdate, string newsubject, string newname, string newdescription, string newstartime, string newendtime, int newduration, int newindex)
        {
            date = newdate;
            subject = newsubject;
            name = newname;
            description = newdescription;
            starttime = newstartime;
            endtime = newendtime;
            duration = newduration;
            index = newindex;
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string StartTime
        {
            get { return starttime; }
            set { starttime = value; }
        }
        public string EndTime
        {
            get { return endtime; }
            set { endtime = value; }
        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
    }

}
