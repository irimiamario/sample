using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinMuzica
{
    internal class Instrumente : Produse
    {
        public Instrumente(int aProductID, string aProductType, string aProductName) : base(aProductID, aProductType, aProductName)
        {
        }
    }
}
