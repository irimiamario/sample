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
using Pontaj_DLL;

namespace Tracker_Angajati_Mario
{
    public partial class AdminEdit : Form
    {
        //START ID angajat automat pt fiecare new list view item-------------------------

        private int angajatID = 1;

        //END ID angajat automat pt fiecare new list view item-------------------------

        public AdminEdit()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //START BACK HOMESCREEN--------------------------------------

            this.Hide();
            HomeScreen home = new HomeScreen();
            home.Show();
            
            //END BACK HOMESCREEN-----------------------------------------
        }

        private void AdminEdit_Load(object sender, EventArgs e)
        {
            //START LISTVIEW1 CREATE COL CONFIG------------------------------------------

            listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Nume", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Prenume", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Angajat TIP", 150, HorizontalAlignment.Center);

            //END LISTVIEW1 CREATE COL CONFIG-----------------------------------------------

           
        }

        //START CREATE FUNCTION TO ADD TO LISTVIEW1---------------------------------------------
        private void listAdd (string angajatNume, string angajatPrenume, string angajatTip)
        {
            //START NEW ITEM CU angajatID auto-------------------------------------------

            ListViewItem everyrow = new ListViewItem("" + angajatID);

            //END NEW ITEM CU angajatID auto----------------------------------------------

            //START Adding to Angajati newangajat-------------------------------------------

            Angajati newangajat = new Angajati(1, "do", "do", "do");
            newangajat.AngajatNume = angajatNume;
            newangajat.AngajatPrenume = angajatPrenume;
            newangajat.AngajatTip = angajatTip;

            //END Adding to Angajati newangajat-----------------------------------------------

            //START POPULATING LISTVIEW-------------------------------------------------------------------------------------

            ListViewItem.ListViewSubItem randNume = new ListViewItem.ListViewSubItem(everyrow, newangajat.AngajatNume);
            ListViewItem.ListViewSubItem randPrenume = new ListViewItem.ListViewSubItem(everyrow, newangajat.AngajatPrenume);
            ListViewItem.ListViewSubItem randTip = new ListViewItem.ListViewSubItem(everyrow, newangajat.AngajatTip);

            //END POPULATING LISTVIEW--------------------------------------------------------------------------------------------

            //START ADDING IN LIST----------------------------------------------------------------------------------------------

            everyrow.SubItems.Add(randNume);
            everyrow.SubItems.Add(randPrenume);
            everyrow.SubItems.Add(randTip);
            listView1.Items.Add(everyrow);

            //END ADDING IN LIST---------------------------------------------------------------------------------------------------

            this.angajatID++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //START TO ADDING TO LIST FROM USER----------------------------------------------------------------------------------

            string angajatNume1 = textBox2.Text.ToString();
            string angajatPrenume1 = textBox3.Text.ToString();
            string angajatTip1 = textBox4.Text.ToString();

            if ((angajatNume1.Length > 1) && (angajatPrenume1.Length > 1) && (angajatTip1.Length>1))
            {
                listAdd(angajatNume1, angajatPrenume1, angajatTip1);
            }
            else
            {
                MessageBox.Show("Text Box is empty\nPlease enter text ", "Text ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //END TO ADDING TO LIST FROM USER-------------------------------------------------------------------------------------------------------
        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listView1.FocusedItem.SubItems[0].Text;
            textBox2.Text = listView1.FocusedItem.SubItems[1].Text;
            textBox3.Text = listView1.FocusedItem.SubItems[2].Text;
            textBox4.Text = listView1.FocusedItem.SubItems[3].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            int index = id - 1;

            listView1.Items[index].SubItems[1].Text = textBox2.Text;
            listView1.Items[index].SubItems[2].Text = textBox3.Text;
            listView1.Items[index].SubItems[3].Text = textBox4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            int index = id - 1;

            if (MessageBox.Show("Are you sure you want to delete?", "Delete record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                listView1.Items[index].Remove();

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //aici we create a save file from our editing
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true }) 
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter write = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (ListViewItem item in listView1.Items) //aici zicem pt fiecare obiect din List View sa se faca ce e mai jos
                        {
                            await write.WriteLineAsync(item.SubItems[0].Text + "|" + item.SubItems[1].Text + "|" + item.SubItems[2].Text + "|" + item.SubItems[3].Text); //aici am bagat sa scrie fiecare Item de il avem
                        }
                        MessageBox.Show("The export was done", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ReadFile()
        {
           
            //START READING FROM FILE------------------------------------------------------------------------------------------------
            foreach (Angajati angajat in angajatiFiltru.Instance.angajatiTot)
            {
               

                
                    listView1.Items.Add(new ListViewItem(angajat.angajatiArray()));
                
            }
            //END READING FROM FILE------------------------------------------------------------------------------------------------------
        }
    }
}
