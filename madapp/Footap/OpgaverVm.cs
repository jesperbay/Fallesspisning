using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;

namespace Footap
{
    class OpgaverVm : INotifyPropertyChanged
    {

        public string name { get; set; }
        public string job { get; set; }
        public ObservableCollection<Opgaverne> Opgavernes { get; set; }

        public OpgaverVm()
        {
            Opgavernes = new ObservableCollection<Opgaverne>();
            Opgavernes.Add(new Opgaverne("Chefkok"));
            Opgavernes.Add(new Opgaverne("Kok"));
            Opgavernes.Add(new Opgaverne("opvasker"));
            name = "opgaver";
            Opgavernes.Add(new Opgaverne(job));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(string name, string job)
        {
            Opgavernes.Add(new Opgaverne(name, job));
        }

       

    }
}
