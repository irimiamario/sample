using System;

namespace Seminar1_Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 4 9 16 25 patrat perfect problema
            uint n;
            Console.WriteLine("n=");
            n = uint.Parse(Console.Read());
            double rad = Math.Sqrt(n);
            if (rad == (int)rad)
                Console.Write($"{n} este p.p; radacina este {rad}");
            else
                Console.Write($"{n} nu este p.p");
            Console.ReadKey(); 
        }
    }
} 
