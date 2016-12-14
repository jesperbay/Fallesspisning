using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace Footap
{
    class MaaltidViewModel : INotifyPropertyChanged
    {
        public string Dag { get; set; }
        public string Ret { get; set; }
        public double MadUdgift { get; set; }
        public Maaltid SelectedItem { get; set; }
        public Maaltid SelectedItem2 { get; set; }

       
        
        public ObservableCollection<Maaltid> MaaltiderNu { get; set; }
        public ObservableCollection<Maaltid> MaaltiderNext { get; set; }

        public MaaltidViewModel()
        {
            MaaltiderNu = new ObservableCollection<Maaltid>();
            MaaltiderNu.Add(new Maaltid("Mandag", "Kylling med Korhansovs", 30.5));
            MaaltiderNext = new ObservableCollection<Maaltid>();
            MaaltiderNext.Add(new Maaltid("Torsdag", "Fiskefars med konkylieknas", 1337));
        }

        public void AddDenneUge()
        {
            MaaltiderNu.Add(new Maaltid(Dag, Ret, MadUdgift));
            OnPropertyChanged();
        }

        public void AddNyeUge()
        {
            MaaltiderNext.Add(new Maaltid(Dag, Ret, MadUdgift));
            OnPropertyChanged();
        }

        public void Remove()
        {
            if (SelectedItem != null)
            {
                MaaltiderNext.Remove(SelectedItem);
                OnPropertyChanged();
            }
            else if (SelectedItem2 != null)
            {
                MaaltiderNu.Remove(SelectedItem2);
                OnPropertyChanged();
            }
        


      
    }
        public void Move ()
        {
            if (SelectedItem != null)
            {
                MaaltiderNu.Add(SelectedItem);
                MaaltiderNext.Remove(SelectedItem);
            }
        }


        public class PersistencyPls
        {
            
      
                            

            private static
            string JsonFileName = "NotesAsJson.dat";

                public static
            async
            void SaveNotesAsJsonAsync 
            (ObservableCollection < Maaltid > MaaltiderNu)
            {
                string notesJsonString = JsonConvert.SerializeObject(MaaltiderNu);
                SerializeNotesFileAsync(notesJsonString, JsonFileName);
            }

            public static
            async
            Task<List<Maaltid>> LoadNotesFromJsonAsync 
            ()
            {
                string notesJsonString = await DeserializeNotesFileAsync(JsonFileName);
                if (notesJsonString != null)
                    return (List<Maaltid>) JsonConvert.DeserializeObject(notesJsonString, typeof(List<Maaltid>));
                return null;
            }



            private static
            async
            void SerializeNotesFileAsync 
            (string notesJsonString, string fileName)
            {
                StorageFile localFile =
                    await
                        ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                            CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(localFile, notesJsonString);
            }


            private static
            async
            Task<string> DeserializeNotesFileAsync 
            (string
            fileName)
            {
                try
                {
                    StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    return await FileIO.ReadTextAsync(localFile);
                }
                catch (FileNotFoundException ex)
                {
                    MessageDialogHelper.Show(
                        "Loading for the first time? - Try Add and Save some Notes before trying to Save for the first time",
                        "File not Found");
                    return null;
                }
            }

            private class
            MessageDialogHelper
            {
                public static
                async
                void Show 
                (string content, string title)
                {
                    MessageDialog messageDialog = new MessageDialog(content, title);
                    await messageDialog.ShowAsync();
                }
            }
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
