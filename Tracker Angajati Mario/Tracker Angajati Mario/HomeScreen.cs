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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //START ADMIN LOGIN BUTTON SHOW-----------------------------------------------------------------------

            this.Hide();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();

            //END ADMIN LOGIN BUTTON SHOW CODE---------------------------------------------------------------------
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //START ANGAJAT BUTTON SHOW-----------------------------------------------------------------------------

            this.Hide();
            AngajatSelect angajatSelect = new AngajatSelect();
            angajatSelect.Show();

            //END ANGAJAT BUTTON SHOW--------------------------------------------------------------------------------

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            //START LISTVIEW POPULATE

            var fileLines = File.ReadAllLines(@"C:\Users\Mario\Desktop\Proiect C# Mario\Tracker Angajati Mario\angajati.txt");
            foreach (string line in fileLines)
            {
                string[] pro = line.Split('|');
                if (pro[3] == "IT")
                {
                    angajatiFiltru.Instance.angajatiTot.Add(new angajatiIT(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4]));
                    angajatiFiltru.Instance.angajatiIT.Add(new angajatiIT(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4]));
                }
                else if (pro[3] == "Angajat General")
                {
                    angajatiFiltru.Instance.angajatiTot.Add(new angajatiGeneral(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4]));
                    angajatiFiltru.Instance.angajatiGeneral.Add(new angajatiGeneral(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4]));
                }
                else if (pro[3] == "Angajat 3rd")
                {
                    angajatiFiltru.Instance.angajatiTot.Add(new angajat3RD(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4], pro[5], pro[6]));
                    angajatiFiltru.Instance.angajati3RD.Add(new angajat3RD(int.Parse(pro[0]), pro[1], pro[2], pro[3], pro[4], pro[5], pro[6]));
                }
            }

            //END LISTVIEW POPULATE
        }
    }
}
