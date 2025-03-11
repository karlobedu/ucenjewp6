using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{



    internal class E13Z2
    {

        public static void Izvedi()
        {
            Zad2();
        }

        // Zad 1. Program unosi ime i ispisuje koliko ime ima znakova
        private static void Zad1()
        {
            Console.WriteLine("Dobrodošli u 1. zadatak");
            string ime;
            while (true)
            {
                ime = E12Metode.UcitajString("Unesi ime osobe (NE za kraj): ");
                if (ime.ToUpper() == "NE")
                {
                    Console.WriteLine("Hvala na korištenju programa 1. zadatak!");
                    break;
                }
                Console.WriteLine(ime.Length);
            }

        }

        // Zad 2. Program unosi ime i prezime Osobe odvojeno. Progra ispisuje prezime i ime

        private static void Zad2()
        {
            string ime, prezime, jos;
            while (true) {
                ime = E12Metode.UcitajString("Unesi ime: ");
                prezime = E12Metode.UcitajString("Unesi prezime: ");
                Console.WriteLine("{0} {1}", prezime, ime);

                if(E12Metode.UcitajString("DA za još: ").ToUpper() != "DA")
                {
                    break;
                }
            }
           
        }
    }
}
