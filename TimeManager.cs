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
    public partial class TimeManager : Form
    {
        public TimeManager()
        {
            InitializeComponent();
        }

        private void TimeManager_Load(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (Assignment assignment in Form1.assignments)
                listBox2.Items.Add(assignment.Name);
        }
        Alarm alarm = new Alarm();
        public int breakinterval;
        public int breaknum = 1;
        public int breakduration = 300;
        private void Button1_Click(object sender, EventArgs e) // Start Session
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    if (listBox2.Items.Count != 0)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        progressBar1.Maximum = currentTime.Duration * 60;
                        progressBar2.Maximum = 300;
                    }
                    else
                    {
                        MessageBox.Show("You have no assignments!");
                    }
                }
                else
                {
                    MessageBox.Show("Input a break interval");
                }
            }
            catch
            {
                MessageBox.Show("Choose an assignment from the list");
            }
        }
        //uwu
        int j = 0;
        
        private void timer1_Tick(object sender, EventArgs e) // Main Timer
        {
            try
            {
                breakinterval = int.Parse(comboBox1.Text) * 60;
                int timevalue = (time.Duration * 60) - j;
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    int seconds = timevalue % 60;
                    int minutes = (timevalue / 60) % 60;
                    string min = minutes.ToString(); // min
                    string sec = seconds.ToString(); // sec
                    label5.Text = string.Format("{0}:{1}", min.PadLeft(2, '0'), sec.PadLeft(2, '0')); // Clock
                    progressBar1.Value++;
                    j++;
                    timevalue--;
                }
                else if (progressBar1.Value == progressBar1.Maximum)
                {
                    timer1.Enabled = false;
                    this.Focus();
                    alarm.ShowDialog();
                    alarm.Hide();
                }
            }
            catch
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                progressBar2.Value = 0;
                MessageBox.Show("Choose an assignment from the list or click 'Start Session'");
            }
        }
        Assignment time = new Assignment();
        Assignment currentTime = new Assignment();
        Assignment next = new Assignment();
        int nextIndex;
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // Assignments
        {
            progressBar1.Value = 0;
            j = 0;
            int currentIndex;
            label2.Text = "";
                foreach (Assignment assignment in Form1.assignments)
                {
                    try
                    {
                        if (listBox2.SelectedItem.ToString() == assignment.Name)
                        {
                            currentTime = assignment;
                            currentIndex = assignment.Index;
                            nextIndex = currentIndex + 1;
                            time.Duration = currentTime.Duration;
                    }
                    }
                    catch
                    {
                        continue;
                    }
                }
                label1.Text = "Assignment: " + currentTime.Name + "\n" +
                    "Date: " + currentTime.Date + "\n" +
                    "Subject: " + currentTime.Subject + "\n" +
                    "Description: " + currentTime.Description + "\n" +
                    "Start Time: " + currentTime.StartTime + "\n" +
                    "End Time: " + currentTime.EndTime + "\n" +
                    "Duration: " + currentTime.Duration + " minutes \n";
                foreach (Assignment assignment in Form1.assignments)
                {
                    try
                    {
                        if (assignment.Index == nextIndex)
                        {
                            next = assignment;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                label2.Text = "Assignment: " + next.Name + "\n" +
                    "Date: " + next.Date + "\n" +
                    "Subject: " + next.Subject + "\n" +
                    "Description: " + next.Description + "\n" +
                    "Start Time: " + next.StartTime + "\n" +
                    "End Time: " + next.EndTime + "\n" +
                    "Duration: " + next.Duration + " minutes \n";
        }

        private void button2_Click(object sender, EventArgs e) // Pause/Resume button
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }
            else if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            if (timer2.Enabled == true)
            {
                timer2.Enabled = false;
            }
            else if (timer2.Enabled == false)
            {
                timer2.Enabled = true;
            }
            if (progressBar2.Enabled == true || progressBar2.Value == progressBar2.Maximum)
            {
                timevalue = 0;
                progressBar2.Value = 0;
                timer2.Enabled = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // null
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Break Interval
        {
            breakinterval = int.Parse(comboBox1.Text) * 60;
        }
        int timevalue = 0;

        private void timer2_Tick(object sender, EventArgs e) // Break timer
        {
            int tempvalue = 0;
            // starts here
            timevalue++; // adds every second

            // break starts
            if (timevalue == breakinterval)
            {
                timer1.Enabled = false;
                progressBar2.Enabled = true;
                
                tempvalue = timevalue;
                this.Focus();
                MessageBox.Show("Take a Break! \n" + "5 minutes");
            }

            // break progress bar
            if (timevalue >= breakinterval && timevalue < (breakinterval + breakduration + 60))
            {
                if (progressBar2.Value < progressBar2.Maximum)
                {
                    progressBar2.Value++;
                }
                else if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar2.Value = 0;
                }
            }

            // break ends
            if (progressBar2.Value == progressBar2.Maximum)
            {
                timevalue = 0;
                timer2.Enabled = false;
                this.Focus();
                MessageBox.Show("Break is over.\n" + "Remember to press the Resume button to resume the assignment.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e) // Next Assignment
        {
            try
            {
                int index = listBox2.SelectedIndex;
                listBox2.SelectedIndex = index + 1;
                currentTime = next;
                progressBar2.Value = 0;
                timevalue = 0;
                progressBar2.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
            catch
            {
                MessageBox.Show("There is no next assignment!");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // null
        }
    }
}
