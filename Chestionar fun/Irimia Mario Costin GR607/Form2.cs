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

namespace Irimia_Mario_Costin_GR607
{
    public partial class Form2 : Form
    {

        int raspunscorect;
        int qnumar = 1;
        int scor;
        int procent;
        int qtotal;



        public Form2()
        {
            InitializeComponent();
            intrebare(qnumar);
            qtotal = 8;

        }

        private void verificareraspuns(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int tagbuton = Convert.ToInt32(senderObject.Tag);

            if(tagbuton==raspunscorect)
            {
                scor++;
            }

            if(qnumar == qtotal)
            {
                procent = (int)Math.Round((double)(scor * 100) / qtotal);

                MessageBox.Show(
                    "Sfarsitul Testului! " + Environment.NewLine +
                    " Ai raspuns corect la " + scor + " intrebari." + Environment.NewLine + " Procentul tau de reusita este " + procent + "%" +
                    Environment.NewLine + " Apasa sa iti salvezi scorul!"
                    );
                scor = 0;
                qnumar = 0;
                intrebare(qnumar);

                File.AppendAllText("scor.txt", " " + procent + "% ");

                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
              qnumar++;
              intrebare(qnumar);
           
        }

        private void intrebare(int intrenr)
        {
            switch(intrenr)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.peaky;
                    q1.Text = "Ce TV Show este acesta?";
                    button1.Text = "Peaky Blinder";
                    button2.Text = "Mafia III";
                    button3.Text = "Gotham";
                    button4.Text = "Incredibles";

                    raspunscorect = 1;

                    break;
                case 2:

                    pictureBox1.Image = Properties.Resources.steamn;
                    q1.Text = "Ce companie detine sigla acesta?";
                    button1.Text = "Electronic Arts";
                    button2.Text = "Valve";
                    button3.Text = "Ubisoft";
                    button4.Text = "TakeTwo";

                    raspunscorect = 3;

                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.death;
                    q1.Text = "Ce TV Show este acesta?";
                    button1.Text = "No game no life";
                    button2.Text = "Infinity War";
                    button3.Text = "Among Us";
                    button4.Text = "Death Note";

                    raspunscorect = 4;

                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.valo;
                    q1.Text = "Ce joc video este acesta?";
                    button1.Text = "CS:GO";
                    button2.Text = "Valorant";
                    button3.Text = "Metro";
                    button4.Text = "Titan Fall";

                    raspunscorect = 2;

                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.star;
                    q1.Text = "Ce companie este acesta?";
                    button1.Text = "Starbucks";
                    button2.Text = "5TOGO";
                    button3.Text = "Tucanno";
                    button4.Text = "Cafea Premium Srl";

                    raspunscorect = 1;

                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.meta;
                    q1.Text = "Ce companie este acesta?";
                    button1.Text = "Facebook";
                    button2.Text = "Oculus";
                    button3.Text = "Instagram";
                    button4.Text = "Meta";

                    raspunscorect = 4;

                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources.mk;
                    q1.Text = "Ce personaj este acesta?";
                    button1.Text = "Donald Duck";
                    button2.Text = "Yagami Light";
                    button3.Text = "Mickey Mouse";
                    button4.Text = "Yagami Ligth";

                    raspunscorect = 3;

                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources.bf42;
                    q1.Text = "Ce joc video este acesta?";
                    button1.Text = "Battlefield 5";
                    button2.Text = "Battlefield 2042";
                    button3.Text = "Fifa 2021";
                    button4.Text = "Fifa 2022";

                    raspunscorect = 2;

                    break;
            }
        }
    }
}
