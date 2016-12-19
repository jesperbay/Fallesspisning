using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace Footap
{
    class PersistencyServiceOpgaver
    {
        private static string JsonFileName = "OpgaverJson.dat";

        public static async void SaveOpgaverAsJsonAsync(OpgaverJSONs opgaverJson)
        {
            string mandagOpgJsonString = JsonConvert.SerializeObject(opgaverJson);
            SerializeMandagOpgFileAsync(mandagOpgJsonString, JsonFileName);
        }

        public static async Task<OpgaverJSONs> LoadOpgaverFromJsonAsync()
        {
            string mandagOpgJsonString = await DeserializeMandagOpgFileAsync(JsonFileName);
            if (mandagOpgJsonString != null)
                return (OpgaverJSONs)JsonConvert.DeserializeObject(mandagOpgJsonString, typeof(OpgaverJSONs));
            return null;
        }



        private static async void SerializeMandagOpgFileAsync(string mandagOpgJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, mandagOpgJsonString);
        }


        private static async Task<string> DeserializeMandagOpgFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                PersistencyServiceOpgaver.MessageDialogHelper.Show("Loading for the first time? - Try Add and Save some Notes before trying to Save for the first time", "File not Found");
                return null;
            }
        }


        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }

        internal static void SaveNotesAsJsonAsync(OpgaverJSONs ugeJobs)
        {
            throw new NotImplementedException();
        }
    }
}

