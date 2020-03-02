using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Üditőautomata
{
    class Program
    {
        static List<Automata> AutomataList;
        private static readonly object DateTima;
        private static readonly object yyyy;

        static void Main(string[] args)
        {
            Feladat01Beolvasas();
            Feladat02SzelsoErtekek();
            Feladat03Kapacitas();
            Feladat04Bevetel();
            Feladat0506Vasarlas();
            Feladat07Urtartalom();


            Console.ReadKey();
        }

        private static void Feladat07Urtartalom()
        {
            Console.WriteLine("\n7.Feladat");
            double pillanatnyiurtartalom = 0;
            double befogadourtartalom = 0;

            foreach (var k in AutomataList)
            {
                pillanatnyiurtartalom += k.jelenlegimennyiseg * k.meret;
                
                befogadourtartalom += k.maxmennyiseg * k.meret;
                
            }
            Console.WriteLine("\tPillanaytnyilag {0} l folyadék van a gépben", pillanatnyiurtartalom);
            Console.WriteLine("\tEnnyi {0} l folyadék fér a gépben", befogadourtartalom);
        }

        private static void Feladat0506Vasarlas()
        {
            Console.WriteLine("\n5.Feladat");
            string[] termeklista = new string[AutomataList.Count];
            for (int i = 0; i < AutomataList.Count; i++)
            {
                termeklista[i] = AutomataList[i].kod;
            }
            Array.Sort(termeklista);
            for (int i = 0; i < termeklista.Length; i++)
            {
                for (int j = 0; j < AutomataList.Count; j++)
                {
                    if (AutomataList[i].kod == termeklista[j]) Console.WriteLine("\t{0, -3}-{1, -20}-{2, -3} Ft",AutomataList[j].kod,AutomataList[j].nev, AutomataList[j].ar );
                }
            }
            Console.Write("\n\tKérem adja meg a termék kódját: ");
            string kulcs = Console.ReadLine();
            
            int szamlalo = 0;
            while(szamlalo<AutomataList.Count && kulcs!=AutomataList[szamlalo].kod)
            {
                szamlalo++;
            }
            if (szamlalo == AutomataList.Count)
            {
                Console.WriteLine("\tNincs ilyen termék a listán");
            }
            else
            {
              
                Console.WriteLine("\ta keresett termék neve: {0}", AutomataList[szamlalo].nev);

                if (kulcs == "F1" || kulcs == "F2" || kulcs == "F3")
                {
                    Console.Write("\tKérem adja meg az életorát(év.hónap.nap): ");
                    DateTime kor = DateTime.Parse(Console.ReadLine());
                    DateTime most = DateTime.Now;
                    DateTime hatar = DateTime.Now.AddYears(-16);
                    TimeSpan eletkor = most - kor;

                    if (kor < hatar)
                    {
                        Console.WriteLine("\tAz ön életkora több mint 16 év");
                        Console.Write("\tKérem dobjon be pénzt {0} Ft-ot :  ", AutomataList[szamlalo].ar);
                        int bedobottpenz = int.Parse(Console.ReadLine());
                        int visszajaro = 0;
                        visszajaro += bedobottpenz - AutomataList[szamlalo].ar;

                        if (visszajaro < 0)
                        {
                            Console.WriteLine("\tSajnos nem elég összeget dobott be");
                        }
                        if (visszajaro > 0)
                        {
                            Console.WriteLine("\tVisszajaró összeg: {0}Ft", visszajaro);
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tSajnos nem múlt el 16 éves nem vehet terméket. Kérem válasszon másikat ");
                    }
                }

                else
                {
                    Console.Write("\tKérem dobjon be pénzt {0} Ft-ot :  ", AutomataList[szamlalo].ar);
                    int bedobottpenz = int.Parse(Console.ReadLine());
                    int visszajaro2 = 0;
                    visszajaro2 =   bedobottpenz- AutomataList[szamlalo].ar;

                    if (visszajaro2 < 0)
                    {
                        Console.WriteLine("\tSajnos nem elég összeget dobott be");
                    }
                    if (visszajaro2 > 0)
                    {
                        Console.WriteLine("\tVisszajaró összeg: {0}Ft", visszajaro2);
                    }
                }
                
            }
        }

        private static void Feladat04Bevetel()
        {
            Console.WriteLine("\n4.Feladat");
            int bevetel = 0;
            int lehetsegesbevetel = 0;
            foreach (var a in AutomataList)
            {
                bevetel += a.jelenlegimennyiseg * a.ar;
                lehetsegesbevetel += a.maxmennyiseg * a.ar;
            }
            Console.WriteLine("\tPillanatnyilag ennyi van a gépben: {0} Ft", bevetel);
            Console.WriteLine("\tHa minden terméket eladnánk: {0} FT", lehetsegesbevetel);
        }

        private static void Feladat03Kapacitas()
        {
            Console.WriteLine("\n3.Feladat");
            int kapacitas = 0;
            foreach (var a in AutomataList)
            {
                kapacitas += a.maxmennyiseg;
            }
            Console.WriteLine("\tA gép kapacitása: {0} db", kapacitas);
        }

        private static void Feladat02SzelsoErtekek()
        {
            Console.WriteLine("\n2.Feladat");
            int maxar = int.MinValue;
            string maxnev = "cica";
            int minar = int.MaxValue;
            string minnev = "kutya";
            int sum = 0;
            int db = 0;
            double atlag = 0;
            foreach (var a in AutomataList)
            {
                if (maxar<a.ar)
                {
                    maxar = a.ar;
                    maxnev = a.nev;
                }
                if (minar>a.ar)
                {
                    minar = a.ar;
                    minnev = a.nev;
                }
                sum += a.ar;
                db++;
                atlag = (double)sum / (double)db;

            }
            Console.WriteLine("\tA legdrágább termék ára: {0} Ft - neve: {1}", maxar, maxnev);
            Console.WriteLine("\tA legdrágább termék ára: {0} Ft - neve: {1}", minar, minnev);
            Console.WriteLine("\tÁtlagosan ennyibe került egy üditő: {0, 0:0} FT", atlag);
        }

        private static void Feladat01Beolvasas()
        {
            AutomataList = new List<Automata>();
            var sr = new StreamReader(@"üdítőital.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                AutomataList.Add(new Automata(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
