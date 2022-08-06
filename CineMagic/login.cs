using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CineMagic
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\Final Project\CineMagic\MovieDatabase.mdf;Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            if(true)
            {
                connect.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE Username='"+textBox1.Text+"',Password='"+textBox2.Text+"')", connect);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read() == true)
                {
                    CinMagicForm f = new CinMagicForm();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Unregistered", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Empty Fields");
            }


            else if (textBox1.Text == textBox2.Text)
            {
                connect.Open();
                SqlCommand c = new SqlCommand("INSERT INTO Login VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", connect);
                c.ExecuteNonQuery();
                MessageBox.Show("Registered");
                connect.Close();
            }

            else
            {
                MessageBox.Show("Password Doesnot match");
                textBox1.Clear();
                textBox2.Clear();
                
            }

        }
    }
}
