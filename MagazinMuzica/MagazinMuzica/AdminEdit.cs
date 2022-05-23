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
    public partial class AdminEdit : Form
    {   //pt a ne contoriza si a ne da un id pt fiecare element din lista
        private int autoID = 1;
        public AdminEdit()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                //aici ne intoarcem la prima pagina
                this.Close();
                PrimaPagina prima = new PrimaPagina();
                prima.Show();
            }
        }

        private void AdminEdit_Load(object sender, EventArgs e)
        {   
            //aici we create coloanele si le configuram cu spatiu si alignment
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Center);

        }

        private void addTolist (string prodname, string prodtype )
        {   //cream nou item cu id ul auto 
            ListViewItem eachrow = new ListViewItem("" + autoID);

            //Pentru clasa adaugam acele string prodname si prodtype sa fie trecute prin clasa noastra Produse
            Produse newprodus = new Produse(1, string.Empty, string.Empty);
            newprodus.ProductType = prodtype;
            newprodus.ProductName = prodname;
            //pentru  clasa

            //aici populam clasa pentru lista
            ListViewItem.ListViewSubItem rowType = new ListViewItem.ListViewSubItem(eachrow, newprodus.ProductType);
            ListViewItem.ListViewSubItem rowName = new ListViewItem.ListViewSubItem(eachrow, newprodus.ProductName);

            //aici adaugam in lista 
            eachrow.SubItems.Add(rowType);
            eachrow.SubItems.Add(rowName);
            listView1.Items.Add(eachrow);

            //ne da id ul itemului
            this.autoID++;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //am apasat din greseala ignora imi e ca daca sterg se distruge programul
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //aici am facut ca atunci cand scrii in casute si apesi pe adaugare sa ti adauge in lista ce ai scris si daca nu merge ai un mesaj de eroare
            string prodName1 = textBox2.Text.ToString();
            string prodtype1 = textBox3.Text.ToString();

            if ((prodName1.Length>1)&&(prodtype1.Length>1))
            {
                addTolist(prodName1, prodtype1);
            }
            else
            {
                MessageBox.Show("Please enter text","Text ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aici am facut ca atunci cand apesi pe un item din lista sa mi scrie in casutele respective Id ul Name ul etc
            textBox1.Text = listView1.FocusedItem.SubItems[0].Text;
            textBox2.Text = listView1.FocusedItem.SubItems[1].Text;
            textBox3.Text = listView1.FocusedItem.SubItems[2].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //aici editam itemele 
            int id = int.Parse(textBox1.Text);
            int index = id - 1;

            listView1.Items[index].SubItems[1].Text = textBox2.Text;
            listView1.Items[index].SubItems[2].Text = textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //aici stergem itemele si am adaugat un check ne apare un MessageBox cu Da sau Nu si daca ii dam da ne sterge ala (vezi ca da eroare daca o faci de multe ori)
            int id = int.Parse(textBox1.Text);
            int index = id - 1;

            if(MessageBox.Show("Are you sure you want to delete?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                listView1.Items[index].Remove(); 
                
            }
        }



        private void ReadFile()
        {
            //citesc din fisier si adaug citirea o fac in PrimaPagina_Load
            foreach (Produse produs in ProduseFiltru.Instance.produseMagazin)
            {
                //Console.WriteLine("\n" + produs.GetType().Name);

                if (produs.GetType().Name == "Instrumente" || produs.GetType().Name == "CD" || produs.GetType().Name == "Caseta")
                {
                    listView1.Items.Add(new ListViewItem(produs.listViewArray()));
                }
            }
        }
   

        private void button6_Click(object sender, EventArgs e)
        {   //Aici apelam functia scris mai jos de ReadFile
            ReadFile();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //aici we create a save file from our editing
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true }) //aici zicem sa o salveze si ne apare un Box cu promt
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter write = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))//aici facem magia
                    {
                        foreach (ListViewItem item in listView1.Items) //aici zicem pt fiecare obiect din List View sa se faca ce e mai jos
                        {
                            await write.WriteLineAsync(item.SubItems[0].Text + "|" + item.SubItems[1].Text + "|" + item.SubItems[2].Text); //aici am bagat sa scrie fiecare Item de il avem
                        }
                        MessageBox.Show("The export was done", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }





}

