using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E18NasljedivanjePolimorfizam
{
    // Apstrakna klasa je ona klasa koja ne može imati instancu
    // služi tome da sadržava zajednička svojstva i metode te da ju netko nasljedi
    public abstract class Entitet : Object // čitati https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-9.0#methods
    {
        public int Sifra { get; set; }

        public override string ToString()
        {
            return Sifra.ToString();
        }

    }
}
