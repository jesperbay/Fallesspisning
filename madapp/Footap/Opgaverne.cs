using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class Opgaverne
    {
        private string opgaver;
        private string job;

        public ObservableCollection<Opgaverne> Opgavernes { get; set; }
        
        public string Name { get; set; }
        public string Job { get; set; }
        public int Alder { get; set; }
        public int HusNr { get; set; }

        public Opgaverne(ObservableCollection<Opgaverne> opgavernes, string name, string job, int alder, int husNr)
        {
            Opgavernes = opgavernes;
            Name = name;
            Job = job;
            Alder = alder;
            HusNr = husNr;
        }

        public Opgaverne()
        {
            
        }

        public Opgaverne(string opgaver)
        {
            this.opgaver = opgaver;
        }

        public Opgaverne(string v, string job) : this(v)
        {
            this.job = job;
        }

        public Opgaverne(string v, string job, int alder, int husNr) : this(v, job)
        {
            this.Alder = alder;
            this.HusNr = husNr;
        }
    }
}
