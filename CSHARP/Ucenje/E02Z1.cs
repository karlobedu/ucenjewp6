using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{

    // Napišite program koji unosi ime i broj godina

    // Program isposuje: Osoba XXXXXX ima YY godina.

    internal class E02Z1
    {

        public static void Izvedi()
        {

            //ovdje se piše rješenje podataka
            Console.Write("Unesi ime: ");
            string ime = Console.ReadLine();
            Console.Write("Unesi broj godina (cijeli broj): ");
            int godine = int.Parse(Console.ReadLine());

            Console.WriteLine("Osoba {0} ima {1} godina.", ime, godine);
        }

    }
}
