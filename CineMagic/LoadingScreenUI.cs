using System;
using System.Windows.Forms;

namespace CineMagic
{
    public partial class LoadingScreenUI : Form
    {
        public LoadingScreenUI()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = true;
                progressBar1.Increment(1);

            }
            else
            {
                timer1.Enabled = false;
                CinMagicForm mainForm = new CinMagicForm();
                mainForm.Show();
                
                
            }
            this.Hide();

        }


        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
