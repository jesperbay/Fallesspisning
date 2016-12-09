using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class Hus
    {
        public int husNr { get; set; }

        public Hus(int husNr)
        {
            this.husNr = husNr;
            int[] myHusArray = new int[23]
        {
            72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 102, 104, 106, 108, 110, 112, 114, 116
        };
            foreach (int i in myHusArray)
            {
                if (i == husNr)
                {
                   int logindHus = i; 
                }
                else
                {
                    string besked = "findes ikke";
                }
            }
        }

        public Hus()
        {
            
        }
       
        
       
        
        
    }
}
