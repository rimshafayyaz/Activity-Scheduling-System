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
    public partial class Login_Page : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public Login_Page()
        {
            InitializeComponent();
            password_textBox.PasswordChar = '*';
            password_textBox.MaxLength = 10;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            SetValueForText1 = username_textBox.Text;
            SetValueForText2 = password_textBox.Text;
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SADDIQUE-USAMA\\SQLEXPRESS;Initial Catalog=Data Source;Integrated Security=True");
                //change the SQL according to the server create new database nd place the sql file given in the folder
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from login where username=@a and password=@c ", con);
                cmd.Parameters.AddWithValue("@a", SetValueForText1);
                cmd.Parameters.AddWithValue("@c", SetValueForText2);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    Home_Page p2 = new Home_Page();
                    p2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("You cannot Loggin into the system \n Your password or username is incorrect.");
                }


                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Make a new Database in your SQL Server and run the given login query in it." +
                    "Give the path of that Database in the project Login Page");
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_MouseHover(object sender, EventArgs e)
        {
            loginButton.BackColor = Color.AliceBlue;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            Instructions_Form p2 = new Instructions_Form();
            p2.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
            SignupForm p2 = new SignupForm();
            p2.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
