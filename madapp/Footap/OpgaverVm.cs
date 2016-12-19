using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        public int MandagJob { get; set; }
        public int TirsdagJob { get; set; }
        public int OnsdagJob { get; set; }
        public int TorsdagJob { get; set; }
        public ObservableCollection<Opgaver> Opgavers { get; set; }
        public int SelectedIndex { get; set; }

        public List<Opgaverne> OpgaverneMandag { get; set; }
        public List<Opgaverne> OpgaverneTirsdag { get; set; }
        public List<Opgaverne> OpgaverneOnsdag { get; set; }
        public List<Opgaverne> OpgaverneTorsdag { get; set; }
        

        public RelayOpgaver AddRelayOpgaver { get; set; }
        public RelayOpgaver RemoRelayOpgaver { get; set; }
        public RelayOpgaver GetRelayOpgaver { get; set; }
        public RelayOpgaver SaveRelayOpgaver { get; set; }

        public OpgaverVm()
        {
            GetRelayOpgaver = new RelayOpgaver(LoadOpgavers);
            SaveRelayOpgaver = new RelayOpgaver(SaveOpgavers);
            OpgaverneMandag = new List<Opgaverne>();
            OpgaverneTirsdag = new List<Opgaverne>();
            OpgaverneOnsdag = new List<Opgaverne>();
            OpgaverneTorsdag = new List<Opgaverne>();
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

       

        public void TilmeldOpgaverKnap()
        {
            LoadOpgavers();
            Add();
            SaveOpgavers();
        }
        private async void SaveOpgavers()
        {
            OpgaverJSONs ugeJobs = new OpgaverJSONs(OpgaverneMandag, OpgaverneTirsdag, OpgaverneOnsdag, OpgaverneTorsdag);
            PersistencyServiceOpgaver.SaveNotesAsJsonAsync(ugeJobs);
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

            await Task.Delay(1000);
            var OpgaverJson = await PersistencyServiceOpgaver.LoadOpgaverFromJsonAsync();
            if (OpgaverJson != null)

                OpgaverneMandag.Clear();

            foreach (var opg in OpgaverJSONs.MandagsJob)
            {
                OpgaverneMandag.Add(opg);
            }

            OpgaverneTirsdag.Clear();

            foreach (var opg in OpgaverJSONs.TirsdagsJob)
            {
               OpgaverneTirsdag.Add(opg); 
            }

            OpgaverneOnsdag.Clear();

            foreach (var opg in OpgaverJSONs.OnsdagsJob)
            {
                OpgaverneOnsdag.Add(opg);
            }

            OpgaverneTorsdag.Clear();

            foreach (var opg in OpgaverJSONs.TorsdagsJob)
            {
                OpgaverneTorsdag.Add(opg);
            }
            await Task.Delay(1000);

        }

        public void Add()
        {
           
           
            OpgaverneMandag.Add(new Opgaverne(Name, Job, Alder, HusNr));
            OpgaverneTirsdag.Add(new Opgaverne(Name, Job, Alder, HusNr));
            OpgaverneOnsdag.Add(new Opgaverne(Name, Job, Alder, HusNr));
            OpgaverneTorsdag.Add(new Opgaverne(Name, Job, Alder, HusNr));

        }
        


        public void Remove()
        {



            if (SelectedIndex != null)
            {
                Opgavers.RemoveAt(SelectedIndex);
                OnPropertyChanged();
            }
}


      

      //public List<OpgaverDage> MySpiseDageList = new List<OpgaverDage>();
      //public OpgaverDage Mandag = new OpgaverDage();
      //public  OpgaverDage Tirsdag = new OpgaverDage();
      //public OpgaverDage Onsdag= new OpgaverDage();
      //public  OpgaverDage Torsdag = new OpgaverDage();
      //public OpgaverDage Specialdag = new OpgaverDage();
      //public OpgaverDage Name1 = new OpgaverDage();
      //public OpgaverDage Opvasker = new OpgaverDage();
      //public  OpgaverDage HjaelpeKok = new OpgaverDage();
      //  public void DageOpgaver()
      //  {
      //      MySpiseDageList = new List<OpgaverDage>();
      //  }

      //  public class OpgaverDage
      // {
            
      //  public string Mandag { get; set; }
      //  public string Tirsdag { get; set; }
      //  public string Onsdag { get; set; }
      //  public string Torsdag { get; set; }
      //  public string Specialdag { get; set; }
      //  public string Name { get; set; }
      //  public string Opvasker { get; set; }
      //  public string HjaelpeKok { get; set; }
           
      //  }

      



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
