using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinMuzica
{
    public class Produse
    {
       public int ProductId { get; set; }
       public string ProductType { get; set; }
       public string ProductName { get; set; }
       
       public Produse (int aProductID, string aProductType, string aProductName)
        {
            ProductId = aProductID;
            ProductType = aProductType;
            ProductName = aProductName;
        }

        public virtual string[] listViewArray()
        {
            //We create here the list 
            string[] list = new string[3]; //Aici scriem cate elemente are list gen avem 3 momentan Id Type si Name
            list[0] = this.ProductId.ToString(); //aici convertim cifrele de la ID la String pt a crea lista
            list[1] = this.ProductType;
            list[2] = this.ProductName;
            return list;
        }

        //public virtual Caracteristici(string caracteristici)
        //{
            
    }
}
