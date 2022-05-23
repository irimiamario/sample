using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MagazinMuzica
{
    public partial class Muzica : Form
    {
        public Muzica()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlegereProdus alege = new AlegereProdus();
            alege.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void Muzica_Load(object sender, EventArgs e)
        {
            //aici am creat coloanele pt lista din Muzica
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Center);

            //aici am creat listview2
           
            listView2.Columns.Add("Nume",100, HorizontalAlignment.Center);
            listView2.Columns.Add("Prenume", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Adresa", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Email", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Telefon", 100, HorizontalAlignment.Center);

            //pentru fiecare produs de la Clasa Produse care se afla in ProduseFiltru in care luam cate o instanta noua cu tagul produseMagazin
            foreach (Produse produs in ProduseFiltru.Instance.produseMagazin)
            {
                //Console.WriteLine("\n" + produs.GetType().Name);

                //aici zicem produs.GetType luam tipul si in cazulnostru .Name si verificam daca e egal cu alea daca da adaugam in listview1
                if (produs.GetType().Name == "CD" || produs.GetType().Name == "Caseta")
                {
                    listView1.Items.Add(new ListViewItem(produs.listViewArray()));
                }
            }
            Client cliente = new Client(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString());
           





        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Refresh();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Client cliente = new Client(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString());
            //aici we create a save file from our editing
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true }) //aici zicem sa o salveze si ne apare un Box cu promt
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter write = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))//aici facem magia
                    {
                        foreach (ListViewItem item in listView1.Items) //aici zicem pt fiecare obiect din List View sa se faca ce e mai jos
                        {
                            await write.WriteLineAsync(item.SubItems[0].Text + "|" + item.SubItems[1].Text + "|" + item.SubItems[2].Text+ "|" + cliente.Nume + "|" + cliente.Prenume + "|" + cliente.Adresa + "|" + cliente.Email + "|" + cliente.Telefon); //aici am bagat sa scrie fiecare Item de il avem
                        }
                        MessageBox.Show("The order was made", "Order Recipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ReadFile()
        {

            var fileLines = File.ReadAllLines(@"C:\Users\Mario\Desktop\Magazin Muzica Alexa\MagazinMuzica\clienti.txt");
            foreach (string line in fileLines)
            {
                string[] prop = line.Split('|');
               
                
                ProduseFiltru.Instance.clientMagazin.Add(new Client(prop[3], prop[4], prop[5], prop[6],prop[7]));
                
            }

            //citesc din fisier si adaug citirea o fac in PrimaPagina_Load
            foreach (Client client in ProduseFiltru.Instance.clientMagazin)
            {
                //Console.WriteLine("\n" + produs.GetType().Name);

                
                
                    listView2.Items.Add(new ListViewItem(client.listClientArray()));
                
            }


           



        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadFile();
        }
    }
    
}
