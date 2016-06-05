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
    public class DetaljiIspitVM : INotifyPropertyChanged
    {
        public IspitniRokViewModel parent { get; set; }
        public Models.Ispit ispit { get; set; }
        public Models.RasporedUSali odabranaSala { get; set; }
        public Frame trenutniFrame { get; set; }
        public ICommand idiNazad { get; set; }
        public ICommand otvoriSalu { get; set; }
        public DetaljiIspitVM(IspitniRokViewModel _parent)
        {
            parent = _parent;
            ispit = _parent.odabraniIspit;
            trenutniFrame = parent.trenutniFrame;
            idiNazad = new RelayCommand<object>(idi_nazad);
            otvoriSalu = new RelayCommand<object>(otvori_salu);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        private void idi_nazad(object o)
        {
            if (trenutniFrame.CanGoBack)
                trenutniFrame.GoBack();
        }

        private void otvori_salu(object o)
        {
            odabranaSala = (Models.RasporedUSali)o;
            trenutniFrame.Navigate(typeof(Views.RasporedUSali), new RasporedUSaliVM(this));
        }
    }
}
