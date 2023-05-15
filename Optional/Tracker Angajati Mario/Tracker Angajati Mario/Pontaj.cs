using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    public class Pontaj
    {
        public string Proiect { get; set; }
        public string Timp { get; set; }
        public string Ziua { get; set; }
        public string Data { get; set; }
        public Pontaj(string aProiect, string aTimp, string aZiua, string aData)
        {
            Proiect = aProiect;
            Timp = aTimp;
            Ziua = aZiua;
            Data = aData;
        }

        public virtual string[] pontajArray()
        {
            
            string[] list = new string[4]; 
            list[0] = this.Proiect.ToString();
            list[1] = this.Timp.ToString();
            list[2] = this.Ziua.ToString();
            list[3] = this.Data.ToString();
            return list;
        }
    }
}
