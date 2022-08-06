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
    public partial class LoadingUI : Form
    {
        //SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Final Project\CineMagic\MovieDatabase.mdf;Integrated Security=True");

        public LoadingUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //    int nameInt = Convert.ToInt32(nameBox.Text.Trim().Length);
            //    int qualityInt = Convert.ToInt32(qualityBox.Text.Trim().Length);
            //    int ratingInt = Convert.ToInt32(ratingBox.Text.Trim().Length);
            //    int typeInt = Convert.ToInt32(typeBox.Text.Trim().Length);
            //    int directorInt = Convert.ToInt32(directorBox.Text.Trim().Length);
            //    int releasedInt = Convert.ToInt32(releasedBox.Text.Trim().Length);

            //    if ((nameInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else if ((qualityInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else if ((ratingInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else if ((typeInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else if ((directorInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else if ((releasedInt < 1))
            //    {
            //        MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        myConn.Open();

            //        SqlCommand myComnd = new SqlCommand(@"INSERT INTO MovieListTB VALUES ('" + nameBox.Text + "', '" + qualityBox.Text + "', '" + ratingBox.Text + "', '" + typeBox.Text + "', '" + directorBox.Text + "', '" + releasedBox.Text + "')", myConn);
            //        myComnd.ExecuteNonQuery();
            //        MessageBox.Show("New Movie Record Added.", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        display_data();
            //        nameBox.Text = qualityBox.Text = ratingBox.Text = typeBox.Text = directorBox.Text = releasedBox.Text = string.Empty;
            //        this.Hide();

            //        myConn.Close();
            //    }
            //}

            //public void display_data()
            //{
            //    myConn.Open();
            //    CinMagicForm mainForm = new CinMagicForm();
            //    SqlCommand myComnd = new SqlCommand("SELECT * FROM MovieListTB", myConn);
            //    myComnd.ExecuteNonQuery();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(myComnd);
            //    da.Fill(dt);
            //    mainForm.movieListGridView.DataSource = dt;
            //    myConn.Close();
            //}

        }

    }
}
