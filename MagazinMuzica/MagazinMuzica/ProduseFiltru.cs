using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinMuzica
{
    public class ProduseFiltru
    {
        public static ProduseFiltru instance = null;
        public static ProduseFiltru Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProduseFiltru();
                }
                return instance;
            }
        }
        public List<Produse> produseMagazin = new List<Produse> { };
        public List<Client> clientMagazin = new List<Client> { };
    }
}
