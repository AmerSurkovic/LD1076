using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasporedIspitaPoSalama.SRSPS.Models;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    public class RasporedUSaliVM
    {
        private DetaljiIspitVM parent;
        public RasporedUSali raspored { get; set; }
        public ICommand idi_nazad { get; set; }
        public ICommand ucitaj_raspored { get; set; }
        // public ICommand edit { get; set; }
        public RasporedUSaliVM(DetaljiIspitVM _parent)
        {
            parent = _parent;
            raspored = parent.odabranaSala;

            idi_nazad = new RelayCommand<object>(idiNazad);
            ucitaj_raspored = new RelayCommand<object>(ucitajRaspored);
        }

        private void idiNazad(object o)
        {
            if (parent.trenutniFrame.CanGoBack)
                parent.trenutniFrame.GoBack();
        }

        private void ucitajRaspored(object obj)
        {
            GridView gridViewRaspored = (GridView)obj;
            double sirina_celije = 50;
            double visina_celije = 50;
            int broj_redova = raspored.raspored.GetUpperBound(0) + 1;
            int broj_kolona = raspored.raspored.GetUpperBound(1) + 1;
            gridViewRaspored.Width = sirina_celije * (broj_redova) + 40;
       
            for(int i=0;i<broj_redova;i++)
                for(int j=0;j<broj_kolona;j++)
                {
                    GridViewItem gvItem = new GridViewItem();
                    gvItem.Width = sirina_celije;
                    gvItem.Height = visina_celije;
                   
                    if(raspored.raspored[i,j])
                        gvItem.Background = new SolidColorBrush(Colors.Red);
                    else
                        gvItem.Background = new SolidColorBrush(Colors.LightGreen);
                    gvItem.Content = i * 10 + j;
                    gridViewRaspored.Items.Add(gvItem);
                }
        }
    }
}
