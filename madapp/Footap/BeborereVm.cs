using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class BeborereVm 
    {
        public ObservableCollection<Beborere> Beboreres { get; set; }
        public string Name { get; set; }
        public int Alder { get; set; }
        public int HusNr01 { get; set; }
        public ObservableCollection<Hus> Huses { get; set; }
        public int ListHusNr { get; set; }



        public BeborereVm()
        {
            Beboreres = new ObservableCollection<Beborere>();
            Beboreres.Add(new Beborere("Jens", 22, 74));
            Huses = new ObservableCollection<Hus>();

        }

        //public int[] HusNrArray = new int[23]
        //{
        //     72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 102, 104, 106, 108, 110, 112, 114, 116
        //};

        public void mycode()
        {
            List<int> HusNr02 = new List<int>();
            HusNr02.Add(55);
        }
       
        
       

        //public int HusNr()
        //{
        //    for (int i = 0; i < HusNrArray.Length; i++)
        //    {
        //        return i;
        //    }
        ////    foreach (int Husnr in HusNrArray)
        ////    {
        ////        return Husnr;
        ////    }
        //}

        //public void Add()
        //{
        //    Beboreres.Add(new Beborere(Name, Alder, HusNr01));
        //}

        public void Remove()
        {
            foreach (Beborere beborere in Beboreres)
            {
                if (beborere.husNr == HusNr01)
                {
                    Beboreres.Remove(beborere);
                    return;
                } 
            }
        }
        //public override string ToString()
        //{
        //    for (int i = 0; i < HusNrArray.Length; i++)
        //    {
        //        HusNr01 = i;
                
        //    }
        //    return "HusNr {0}";
        //}
    }
}
