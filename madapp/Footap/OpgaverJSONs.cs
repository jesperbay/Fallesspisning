using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class OpgaverJSONs
    {
        public static List<Opgaverne> MandagsJob { get; set; }
        public static List<Opgaverne> TirsdagsJob { get; set; }
        public static List<Opgaverne> OnsdagsJob { get; set; }
        public static List<Opgaverne> TorsdagsJob { get; set; }

        public OpgaverJSONs(List<Opgaverne> mandagsJob, List<Opgaverne> tirsdagsJob, List<Opgaverne> onsdagsJob, List<Opgaverne> torsdagsJob)
        {
            MandagsJob = mandagsJob;
            TirsdagsJob = tirsdagsJob;
            OnsdagsJob = onsdagsJob;
            TorsdagsJob = torsdagsJob;
        }

        

    }
}
