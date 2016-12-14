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
    class MaaltidViewModel : INotifyPropertyChanged
    {
        public DateTime DateGregorian { get; set; }
        public string Ret { get; set; }
        public double MadUdgift { get; set; }
        public Maaltid SelectedItem { get; set; }

        public ObservableCollection<Maaltid> MaaltiderNu { get; set; }
        public ObservableCollection<Maaltid> MaaltiderNext { get; set; }

        public MaaltidViewModel()
        {
            MaaltiderNu = new ObservableCollection<Maaltid>();
            MaaltiderNu.Add(new Maaltid(new DateTime(2016, 12, 8), "Kylling med Korhansovs", 30.5));
            MaaltiderNext = new ObservableCollection<Maaltid>();
            MaaltiderNext.Add(new Maaltid(new DateTime(2016, 12, 12), "Fiskefars med konkylieknas", 1337));
        }

        public void AddDenneUge()
        {
            MaaltiderNu.Add(new Maaltid(DateGregorian, Ret, MadUdgift));
            OnPropertyChanged();
        }

        public void AddNyeUge()
        {
            MaaltiderNext.Add(new Maaltid(DateGregorian, Ret, MadUdgift));
            OnPropertyChanged();
        }

        #region PropertyChangeSupport

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
