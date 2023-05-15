using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    public class angajatiGeneral : Angajati
    {
        public string Pozitie { get; set; }
        public angajatiGeneral(int aAngajatID, string aAngajatNume, string aAngajatPrenume, string aAngajatTip , string aPozitie) : base(aAngajatID, aAngajatNume, aAngajatPrenume, aAngajatTip)
        {
            Pozitie = aPozitie;
        }
        public virtual string[] angajatiGeneraliArray()
        {
            string[] list = new string[5];
            list[0] = this.AngajatID.ToString();
            list[1] = this.AngajatNume;
            list[2] = this.AngajatPrenume;
            list[3] = this.AngajatTip;
            list[4] = this.Pozitie;
            return list;
        }
    }
}
