using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;

namespace NoteMVVM1
{
    class NoteModel
    {
        public int Nr { get; set; }
        public string Tekst { get; set; }
        public string Emne { get; set; }
        public DateTime Dato { get; set; }

        public static int count { get; set; }
        public string Dag { get; set; }

        public NoteModel(string tekst, string emne)
        {
            Nr = ++count;
            Tekst = tekst;
            Emne = emne;
            Dato = DateTime.Now;
        }
       

        public override string ToString()
        {
            if (Nr == 1)
            {
                Dag = "Mandag";
            }
            if (Nr == 2)
            {
                Dag = "Tirsdag";
            }
            if (Nr == 3)
            {
                Dag = "Onsdag";
            }
            if (Nr == 4)
            {
                Dag = "Torsdag";
            }
            return $"{nameof(Dag)}: {Dag}, {nameof(Tekst)}: {Tekst}, {nameof(Emne)}: {Emne}, {nameof(Dato)}: {Dato}";
        }
    }
}
