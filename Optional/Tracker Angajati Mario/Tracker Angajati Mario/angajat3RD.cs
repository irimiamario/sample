using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    public class angajat3RD : angajatiGeneral
    {
       public string Companie { get; set; }
       public string Perioada { get; set; }
       public angajat3RD (int aAngajatID, string aAngajatNume, string aAngajatPrenume, string aAngajatTip, string aPozitie, string aCompanie, string aPerioada) : base(aAngajatID, aAngajatNume, aAngajatPrenume, aAngajatTip, aPozitie)
        {
            Companie = aCompanie;
            Perioada = aPerioada;
        }
        public virtual string[] angajati3RDArray()
        {
            
            string[] list = new string[7];
            list[0] = this.AngajatID.ToString();
            list[1] = this.AngajatNume;
            list[2] = this.AngajatPrenume;
            list[3] = this.AngajatTip;
            list[4] = this.Pozitie;
            list[5] = this.Companie;
            list[6] = this.Perioada;
            return list;
        }
    }
}
