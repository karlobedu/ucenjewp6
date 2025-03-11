using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E13Rekurzija
    {
        // Rekurzija je kada metoda zove samu sebe
        // UZ UVIJET PREKIDA REKURZIJE

        public static void Izvedi()
        {
            // Izvedi(); // Ovdje dobijemo Stack overflow https://stackoverflow.com/

            Console.WriteLine(Zbroji(100));

        }

        private static int Zbroji(int broj)
        {
            if (broj == 1)
            {
                return 1;
            }
            return broj + Zbroji(broj-1);
        }
        // 100 + 99 + 98 + 97 + ... + 1
    }
}
