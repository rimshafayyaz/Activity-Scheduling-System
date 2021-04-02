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
    public partial class InstructionPage : Form
    {
        public InstructionPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_Page p2 = new Home_Page();
            p2.Show();
            this.Hide();
        }
    }
}
