using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kronos_Manager
{
    public partial class Form1 : Form
    {
        internal static AddAssignment Assignment;
        internal static TimeManager TimeManager;
        internal static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }
        
        public static List<Assignment> assignments = new List<Assignment>();
        

        
        public void UpdateNames(List<Assignment> list)
        {
            listBox1.Items.Clear();
            foreach (Assignment assignment in assignments)
                listBox1.Items.Add(assignment.Name);
        }
        private void buttonAddAssignment_Click(object sender, EventArgs e)
        {
            Assignment = new AddAssignment();
            Assignment.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            Beats ShowBeats = new Beats();
            ShowBeats.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           // string SelectedDate = monthCalendar1.SelectionStart.ToString();
           // MessageBox.Show(SelectedDate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeManager = new TimeManager();
            TimeManager.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateNames(assignments);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assignment current = new Assignment();
            label2.Text = "";
            foreach (Assignment assignment in assignments)
            {
                try
                {
                    if (listBox1.SelectedItem.ToString() == assignment.Name)
                    {
                        current = assignment;
                    }
                }
                catch
                {
                    continue;
                }
            }
            label2.Text = "Date: " + current.Date + "\n" +
                "Subject: " + current.Subject + "\n" +
                "Description: " + current.Description + "\n" +
                "Start Time: " + current.StartTime + "\n" +
                "End Time: " + current.EndTime + "\n" +
                "Duration: " + current.Duration + " minutes \n";
        }
    }
}
