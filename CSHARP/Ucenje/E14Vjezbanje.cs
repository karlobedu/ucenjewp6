using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E14Vjezbanje
    {

        // 3. program: Za dani cijeli broj između 20 i 50 ispiši koja mu je vrijednost jedinice
        // 34 -> 4
        // 21 -> 1

        public static void Izvedi()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dobrodošli u vježbanje petkom");
            Console.ResetColor();
            Izbornik();
            Console.WriteLine("Hvala na korištenju, doviđenja");
        }

       


        private static void Izbornik()
        {

            string[] programi = { 
            "Parnost broja",
            "Tablica množenja",
            "Jedinična vrijednost",
            "Broj znakova naziva mjesta",
            "Zbroj znamenki broja",
            "Prebrojavanje broja znakova"
            };

            Console.WriteLine();
            Console.WriteLine("IZBORNIK");
            
            for(int i = 0; i < programi.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, programi[i]);
            }

            Console.WriteLine("0. Izlaz iz programa");
            OdabirOpcijeIzbornika(programi.Length);
        }

        private static void OdabirOpcijeIzbornika(int brojPrograma)
        {
            switch(E12Metode.UcitajCijeliBroj("Odaberi stavku izbornika: ",0, brojPrograma))
            {
                case 0:
                    break;
                case 1:
                    ParnostBroja();
                    Izbornik();
                    break;
                case 2:
                    TablicaMnozenja();
                    Izbornik();
                    break;
                case 3:
                    JedinicnaVrijednost();
                    Izbornik();
                    break;
                case 4:
                    BrojZnakovaNazivaMjesta();
                    Izbornik();
                    break;
                case 5:
                    ZbrojZnamenkiBroja();
                    Izbornik();
                    break;
                case 6:
                    PrebrojavanjeBrojaZnakova();
                    Izbornik();
                    break;
            }
        }

        private static void PrebrojavanjeBrojaZnakova()
        {
            NaslovPrograma("Prezrojavanje znakova u izrazu");

            string izraz = E12Metode.UcitajString("Unesi izraz: ").ToLower();

            // Danas pada snijeg --> vanjska petlja
            // Danas pada snijeg -> unutarnja petlja
            int[] niz = new int[izraz.Length];
            bool[] ispisi = new bool[izraz.Length]; // njegove sve vrijednosti su false
            int b;
            for(int i=0;i<izraz.Length;i++)
            {
                b = 0;
                foreach(char c in izraz)
                {
                    if (izraz[i] == c)
                    {
                        b++;
                    }
                }
                niz[i]= b;
                // ako je b>1 tada treba na SAMO prvo pojavljivanje tog slova staviti true
                if (b > 1)
                {
                    for(int j = 0; j < izraz.Length; j++)
                    {
                        if (izraz[i] == izraz[j])
                        {
                            ispisi[j] = true;
                            break;
                        }
                    }
                }
                // inače na to slovo stavi true
                else
                {
                    ispisi[i] = true;
                }
            }
            //Console.WriteLine(string.Join(",",ispisi));
            for(int i = 0; i < izraz.Length; i++)
            {
                if (ispisi[i] && izraz[i]!=' ')
                {
                    Console.Write("{0} ({1}) ", izraz[i], niz[i]);
                }
                
            }
            Console.WriteLine();

        }

        private static void ZbrojZnamenkiBroja()
        {
            NaslovPrograma("Zbroj znamenki broja");
            string broj = E12Metode.UcitajString("Unesi cijeli broj: ");
            int manjiOd = E12Metode.UcitajCijeliBroj("Zbroj mora biti manji od: ");

            if (!provjeraBrojaURedu(broj))
            {
                Console.WriteLine("Nije dobar broj");
                return; // short cuircuitng
            }

            // mi smo sada sigurni da u našem stringu broj postoje samo znakovi koji su brojevi

            // ulaz broj: 32472365354523523676576576576563423422 - string
            // 168, rez varijabla int -> prebaziti u string
            // 15
            // 6

            int rez = int.MaxValue; // mogao sam ići i s 10 (bolje je ne koristiti konstante)
            while (rez > manjiOd)
            {
                rez = 0; //(int)BigInteger.Zero;
                foreach(char c in broj)
                {
                    rez += int.Parse(c.ToString());
                }
                Console.WriteLine(rez);
                broj = rez.ToString();
            }

            Console.WriteLine(rez);



        }

        private static bool provjeraBrojaURedu(string broj)
        {
            foreach(char z in broj){
                try
                {
                    int.Parse(z.ToString());
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private static void BrojZnakovaNazivaMjesta()
        {
            NaslovPrograma("Za uneseni naziv mjesta ispisuje koliko ima znakova");

            Console.WriteLine(E12Metode.UcitajString("Unesi ime grada: ").Length);
        }

        private static void JedinicnaVrijednost()
        {
            NaslovPrograma("Jedinična vrijednost");
            int broj = E12Metode.UcitajCijeliBroj("Unesi broj između 20 i 50: ", 20, 50);
            Console.WriteLine(broj%10);
        }

        private static void TablicaMnozenja()
        {
            NaslovPrograma("Program koji za dane brojeve redaka i stupaca generira tablicu množenja");
            int redaka = E12Metode.UcitajCijeliBroj("Unesi broj redaka: ", 2, 10);
            int stupaca = E12Metode.UcitajCijeliBroj("Unesi broj stupaca: ", 2, 10);

            for(int i=1; i<=redaka; i++)
            {
                for(int j=1; j<=stupaca; j++)
                {
                    Console.Write("{0,4}",i*j);
                }
                Console.WriteLine();
            }

        }

        private static void ParnostBroja()
        {
            NaslovPrograma("Program koji provjerava da li je uneseni broj paran ili ne");
            int broj = E12Metode.UcitajCijeliBroj("Unesi cijeli broj: ");
            if(broj%2== 0)
            {
                Console.WriteLine("Uneseni broj {0} je PARAN",broj);
            }
            else
            {
                Console.WriteLine("Uneseni broj {0} je NEPARAN", broj);
            }
        }

        private static void NaslovPrograma(string naslov)
        {
            NaglasiNaslov(naslov.Length);
            Console.WriteLine(naslov);
            NaglasiNaslov(naslov.Length);
        }

        private static void NaglasiNaslov(int komada)
        {
            for (int i = 0; i < komada; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
