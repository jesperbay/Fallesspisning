using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class ListForOpgaverVm
    {
        public string Mandag { get; set; }
        public string Tirsdag { get; set; }
        public string Onsdag { get; set; }
        public string Torsdag { get; set; }
        public string Specialdag { get; set; }
        public string Name { get; set; }
        public string Opvasker { get; set; }
        public string HjaelpeKok { get; set; }

        public ListForOpgaverVm(string mandag, string tirsdag, string onsdag, string torsdag, string specialdag, string name, string opvasker, string hjaelpeKok)
        {
            Mandag = mandag;
            Tirsdag = tirsdag;
            Onsdag = onsdag;
            Torsdag = torsdag;
            Specialdag = specialdag;
            Name = name;
            Opvasker = opvasker;
            HjaelpeKok = hjaelpeKok;
        }
    }
}
