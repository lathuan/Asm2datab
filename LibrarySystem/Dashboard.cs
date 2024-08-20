using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addbooks f = new Addbooks();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Viewbooks vb = new Viewbooks();
            vb.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addstudent a = new Addstudent();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Viewstudent b = new Viewstudent();
            b.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Issuebooks c = new Issuebooks();
            c.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Returnbooks d = new Returnbooks();
            d.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IssuebooksRP h = new IssuebooksRP();
            h.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReturnbooksRP k = new ReturnbooksRP();
            k.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
