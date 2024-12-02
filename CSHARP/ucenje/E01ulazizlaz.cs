using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucenje
{
    internal class E01ulazizlaz
    {

        public static void izvedi()
        {
            // Ovo je izlaz
            Console.Write("Unesi svoje ime: ");


            // Ulaz podataka u program
            string ime =Console.ReadLine();

            Console.WriteLine("Unijeli ste " + ime);

            // formatirani nacin ispisa
            Console.WriteLine("Unijeli ste {0}. Bravo!", ime);


        }


    }
}