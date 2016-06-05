using RasporedIspitaPoSalama.SRSPS.Helper;
using RasporedIspitaPoSalama.SRSPS.Models;
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
    class AdministratorViewModel : INotifyPropertyChanged
    {
        public Administrator CreateAdministrator { get; set; }

        //rfid uredjaj
        Rfid rfid;

        private string user_name;
        public string UserName { get { return user_name; } set { user_name = value; OnNotifyPropertyChanged("UserName"); } }

        private string password;
        public string PassWord { get { return password; } set { password = value; OnNotifyPropertyChanged("PassWord"); } }

        public ICommand Potvrda { get; set; }

        public AdministratorViewModel()
        {
            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);

            Potvrda = new RelayCommand<object>(potvrdi);
        }

        //callback na read rfid
        public void RfidReadSomething(string rfidKod)
        {
            CreateAdministrator.RfidKartica = rfidKod;
        }

        public async void potvrdi(object parametar)
        {

            // Validacija podataka
            if (String.IsNullOrWhiteSpace(UserName))
            {
                var d = new MessageDialog("Unesite ponovno korisnicko ime.", "Neispravan unos korisnickog imena");
                await d.ShowAsync();
            }
            else if (String.IsNullOrWhiteSpace(PassWord))
            {
                var d = new MessageDialog("Unesite ponovno lozinku.", "Neispravan unos lozinke");
                await d.ShowAsync();
            }
            else if (UserName != TestniPodaci.admin.UserName || PassWord != TestniPodaci.admin.Password)
            {
                var d = new MessageDialog("Uneseni podaci nisu ispravni. Unesite ispravno korisnicko ime i odgovarajucu lozinku", "Greska!");
                await d.ShowAsync();
            }
            else if (UserName == TestniPodaci.admin.UserName && PassWord == TestniPodaci.admin.Password)
            {
                var d = new MessageDialog("Uspjesna prijava!", "Dodatne aktivnosti u aplikaciji su sada aktivirane.");
                App.admin = true;

                await d.ShowAsync();

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
