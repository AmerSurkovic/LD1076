using RasporedIspitaPoSalama.SRSPS.Helper;
using RasporedIspitaPoSalama.SRSPS.Models;
using RasporedIspitaPoSalama.SRSPS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    class SalaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Sala> Sale { get; set; }

        public Frame trenutniFrame { get; set; }

        public Sala selectedItem { get; set; }

        public ICommand UnosSale { get; set; }
        public ICommand EditSale { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand Obrisi { get; set; }

        public SalaViewModel()
        {
       

            Sale = new ObservableCollection<Sala>();
            NavigationService = new NavigationService();

            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                foreach (Models.Sala s in db.Sale)
                    Sale.Add(s);
            }
            if(Sale.Count>0)
                selectedItem = Sale[0];

            UnosSale = new RelayCommand<object>(unesiSale);
            EditSale = new RelayCommand<object>(editSale);
            Obrisi = new RelayCommand<object>(obrisi);

        }

        public void obrisi(object parametar)
        {
           
            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                db.Sale.Remove(selectedItem);
                db.SaveChanges();
            }
            Sale.Remove(selectedItem);
        }

        public void unesiSale(object parametar)
        {
            //NavigationService.Navigate(typeof(Unos_sale), new UnosSaleViewModel(this));
            trenutniFrame.Navigate(typeof(Unos_sale), new UnosSaleViewModel(this));
        }

        public void editSale(object parametar)
        {
            //NavigationService.Navigate(typeof(EditSale), new EditSaleViewModel(this));
            trenutniFrame.Navigate(typeof(EditSale), new EditSaleViewModel(this));
        }

    }

}
