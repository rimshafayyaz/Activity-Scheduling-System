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
    public partial class Form2 : System.Windows.Forms.Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        public Form2()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SetValueForText1 = username_textBox.Text;
            SetValueForText2 = password_textBox.Text;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ULMTKBS\\SQLEXPRESS;Initial Catalog=ActivityScheduling;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from logindata where username=@a and password=@b ", con);
            cmd.Parameters.AddWithValue("@a", SetValueForText1);
            cmd.Parameters.AddWithValue("@b", SetValueForText2);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                this.Hide();
                activityscheduler p2 = new activityscheduler();
                p2.Show();

            }
            else
            {
                MessageBox.Show("You cannot Loggin into the system \n Your password or username is incorrect.");
            }

            cmd.ExecuteNonQuery();
        }
    }
}
