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
    public partial class Alarm : Form
    {
        public Alarm()
        {
            InitializeComponent();
        }

        private void Alarm_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=OgHbJbx7ENw", System.UriKind.Absolute);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new System.Uri("https://google.com", System.UriKind.Absolute);
            this.Hide();
        }
    }
}
