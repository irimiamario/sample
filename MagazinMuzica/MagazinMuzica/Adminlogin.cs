using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazinMuzica
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Aici am facut pentru butonul de PRIMA PAGINA sa ne inchida AdminLogin si sa ne arate Prima Pagina
            PrimaPagina primapag = new PrimaPagina();
            primapag.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Aici verific daca username si password sunt bune si afisez cu MessageBox.Show un box care sa scrie ce e acolo si are un buton de ok si un semnul exclamarii ca icon
            //si am mai adaugat daca e true if ul sa ne arate AdminEdit
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {   
                MessageBox.Show("Login was succesfull","Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                AdminEdit edit = new AdminEdit();
                edit.Show();
            }
            else
            {
                MessageBox.Show("The username and password were inccorect","Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
    }
}
