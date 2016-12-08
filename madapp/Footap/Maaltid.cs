using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace Footap
{
    class Maaltid
    {
        public DateTime DateGregorian { get; set; }
        public string Ret { get; set; }
        public double MadUdgift { get; set; }

        public Maaltid(DateTime dategregorian, string ret, double madudgift)
        {
            DateGregorian = dategregorian;
            Ret = ret;
            MadUdgift = madudgift;
        }

        public override string ToString()
        {
            return $"{nameof(DateGregorian)}: {DateGregorian}, {nameof(Ret)}: {Ret}, {nameof(MadUdgift)}: {MadUdgift}";
        }
    }
}
