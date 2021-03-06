﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class HusVm
    {
        public ObservableCollection<Hus> Huses { get; set; }
        public int HusNr { get; set; }

       
        public HusVm(ObservableCollection<Hus> huses, int[] husNrArray)
        {
            Huses = huses;
            HusNrArray = husNrArray;
        }

        int[] HusNrArray = new int[23]
       {
            72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 102, 104, 106, 108, 110, 112, 114, 116
       };

        public override string ToString()
        {
            return string.Format("HusNr {0}", HusNrArray);
        }
    }
}
