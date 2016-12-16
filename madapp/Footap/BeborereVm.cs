using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Footap.Annotations;

namespace Footap
{
    class BeborereVm : INotifyPropertyChanged
    {
        public ObservableCollection<Beborere> Beboreres { get; set; }
        public string Name { get; set; }
        public int Alder { get; set; }
        public int HusNr { get; set; }
        public ObservableCollection<Hus> Huses { get; set; }
        public int ListHusNr { get; set; }
        public int SelectedIndex { get; set; }

       
        

        public BeborereVm()
        {
            Huses = new ObservableCollection<Hus>();
            Beboreres = new ObservableCollection<Beborere>();
            Beboreres.Add(new Beborere("Jens", 22, 74));
          

        }

        //public int[] HusNrArray = new int[23]
        //{
        //     72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 102, 104, 106, 108, 110, 112, 114, 116
        //};

        //public void mycode()
        //{
        //    List<int> HusNr02 = new List<int>();
        //    HusNr02.Add(55);
        //}




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

        public void Add()
        {
            Beboreres.Add(new Beborere(Name, Alder, HusNr));
           
        }

        public void Remove()
        {
            

            
            if (SelectedIndex != null)
            {
                Beboreres.RemoveAt(SelectedIndex);
                OnPropertyChanged();
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
        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
