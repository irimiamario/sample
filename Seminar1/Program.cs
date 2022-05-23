using System;

namespace Seminar1
{
    class Program
    {
        static void Main(string[] args)
        {
            //nota la proiect -40% din nota finala, test - 20% , sesiunea de com 5%, participarea activa 35%
            //vreau nota finala
           // uint a, b, c, d;//numere naturale
            uint a, b, c, d;
            Console.WriteLine("Introduceti notele\n-proiect: ");
            if (!uint.TryParse(Console.ReadLine(), out a) || a > 10)
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("-test: ");
            if (!uint.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("-sesiune: ");
            if (!uint.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("-participare: ");
            if (!uint.TryParse(Console.ReadLine(), out d))
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }

            double nota = 0.4 * a + 0.2 * b + 0.05 * c + 0.35 * d;

            Console.WriteLine($"Nota obtinuta: {nota}");
            nota = Math.Round(nota);
            Console.WriteLine($"Nota rotunjita:{nota}");
            if (nota >= 5)
                Console.WriteLine("ai trecut");
            else
                Console.WriteLine("nu ai trecut");


            Console.ReadKey();





        }
    }
}
