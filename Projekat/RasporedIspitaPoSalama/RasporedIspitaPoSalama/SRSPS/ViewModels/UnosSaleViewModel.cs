using RasporedIspitaPoSalama.SRSPS.Helper;
using RasporedIspitaPoSalama.SRSPS.Models;
using RasporedIspitaPoSalama.SRSPS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    class UnosSaleViewModel : INotifyPropertyChanged
    {
        public SalaViewModel Parent { get; set; }
        public ICommand Potvrda { get; set; }
        public ICommand Dodaj { get; set; }

        public Sala unos { get; set; }

        public UnosSaleViewModel(SalaViewModel p)
        {
            this.Parent = p;

            Potvrda = new RelayCommand<object>(potvrdi);        
            Dodaj = new RelayCommand<object>(dodaj);
            unos = new Sala();
        }

        public void dodaj(object parametar)
        {
            Parent.Sale.Add(unos);
            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                db.Sale.Add(unos);
                db.SaveChanges();
            }
            Parent.trenutniFrame.GoBack();
        }

        public void potvrdi(object parametar)
        {
            if (Parent.trenutniFrame.CanGoBack)
                Parent.trenutniFrame.GoBack();
            //Parent.trenutniFrame.GoBack();
          //  Parent.NavigationService.GoBack();
        }

        //implementacija INotifyPropertyChanged interfejsa koji ova klasa implementira
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
