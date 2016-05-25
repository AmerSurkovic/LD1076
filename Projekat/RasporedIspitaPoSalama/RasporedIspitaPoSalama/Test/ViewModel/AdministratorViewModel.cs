using RasporedIspitaPoSalama.Test.Helper;
using RasporedIspitaPoSalama.Test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.Test.ViewModel
{
    class AdministratorViewModel : INotifyPropertyChanged
    {   
        public Administrator CreateAdministrator { get; set; }
        
        //rfid uredjaj
        Rfid rfid;

        public AdministratorViewModel()
        {
            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);
        }

        //callback na read rfid
        public void RfidReadSomething(string rfidKod)
        {
            CreateAdministrator.RfidKartica = rfidKod;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
