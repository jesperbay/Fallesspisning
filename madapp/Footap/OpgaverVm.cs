using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Footap.Annotations;

namespace Footap
{
        class OpgaverVm : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Alder { get; set; }
        public int HusNr { get; set; }
        public ObservableCollection<Opgaver> Opgavers { get; set; }
        public int SelectedIndex { get; set; }
        

        public RelayOpgaver AddRelayOpgaver { get; set; }
        public RelayOpgaver RemoRelayOpgaver { get; set; }
        public RelayOpgaver GetRelayOpgaver { get; set; }
        public RelayOpgaver SaveRelayOpgaver { get; set; }

        public OpgaverVm()
        {
            
        }


        public OpgaverVm(string name, string job, int alder, int husNr, int selectedIndex)
        {
            Name = name;
            Job = job;
            Alder = alder;
            HusNr = husNr;
            SelectedIndex = selectedIndex;
            
            AddRelayOpgaver = new RelayOpgaver(Add);
            RemoRelayOpgaver = new RelayOpgaver(Remove);
            GetRelayOpgaver = new RelayOpgaver(LoadOpgavers);
            SaveRelayOpgaver = new RelayOpgaver(SaveOpgavers);
            Opgavers = new ObservableCollection<Opgaver>();
        }
        //    public string Name { get; set; }
        //    public string Job { get; set; }
        //    public ObservableCollection<Opgaver> Opgavers { get; set; }
        //    public int Alder { get; set; }
        //    public int HusNr { get; set; }
        //    public int SelectedIndex { get; set; }

        //    public RelayOpgaver AddOpgaverCommand { get; set; }
        //    public RelayOpgaver RemoveOpgaverCommand { get; set; }
        //    public RelayOpgaver GetOpgaverCommand { get; set; }
        //    public RelayOpgaver SaveOpgaverCommand { get; set; }


        //    //public OpgaverVm()
        //    //{
        //    //    Opgavernes = new ObservableCollection<Opgavers>();
        //    //    Opgavernes.Add(new Opgaverne("Chefkok"));
        //    //    Opgavernes.Add(new Opgaverne("Kok"));
        //    //    Opgavernes.Add(new Opgaverne("opvasker"));
        //    //    Name = "opgaver";
        //    //    Opgavernes.Add(new Opgaverne(Job));
        //    //}
        //    public OpgaverVm(string name, string job, int alder, int husNr, int selectedIndex)
        //    {
        //        Name = name;
        //        Job = job;
        //        Alder = alder;
        //        HusNr = husNr;
        //        SelectedIndex = selectedIndex;
        //        AddOpgaverCommand = new RelayOpgaver(Add);
        //        RemoveOpgaverCommand = new RelayOpgaver(Remove);
        //        GetOpgaverCommand = new RelayOpgaver(LoadOpgavers);
        //        SaveOpgaverCommand = new RelayOpgaver(SaveOpgavers);
        //        Opgavers = new ObservableCollection<Opgaver>();
        //    }


        private async void LoadOpgavers()
        {
            var Opgaverss = await PersistencyServiceOpgaver.LoadOpgaverFromJsonAsync();
            if (Opgaverss != null)
            {
                //Beboreres.Clear();
                foreach (var Opgaver in Opgaverss)
                {
                    Opgavers.Add(Opgaver);

                }

            }

        }

        public void Add()
        {
            Opgavers.Add(new Opgaver(Name, Job, Alder, HusNr));
            MySpiseDageList.Add(new OpgaverDage());
            
            //Opgavers.Add(new Opgaver(Name, Job, Alder, HusNr));

        }
        


        public void Remove()
        {



            if (SelectedIndex != null)
            {
                Opgavers.RemoveAt(SelectedIndex);
                OnPropertyChanged();
            }
}


        private async void SaveOpgavers()
        {
            PersistencyServiceOpgaver.SaveNotesAsJsonAsync(Opgavers);

        }

      public List<OpgaverDage> MySpiseDageList = new List<OpgaverDage>();
      public OpgaverDage Mandag = new OpgaverDage();
      public  OpgaverDage Tirsdag = new OpgaverDage();
      public OpgaverDage Onsdag= new OpgaverDage();
      public  OpgaverDage Torsdag = new OpgaverDage();
      public OpgaverDage Specialdag = new OpgaverDage();
      public OpgaverDage Name1 = new OpgaverDage();
      public OpgaverDage Opvasker = new OpgaverDage();
      public  OpgaverDage HjaelpeKok = new OpgaverDage();
        public void DageOpgaver()
        {
            MySpiseDageList = new List<OpgaverDage>();
        }

        public class OpgaverDage
       {
            
        public string Mandag { get; set; }
        public string Tirsdag { get; set; }
        public string Onsdag { get; set; }
        public string Torsdag { get; set; }
        public string Specialdag { get; set; }
        public string Name { get; set; }
        public string Opvasker { get; set; }
        public string HjaelpeKok { get; set; }
           
        }





        //public void Add(string name, string job)
        //{
        //    Opgavernes.Add(new Opgaverne(name, job));
        //}


        #region MyRegion
        public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 
    #endregion
}

  
}
