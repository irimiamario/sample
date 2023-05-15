using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    public class angajatiIT : Angajati
    { string Specializare { get; set; }
        public angajatiIT(int aAngajatID, string aAngajatNume, string aAngajatPrenume, string aAngajatTip, string aSpecializare) : base(aAngajatID, aAngajatNume, aAngajatPrenume, aAngajatTip)
        {
            Specializare = aSpecializare;
        }

        public virtual string [] angajatiITArray()
        {
            
            string[] list = new string[5];
            list[0] = this.AngajatID.ToString();
            list[1] = this.AngajatNume;
            list[2] = this.AngajatPrenume;
            list[3] = this.AngajatTip;
            list[4] = this.Specializare;
            return list;
        }
    }
}
