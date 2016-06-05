using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasporedIspitaPoSalama.SRSPS.Models;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    public class IspitniRokViewModel : INotifyPropertyChanged
    {
        public IspitniRok ispitniRok { get; set; }
        public Models.Ispit odabraniIspit { get; set; }
        public ListIspitnihRokovaVM parent { get; set; }
        public Frame trenutniFrame {get; set;}

        public ICommand pritisnutIspit { get; set; }
        public ICommand idiNazad { get; set; }
        public ICommand dodaj_ispit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public IspitniRokViewModel(ListIspitnihRokovaVM _parent)
        {
            ispitniRok = _parent.odabraniRok;
            parent = _parent;
            trenutniFrame = _parent.glavniFrame;

            idiNazad = new RelayCommand<object>(idi_nazad);
            pritisnutIspit = new RelayCommand<object>(pokreniPregledIspita);
            dodaj_ispit = new RelayCommand<object>(dodajIspit);
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        private void pokreniPregledIspita(object o)
        {
            odabraniIspit = (Ispit)o;
            trenutniFrame.Navigate(typeof(Views.DetaljiIspit), new DetaljiIspitVM(this));
        }
  
        private void idi_nazad(object o)
        {
            if(trenutniFrame.CanGoBack)
            {
                trenutniFrame.GoBack();
            }
        }
        private void dodajIspit(object o)
        {
            trenutniFrame.Navigate(typeof(Views.DodavanjeIspita), new DodavanjeIspitaVM(this));
        }

    }
}
