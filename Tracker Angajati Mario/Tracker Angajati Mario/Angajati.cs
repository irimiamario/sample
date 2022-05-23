using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    public class Angajati
    {
        public int AngajatID { get; set; }
        public string AngajatNume { get; set; }
        public string AngajatPrenume { get; set; }

        public string AngajatTip { get; set; }

        public Angajati (int aAngajatID, string aAngajatNume, string aAngajatPrenume, string aAngajatTip)
        {
            AngajatID = aAngajatID;
            AngajatNume = aAngajatNume;
            AngajatPrenume = aAngajatPrenume;
            AngajatTip = aAngajatTip;
        }

       

        public virtual string [] angajatiArray()
        {
            string [] list = new string [4];
            list[0] = this.AngajatID.ToString();
            list[1] = this.AngajatNume;
            list[2] = this.AngajatPrenume;
            list[3] = this.AngajatTip;
            return list;
        }

    }
}
