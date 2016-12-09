using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class Beborere : Hus
    {
        public int Alder { get; set; }
        public string Navn { get; set; }

        public Beborere(int alder, string navn, int husNr)
        {
            Alder = alder;
            Navn = navn;
            husNr = husNr;
        }
    }
}
