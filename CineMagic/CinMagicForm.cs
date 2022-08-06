using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CineMagic
{
    public partial class CinMagicForm : Form
    {
        //Connection String
        SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Final Project\CineMagic\MovieDatabase.mdf;Integrated Security=True");

        public CinMagicForm()
        {
            InitializeComponent();
        }

        //Delete function
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nameBox.Text.Trim().Length) > 0)
            {
                try
                {
                    SqlCommand myComnd = new SqlCommand("DELETE ListTable WHERE Name=@name", myConn);
                    myComnd.CommandType = CommandType.Text;
                    myComnd.Parameters.AddWithValue("@name", nameBox.Text);

                    myConn.Open();
                    myComnd.ExecuteNonQuery();
                    myConn.Close();

                    MessageBox.Show("Movie Record Deleted.", "Deleted Successfully", MessageBoxButtons.OK);
                    display_data();
                    resetFormControls();
                }
                catch (Exception myExc)
                {
                    MessageBox.Show(myExc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Add function
        private void addMovieBtn_Click(object sender, EventArgs e)
        {
            int nameInt, qualityInt, ratingInt, typeInt, directorInt, releasedInt;
            nameInt = Convert.ToInt32(nameBox.Text.Trim().Length);
            qualityInt = Convert.ToInt32(qualityBox.Text.Trim().Length);
            ratingInt = Convert.ToInt32(ratingBox.Text.Trim().Length);
            typeInt = Convert.ToInt32(typeBox.Text.Trim().Length);
            directorInt = Convert.ToInt32(directorBox.Text.Trim().Length);
            releasedInt = Convert.ToInt32(releasedBox.Text.Trim().Length);

            if (nameInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (qualityInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ratingInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (typeInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (directorInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (releasedInt < 1)
            {
                MessageBox.Show("All fields are required.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand myComnd = new SqlCommand("INSERT INTO ListTable VALUES (@name, @quality, @rating, @type, @director, @released)", myConn);
                myComnd.CommandType = CommandType.Text;
                myComnd.Parameters.AddWithValue("@name", nameBox.Text);
                myComnd.Parameters.AddWithValue("@quality", qualityBox.Text);
                myComnd.Parameters.AddWithValue("@rating", ratingBox.Text);
                myComnd.Parameters.AddWithValue("@type", typeBox.Text);
                myComnd.Parameters.AddWithValue("@director", directorBox.Text);
                myComnd.Parameters.AddWithValue("@released", releasedBox.Text);
                myConn.Open();
                myComnd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("New Movie Record Added.", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display_data();
                resetFormControls();
            }
        }

        //Update function
        private void updateMovieBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nameBox.Text.Trim().Length) > 0)
            {
                try
                {
                    myConn.Open();
                    SqlCommand myComnd = new SqlCommand("UPDATE ListTable SET Quality='" + qualityBox.Text + "', Rating='" + ratingBox.Text + "', Type='" + typeBox.Text + "', Director='" + directorBox.Text + "', ReleasedIn='" + releasedBox.Text + "' WHERE ReleasedIn='"+releasedBox.Text+"'", myConn);
                    myComnd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("Movie Record Updated.", "Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    display_data();
                    resetFormControls();
                }
                catch (Exception myExc)
                {
                    MessageBox.Show(myExc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a record to update.", "Select...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetFormControls()
        {
            nameBox.Clear();
            qualityBox.Clear();
            ratingBox.Clear();
            typeBox.Clear();
            directorBox.Clear();
            releasedBox.Clear();
        }
        private void CinMagicForm_Load(object sender, EventArgs e)
        {
            nameBox.Focus();
            display_data();
            // TODO: This line of code loads data into the 'movieDatabaseDataSet3.ListTable' table. You can move, or remove it, as needed.
            this.listTableTableAdapter.Fill(this.movieDatabaseDataSet3.ListTable);
        }
        public void display_data()
        {
            try
            {
                SqlCommand myComnd = new SqlCommand("SELECT * FROM ListTable", myConn);

                myConn.Open();
                SqlDataReader sdr = myComnd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                myConn.Close();

                movieListGridView.DataSource = dt;
            }
            catch (Exception myExc)
            {
                MessageBox.Show(myExc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void movieListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nameBox.Text = movieListGridView.SelectedRows[0].Cells[0].Value.ToString();
            qualityBox.Text = movieListGridView.SelectedRows[0].Cells[1].Value.ToString();
            ratingBox.Text = movieListGridView.SelectedRows[0].Cells[2].Value.ToString();
            typeBox.Text = movieListGridView.SelectedRows[0].Cells[3].Value.ToString();
            directorBox.Text = movieListGridView.SelectedRows[0].Cells[4].Value.ToString();
            releasedBox.Text = movieListGridView.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void resetFieldBtn_Click(object sender, EventArgs e)
        {
            resetFormControls();
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if(searchBox.Text != "")
            {
                if(myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                    SqlCommand com = myConn.CreateCommand();
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT * FROM ListTable WHERE Name = '" + searchBox.Text + "'";
                    com.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    movieListGridView.DataSource = dt;
                    myConn.Close();
                    resetFormControls();
                }
            }
            else
            {
                display_data();
            }
        }

        private void movieListGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
