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
    public partial class Beats : Form
    {
        public Beats()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Lofi
        {
            webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=5qap5aO4i9A", System.UriKind.Absolute);
            // System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=5qap5aO4i9A");
            //Uri yt = https://www.youtube.com/watch?v=5qap5aO4i9A;
            //webBrowser1.Url = yt;
        }

        private void button2_Click(object sender, EventArgs e) // Classical
        {
            webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=RVfNygw10NU&ab_channel=YellowBrickCinema-RelaxingMusic", System.UriKind.Absolute);
        }

        private void button3_Click(object sender, EventArgs e) // Piano
        {
            webBrowser1.Url = new System.Uri("https://www.youtube.com/watch?v=XULUBg_ZcAU", System.UriKind.Absolute);
        }

        private void button4_Click(object sender, EventArgs e) // Close
        {
            webBrowser1.Url = new System.Uri("https://google.com", System.UriKind.Absolute);
            this.Close();
        }

        private void Beats_Load(object sender, EventArgs e)
        {

        }
    }
}
