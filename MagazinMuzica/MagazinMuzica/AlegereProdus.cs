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
    public partial class AlegereProdus : Form
    {
        public AlegereProdus()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrimaPagina prima = new PrimaPagina();
            prima.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstrumenteMuzicale instrumente = new InstrumenteMuzicale();
            instrumente.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Muzica muzica = new Muzica();  
            muzica.Show();
            this.Close();
        }
    }
}
