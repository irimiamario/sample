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
    public partial class AngajatSelect : Form
    {
        public AngajatSelect()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            angajatIT angajatIT = new angajatIT();
            angajatIT.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            angajatiGenerali angajatiGenerali = new angajatiGenerali();
            angajatiGenerali.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            angajatiGeneral3RD angajatiGeneral3RD = new angajatiGeneral3RD();
            angajatiGeneral3RD.Show();
        }

        private void AngajatSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
