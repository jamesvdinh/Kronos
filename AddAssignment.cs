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
    public partial class AddAssignment : Form
    {
        

        public AddAssignment()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assignment Assignment = new Assignment();

            Assignment.Subject = textBoxSubject.Text;
            Assignment.Name = textBoxName.Text;
            Assignment.Description = textBoxDescription.Text;
            int duration;

            
            // assingmnet date
           
            DateTime DueDate;
            DueDate = dateTimePicker1.Value;
            Assignment.Date = DueDate.ToString();
            // assingmnet start time
            
            DateTime StartTime;
            StartTime = dateTimePicker2.Value;
            Assignment.StartTime = StartTime.ToString();
            // assingmnet end time

            DateTime EndTime;
            EndTime = dateTimePicker3.Value;
            Assignment.EndTime = EndTime.ToString();

            

            if (int.TryParse(textBoxDuration.Text, out duration))
            {
                Assignment.Duration = int.Parse(textBoxDuration.Text);
                Form1.assignments.Add(Assignment);
                Form1.form1.UpdateNames(Form1.assignments);
                Assignment.Index = Form1.assignments.Count;
                foreach (Assignment assignment in Form1.assignments)
                {
                    assignment.Index = Form1.assignments.IndexOf(assignment);
                }
                MessageBox.Show("Assignment Added!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please use an integer in Duration");
            }
        }
    }
}
