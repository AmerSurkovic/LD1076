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

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    class EditSaleViewModel : INotifyPropertyChanged
    {
        public SalaViewModel Parent { get; set; }
        public ICommand Potvrda { get; set; }
        public ICommand Edit { get; set; }
        public ICommand idi_nazad { get; set; }

        public EditSaleViewModel(SalaViewModel p)
        {
            this.Parent = p;
            Potvrda = new RelayCommand<object>(potvrdi);
            Edit = new RelayCommand<object>(edit);
            idi_nazad = new RelayCommand<object>(idiNazad);
        }

        public void edit(object parametar)
        {
           
            if (Parent.trenutniFrame.CanGoBack)
                Parent.trenutniFrame.GoBack();
        }

        public void potvrdi(object parametar)
        {
            if (Parent.trenutniFrame.CanGoBack)
                Parent.trenutniFrame.GoBack();
        }

      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        private void idiNazad(object o)
        {
            if (Parent.trenutniFrame.CanGoBack)
                Parent.trenutniFrame.GoBack();
        }
    }
}
