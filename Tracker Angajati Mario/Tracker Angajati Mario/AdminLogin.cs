using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pontaj_DLL;

namespace Tracker_Angajati_Mario
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //START HOMESCREEN BACK-----------------------------------------------

            this.Hide();
            HomeScreen home = new HomeScreen();
            home.Show();
            

            //END HOMESCREEN BACK-------------------------------------------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //START Validation login user paas is correct--------------------------------------------------------------------------------------------

            if (textBox1.Text == "ad" && textBox2.Text == "ad")
            {
                MessageBox.Show("Login succesfully", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                AdminEdit adminEdit = new AdminEdit();
                adminEdit.Show();
                
            }
            else
            {
                MessageBox.Show("Inccorect username/password\nTry Again", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //END Validation login user pass is correct--------------------------------------------------------------------------------------------
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
