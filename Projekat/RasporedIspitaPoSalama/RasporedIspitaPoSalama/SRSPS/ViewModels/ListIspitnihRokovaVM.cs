using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    public class ListIspitnihRokovaVM
    {
        public ObservableCollection<Models.IspitniRok> ispitniRokovi { get; set; }
        public Models.IspitniRok odabraniRok { get; set; }
        public Frame glavniFrame;

        public ICommand klikNaRok { get; set; }
        public ICommand test_frame { get; set; }
        public ListIspitnihRokovaVM(Frame _glavniFrame)
        {
            ispitniRokovi = Helper.TestniPodaci.dajIspitneRokove();
            glavniFrame = _glavniFrame;
            klikNaRok = new RelayCommand<object>(otvoriRok);
        }

        private void otvoriRok(object parametar)
        {
            odabraniRok = (Models.IspitniRok)parametar;
            glavniFrame.Navigate(typeof(Views.IspitniRok), new IspitniRokViewModel(this));
        }
    }
}
