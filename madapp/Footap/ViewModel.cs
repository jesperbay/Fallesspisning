using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Footap
{
    class ViewModel        : INotifyPropertyChanged
    {
        public string Dag { get; set; }
        public string Ret { get; set; }
        public double Udgift { get; set; }
        public Maaltid SelectedItem { get; set; }

        public ObservableCollection<Maaltid> maaltider { get; set; }

        public ViewModel()
        {
                    maaltider = new ObservableCollection<Maaltid>();
        }

        public void AddMandag(string Dag, String Ret, Double Udgift)
        {
            maaltider.Add(new Maaltid());
        }

        #region PropertyChangeSupport
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
