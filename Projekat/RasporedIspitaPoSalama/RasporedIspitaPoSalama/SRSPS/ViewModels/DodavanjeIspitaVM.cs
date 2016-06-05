using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    public class DodavanjeIspitaVM
    {
        public Models.Ispit ispit { get; set; }
        public ICommand dodaj_ispit { get; set; }
        public ICommand idi_nazad { get; set; }
        public IspitniRokViewModel Parent { get; set; }

        public DodavanjeIspitaVM(IspitniRokViewModel _parent)
        {
            Parent = _parent;
            ispit = new Models.Ispit();

            dodaj_ispit = new RelayCommand<object>(dodajIspit);
            idi_nazad = new RelayCommand<object>(idiNazad);
        }

        private void dodajIspit(object o)
        {

        }

        private void idiNazad(object o)
        {
            if (Parent.trenutniFrame.CanGoBack)
                Parent.trenutniFrame.GoBack();
        }
    }
}
