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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        public static string filePath;

        private void browse_btn_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog(); //this prompts the user to open a file
            openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";   //opens only excel files
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            //Get the path of specified file
            filePath = openFileDialog.FileName;
            //loadInputExcel(filePath);

            timetable_generator p2 = new timetable_generator();
            p2.Show();
            this.Hide();
        }
        internal void initGUI()
        {
            throw new NotImplementedException();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            InstructionPage p2 = new InstructionPage();
            p2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Page p2 = new Login_Page();
            p2.Show();
            this.Hide();
        }
    }
        
    }
