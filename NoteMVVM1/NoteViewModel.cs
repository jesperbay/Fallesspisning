using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NoteMVVM1.Annotations;

namespace NoteMVVM1
{
    class NoteViewModel    : INotifyPropertyChanged
    {

        public string Tekst { get; set; }
        public string Emne { get; set; }
        public NoteModel SelectedItem { get; set; }

        public ObservableCollection<NoteModel> notes { get; set; }
        public ObservableCollection<NoteModel> noteDone { get; set; }

        public NoteViewModel()
        {
            notes = new ObservableCollection<NoteModel>();

            notes.Add(new NoteModel("Hej", "Maybelines hofteholder"));
            notes.Add(new NoteModel("Kan du lide det?", "hendes hofteholder"));
            notes.Add(new NoteModel("køb det", "kage"));

            noteDone = new ObservableCollection<NoteModel>();

            noteDone.Add(new NoteModel( "kage", "aftensmad"));
        }

        public void Add()
        {
            notes.Add(new NoteModel(Tekst, Emne)); OnPropertyChanged();
            
        }

        public void Remove()
        {
            notes.Remove(SelectedItem);
            OnPropertyChanged();
        }


        public void Done()
        {
            if (SelectedItem != null)
            {
                noteDone.Add(SelectedItem);
                notes.Remove(SelectedItem);
            }
        }

        #region PropertyChangeSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
