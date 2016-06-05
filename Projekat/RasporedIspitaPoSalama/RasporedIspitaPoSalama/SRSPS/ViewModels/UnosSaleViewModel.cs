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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    class UnosSaleViewModel : INotifyPropertyChanged
    {
        public SalaViewModel Parent { get; set; }
        public ICommand Potvrda { get; set; }
        public ICommand Dodaj { get; set; }

        public Sala unos { get; set; }

        private string naziv_sale;
        public string NazivSale { get { return naziv_sale; } set { naziv_sale = value; OnNotifyPropertyChanged("NazivSale"); } }

        private string kapacitet_sale;
        public string KapacitetSale { get { return kapacitet_sale; } set { kapacitet_sale = value; OnNotifyPropertyChanged("KapacitetSale"); } }

        public UnosSaleViewModel(SalaViewModel p)
        {
            this.Parent = p;

            Potvrda = new RelayCommand<object>(potvrdi);
            Dodaj = new RelayCommand<object>(dodaj);
            unos = new Sala();
        }

        public async void dodaj(object parametar)
        {
            int parsedValue;

            // Validacija podataka
            if (String.IsNullOrWhiteSpace(NazivSale))
            {
                var d = new MessageDialog("Unesite ime sale.", "Neispravan unos imena sale");
                await d.ShowAsync();
            }
            else if (String.IsNullOrEmpty(KapacitetSale) || !int.TryParse(KapacitetSale, out parsedValue))// || Convert.ToInt32(KapacitetSale) < 0)
            {
                var d = new MessageDialog("Unesite kapacitet sale.", "Neispravan unos kapaciteta sale");
                await d.ShowAsync();
            }
            else
            {
                unos.naziv = NazivSale;
                unos.kapacitet = Convert.ToInt32(KapacitetSale);
                Parent.Sale.Add(unos);

                using (var db = new Models.RasporedIspitaPoSalamaDbContext())
                {
                    db.Sale.Add(unos);
                    db.SaveChanges();
                }
                Parent.trenutniFrame.GoBack();
            }
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
