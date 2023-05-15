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
    public partial class angajatIT : Form
    {
        public angajatIT()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadFile();
        }
        private void ReadFile()
        {
           

            //START READING FROM FILE------------------------------------------------------------------------------------------------
            foreach (angajatiIT angajat in angajatiFiltru.Instance.angajatiIT)
            {



                listView1.Items.Add(new ListViewItem(angajat.angajatiITArray()));

            }
            //END READING FROM FILE------------------------------------------------------------------------------------------------------
        }

        private void ReadFilePontaj()
        {
            angajatiFiltru.Instance.pontajA.Clear(); // Clear the list
            listView2.Items.Clear(); // Clear the ListView
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "Tracker Angajati Mario", "pontaj.txt");
            var fileLines = File.ReadAllLines(filePath);
            foreach (string line in fileLines)
            {
                string[] prop = line.Split('|');

                angajatiFiltru.Instance.pontajA.Add(new Pontaj(prop[0], prop[1], prop[2], prop[3]));

            }

            foreach (Pontaj pontaj in angajatiFiltru.Instance.pontajA)
            {
                listView2.Items.Add(new ListViewItem(pontaj.pontajArray()));
            }
        }


        private void angajatIT_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Nume", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Prenume", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Angajat TIP", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Specializare", 100, HorizontalAlignment.Center);

            //listview 2 
            listView2.Columns.Add("Proiect", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Timp", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Ziua", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Data", 100, HorizontalAlignment.Center);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AngajatSelect angajatSelect = new AngajatSelect();
            angajatSelect.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReadFilePontaj();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter write = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (ListViewItem item in listView2.Items) //aici zicem pt fiecare obiect din List View sa se faca ce e mai jos
                        {
                            await write.WriteLineAsync(item.SubItems[0].Text + "|" + item.SubItems[1].Text + "|" + item.SubItems[2].Text + "|" + item.SubItems[3].Text + "|" + item.SubItems[4].Text ); //aici am bagat sa scrie fiecare Item de il avem
                        }
                        MessageBox.Show("The export was done", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void listAdd(string Proiect, string Timp, string Ziua, string Data)
        {
            

            ListViewItem everyrow = new ListViewItem();

           

            //START Adding to Angajati newangajat-------------------------------------------

            Pontaj newpontaj = new Pontaj("do", "do", "do", "do");
            newpontaj.Proiect = Proiect;
            newpontaj.Timp = Timp;
            newpontaj.Ziua = Ziua;
            newpontaj.Data = Data;

            //END Adding to Angajati newangajat-----------------------------------------------

            //START POPULATING LISTVIEW-------------------------------------------------------------------------------------

            ListViewItem.ListViewSubItem randProiect = new ListViewItem.ListViewSubItem(everyrow, newpontaj.Proiect);
            ListViewItem.ListViewSubItem randTimp = new ListViewItem.ListViewSubItem(everyrow, newpontaj.Timp);
            ListViewItem.ListViewSubItem randZiua = new ListViewItem.ListViewSubItem(everyrow, newpontaj.Ziua);
            ListViewItem.ListViewSubItem randData = new ListViewItem.ListViewSubItem(everyrow, newpontaj.Data);

            //END POPULATING LISTVIEW--------------------------------------------------------------------------------------------

            //START ADDING IN LIST----------------------------------------------------------------------------------------------

            everyrow.SubItems.Add(randProiect);
            everyrow.SubItems.Add(randTimp);
            everyrow.SubItems.Add(randZiua);
            everyrow.SubItems.Add(randData);
            listView2.Items.Add(everyrow);

            //END ADDING IN LIST---------------------------------------------------------------------------------------------------

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //START TO ADDING TO LIST FROM USER----------------------------------------------------------------------------------

            string proiect = textBox1.Text.ToString();
            string timp = textBox2.Text.ToString();
            string ziua = textBox3.Text.ToString();
            string data = textBox4.Text.ToString();
            int enteredId;
            bool isNumeric = int.TryParse(txtEmployeeId.Text, out enteredId);
            if (!isNumeric)
            {
                MessageBox.Show("Invalid ID angajat!", "Eroare ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var validEmployee = angajatiFiltru.Instance.angajatiIT.FirstOrDefault(emp => emp.AngajatID == enteredId);
            if (validEmployee == null)
            {
                MessageBox.Show("Invalid ID angajat!", "Eroare ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((proiect.Length > 1) && (timp.Length > 1) && (ziua.Length > 1) && (data.Length>1))
            {
                listAdd(proiect, timp, ziua, data);
            }
            else
            {
                MessageBox.Show("Text Box is empty\nPlease enter text ", "Text ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //END TO ADDING TO LIST FROM USER-------------------------------------------------------------------------------------------------------
        }
    }
}
