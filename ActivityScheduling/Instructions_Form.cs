using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityScheduling
{
    public partial class Instructions_Form : Form
    {
        public Instructions_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Page p2 = new Login_Page();
            p2.Show();
            this.Hide();
        }
    }
}
