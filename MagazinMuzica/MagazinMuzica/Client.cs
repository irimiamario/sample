using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinMuzica
{
    public class Client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Client(string aNume, string aPrenume, string aAdresa, string aEmail, string aTelefon)
        {
            Nume = aNume;
            Prenume = aPrenume;
            Adresa = aAdresa;
            Email = aEmail;
            Telefon = aTelefon;
        }

        public virtual string[] listClientArray()
        {
            //We create here the list 
            string[] list = new string[6]; //Aici scriem cate elemente are list gen avem 3 momentan Id Type si Name
            list[0] = this.Nume;
            list[1] = this.Prenume;
            list[2] = this.Adresa;
            list[3] = this.Email;
            list[4] = this.Telefon;
            return list;
        }
    }
}
