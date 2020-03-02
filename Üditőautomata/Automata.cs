using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Üditőautomata
{
    class Automata
    {
        public string nev;
        public string tipus;
        public double meret;
        public int ar;
        public int maxmennyiseg;
        public int jelenlegimennyiseg;
        public string kod;

        public Automata(string sor)
        {
            var dbok = sor.Split(';');
            this.nev = dbok[0];
            this.tipus = dbok[1];
            this.meret = double.Parse(dbok[2]);
            this.ar = int.Parse(dbok[3]);
            this.maxmennyiseg = int.Parse(dbok[4]);
            this.jelenlegimennyiseg = int.Parse(dbok[5]);
            this.kod = dbok[6];

        }
    }
}
