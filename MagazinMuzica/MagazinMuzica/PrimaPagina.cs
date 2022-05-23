using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazinMuzica
{
    public partial class PrimaPagina : Form
    {
        public PrimaPagina()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide() ascunde formul curent
            //Aici apasam butonul Intra de pentru AdminLogin si avem un this.Hide care ne ascunde PrimaPagina 
            //Si mai cream un element pt AdminLogin login care il facem .Show sa ne arate formul 
            this.Hide(); 
            Adminlogin login = new Adminlogin();
            login.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //la fel si pt celalalt buton
            this.Hide();
            AlegereProdus alege = new AlegereProdus();
            alege.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
          
        }

        private void PrimaPagina_Load(object sender, EventArgs e)
        {
            //aici am facut o chestie ca sa avem listview ul intr un fel sortabil

            var fileLines = File.ReadAllLines(@"C:\Users\Mario\Desktop\Magazin Muzica Alexa\MagazinMuzica\produse.txt");
            foreach(string line in fileLines) {
                string[] prop = line.Split('|');
                if (prop[1] == "CD")
                {
                    ProduseFiltru.Instance.produseMagazin.Add(new CD(int.Parse(prop[0]), prop[1], prop[2]));
                }
                else if(prop[1] == "Caseta")
                {
                    ProduseFiltru.Instance.produseMagazin.Add(new Caseta(int.Parse(prop[0]), prop[1], prop[2]));

                }
                else if(prop[1]=="Instrument")
                {
                    ProduseFiltru.Instance.produseMagazin.Add(new Instrumente(int.Parse(prop[0]), prop[1], prop[2]));
                }
            }
        }
    }
}
