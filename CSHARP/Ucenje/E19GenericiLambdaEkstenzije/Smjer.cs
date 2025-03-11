using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.E19GenericiLambdaEkstenzije
{
    public class Smjer:Entitet,ISucelje,IComparable<Smjer>
    {
        public string? Naziv { get; set; }

        public int CompareTo(Smjer? other)
        {
            return Naziv.CompareTo(other?.Naziv);
        }

        public void OdradiPosao()
        {
            // kasnije ću. NIKAD NEĆEŠ i to ima svoj naziv technical debt https://www.productplan.com/glossary/technical-debt/
        }

        // atributi služe za definiranje dodatnih podataka trećoj strani https://mbarkt3sto.hashnode.dev/deprecation-in-c
        [Obsolete("Ova metoda je depricated")]
        public string StariNaziv()
        {
            return Naziv + " stari " ?? "";
        }

        public override string ToString()
        {
            return Naziv ?? "";
        }

    }
}
