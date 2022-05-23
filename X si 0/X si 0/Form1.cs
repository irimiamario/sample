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

namespace X_si_0
{
    public partial class Form1 : Form
    {
        public enum Jucator
        {
            X, O
        }

        Jucator jucatorcurent;
        List<Button> buttons;
        Random rand = new Random();
        int ScorJucator = 0;
        int ScorBot = 0;
    

        public Form1()
        {
            InitializeComponent();
            resetareRunda();
        }

        private void incarcarebutoane()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8 };
        }
        private void resetareRunda()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "joc")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).BackColor = default(Color);
                    ((Button)X).Text = "?";
                }
            }

            incarcarebutoane();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetareRunda();
        }


        private void UtilizatorClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            jucatorcurent = Jucator.X;
            button.Text = jucatorcurent.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.DarkRed;
            buttons.Remove(button);
            Verificare();
            timer1.Start();

        }

        private void RandBot(object sender, EventArgs e)
        {
            if (buttons.Count>0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                jucatorcurent = Jucator.O;
                buttons[index].BackColor = System.Drawing.Color.DarkGreen;
                buttons[index].Text = jucatorcurent.ToString();
                buttons.RemoveAt(index);
                Verificare();
                timer1.Stop();
            }
        }

   

        private void Verificare()

        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
)
            {
                timer1.Stop();
                MessageBox.Show("Utilizatorul a castigat!");
                ScorJucator++;
                label1.Text = "Scor Utilizator: " + ScorJucator;
                resetareRunda();
                
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
       
)
            {
                timer1.Stop();
                MessageBox.Show("Bot-ul a castigat!");
                ScorBot++;
                label2.Text = "Scor Bot: " + ScorBot;
                resetareRunda();
              

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TextWriter txt = new
            StreamWriter("C:\\scor_utilizator\\scor.txt");
            txt.Write(label1.Text);
            txt.Close();

        }
    }
}
