using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_Angajati_Mario
{
    internal class angajatiFiltru
    {
        public static angajatiFiltru instance = null;
        public static angajatiFiltru Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new angajatiFiltru();
                }
                return instance;
            }
        }
        public List<Angajati> angajatiTot = new List<Angajati> { };
        public List<angajatiIT> angajatiIT = new List<angajatiIT> { };
        public List<angajatiGeneral> angajatiGeneral = new List<angajatiGeneral> { };
        public List<angajat3RD> angajati3RD = new List<angajat3RD> { };
        public List<Pontaj> pontajA = new List<Pontaj> { };
       
    }
}
