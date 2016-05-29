using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasporedIspitaPoSalama.SRSPS.Models;
using System.Runtime.CompilerServices;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    class IspitniRokViewModel : INotifyPropertyChanged
    {
        public IspitniRok ispitniRok { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public IspitniRokViewModel()
        {
            Helper.TestniPodaci data = new Helper.TestniPodaci();
            ispitniRok = data.ispitniRok;
            String s = ispitniRok.ispiti.ElementAt<Ispit>(0).ToString();
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
