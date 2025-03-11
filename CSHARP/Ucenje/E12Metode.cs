using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E12Metode
    {

        /// <summary>
        /// Metoda za demonstraciju različitih tipova metoda
        /// </summary>
        
        public static void Izvedi()
        {
            // metode se sastoje od dva dijela
            // 1. Tijelo metode
            // 2. Poziv metode

            // poziv metode
            Tip1();
            Tip1();

            Tip2(7);
            Tip2(5);

            Tip2(10, "Poziv druge varijante metode Tip2");

            int i = Tip3() + 1;
            Console.WriteLine(i);

            int[] niz = { 2, 5, 2, 1, 4, 1, 2, 1, 4, 2, 3 };
            Console.WriteLine(Tip4(niz));

            // Metopda koja vraća vrijednost može biti pozvana i kao void metoda
            Tip4(niz); // ona će se izvesti ali njezin rezultat nema efekta u ovoj metodi

        }

        // Tijelo metode
        /// <summary>
        /// Metoda koja ne prima parametre i ne vraća vrijednost
        /// </summary>
        
        static void Tip1(/* Ovdje dođu parametri ili ne */) //void je oznaka da ne vraća vrijednost (praznina)
        {
            Console.WriteLine("Ispis iz 1. tipa metode");
            Console.WriteLine("***********************");
            Console.WriteLine("Kraj ispisa iz 1. tipa metode");
        }

        // Tip 2: Prima parametre ali ne vraća vrijednost
        /// <summary>
        /// Metoda koja prima jedan cijeli broj kao parametar i ispisuje brojeve od 0 do primljenog broja
        /// </summary>
        /// <param name="x">Cijeli broj do kojeg se ispisuju brojevi</param>
        
        private static void Tip2(int x) // x je parametar tipa int
        {
            for(int i= 0; i < x; i++)
            {
                Console.WriteLine(i);
            }
            
        }

        // potpis metode:
        // naziv + lista parametara
        /// <summary>
        /// Metoda koja prima cijeli broj i string kao parametre, ispisuje string i zatim brojeve od 0 do primljenog broja
        /// </summary>
        /// <param name="x">Cijeli broj do kojeg se ispisuju brojevi</param>
        /// <param name="naslov">String koji se ispisuje prije brojeva</param>
        // Method overloading
        private static void Tip2(int x, string naslov)
        {
            Console.WriteLine(naslov);
            Tip2(x);
        }

        // Tip 3: Ne prima parametre ali vraća vrijednost
        /// <summary>
        /// Metoda koja ne prima parametre i vraća maksimalnu vrijednost cijelog broja
        /// </summary>
        /// <returns>Maksimalna vrijednost cijelog broja</returns>
        private static int Tip3()
        {
            return int.MaxValue; // svaka metoda tipa koji nije void mora imati return
        }


        // Tip 4: Prima parametre i vraća vrijednost
        /// <summary>
        /// Metoda će za primljeni niz cijelih brojeva vratiti sumu
        /// </summary>
        /// <param name="niz">Niz cijelih brojeva</param>
        /// <returns>Suma primljenih brojeva</returns>
        private static int Tip4(int[] niz)
        {
            int suma = 0;
            foreach(int i in niz)
            {
                suma += i;
            }
            return suma;
        }



        // NAMA BITNE METODE
        // Write once, use everywhere
        /// <summary>
        /// Metoda za učitavanje cijelog broja od korisnika.
        /// </summary>
        /// <param name="poruka">Poruka koja se ispisuje korisniku.</param>
        /// <returns>Učitani cijeli broj.</returns>

        public static int UcitajCijeliBroj(string poruka)
        {

            while (true)
            {
                Console.Write(poruka);
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Problem kod učitanja broja!");                    
                }
            }


           // return 0; // kasnije obrisati
        }




        public static int UcitajCijeliBroj(string poruka, int min, int max)
        {
            int i;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if(i<min || i > max)
                    {
                        Console.WriteLine("Broj nije u danom rasponu {0} - {1}",min,max);
                        continue;
                    }
                    return i;
                }
                catch
                {
                    Console.WriteLine("Problem kod učitanja broja!");
                }
            }


            // return 0; // kasnije obrisati
        }






        public static string UcitajString(string poruka)
        {
            string s = "";
            while(true)
            {
                Console.Write(poruka);
                s = Console.ReadLine().Trim();
                if(s.Length == 0)
                {
                    Console.WriteLine("Obavezan unos");
                    continue;
                }
                return s;
            }

           // return "";
        }



        public static bool UcitajBool(string poruka, string uvjetZaTrue)
        {
            Console.Write(poruka);
            return Console.ReadLine().Trim().ToUpper()==uvjetZaTrue.ToUpper();
        }




    }
}
