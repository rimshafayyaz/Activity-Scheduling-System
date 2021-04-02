using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityScheduling
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            password_textBox.PasswordChar = '*';
            password_textBox.MaxLength = 10;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {


            string username = username_textBox.Text;
            string email = email_textBox.Text;
            string password = password_textBox.Text;
            try
            {
                SqlConnection Con = new SqlConnection("Data Source=SADDIQUE-USAMA\\SQLEXPRESS;Initial Catalog=Data Source;Integrated Security=True");
                Con.Open();
                SqlCommand Cmd = new SqlCommand("Insert into login values (@a,@b,@c)", Con);
                Cmd.Parameters.AddWithValue("@a", username);
                Cmd.Parameters.AddWithValue("@b", email);
                Cmd.Parameters.AddWithValue("@c", password);


                Cmd.ExecuteNonQuery();
                MessageBox.Show("          Saved Successfully        ");
                username_textBox.Text = " ";
                email_textBox.Text = " ";
                password_textBox.Text = " ";

                Login_Page p2 = new Login_Page();
                p2.Show();
                this.Hide();
                //data_grid_populate_karna_function();
                //red();
                Cmd.Dispose();
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Make a new Database in your SQL Server and run the given login query in it." +
                    "Give the path of that Database in the project Login Page");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Page p2 = new Login_Page();
            p2.Show();
            this.Hide();

        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
