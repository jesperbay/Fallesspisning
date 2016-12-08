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
            public string Ret { get; set; }
            public double MadUdgift { get; set; }
            public Maaltid SelectedItem { get; set; }

            public ObservableCollection<Maaltid> maaltider { get; set; }

            public MaaltidViewModel ()
            {
                maaltider = new ObservableCollection<Maaltid>();
                maaltider.Add(new Maaltid(new DateTime(2016 , 12 , 8) , "Kylling med Korhansovs" , 30.5));
            }

            public void Add ()
            {
                maaltider.Add(new Maaltid(new DateTime() , Ret , MadUdgift));
                OnPropertyChanged();
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
