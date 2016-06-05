using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RasporedIspitaPoSalama.SRSPS.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DodavanjeIspita : Page
    {
        public DodavanjeIspita()
        {
            this.InitializeComponent();
           
            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                comboBoxPredmeti.ItemsSource = db.Predmeti;
            }
            tBoxTrajanje.Text = "2";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.tbTrenutnaStranica.Text = "Dodavanje ispita";
            if(e.Parameter!=null)
                 DataContext = (ViewModels.DodavanjeIspitaVM)e.Parameter;
        }


        private void dodajIspitButton_Click(object sender, RoutedEventArgs e)
        {
            Models.Ispit ispit = new Models.Ispit();
            ispit.predmet = comboBoxPredmeti.SelectedItem as Models.Predmet;
            ispit.brojPrijavljenih = Convert.ToInt32(tBoxBrojPrijavljenih.Text.ToString());
            int trajanje = Convert.ToInt32(tBoxTrajanje.Text.ToString());
            ispit.termin = new Models.Termin(0, datePicker.Date.DateTime, datePicker.Date.AddHours(trajanje).DateTime);
            ispit.rasporedi = new List<Models.RasporedUSali>();
            Models.RasporedUSali rus;
            
            int brojSala =(int) ((float)ispit.brojPrijavljenih / 80);
            bool[,] raspored;
            int brojZauzetih = 0;
            using (var db = new Models.RasporedIspitaPoSalamaDbContext())
            {
                List<Models.Sala> sale = new List<Models.Sala>();
                foreach(Models.Sala s in db.Sale)
                {
                    sale.Add(s);
                }
                for (int i = 0; i < brojSala + 1 && i<sale.Count && brojZauzetih<=ispit.brojPrijavljenih; i++)
                {
                    raspored = new bool[8, 10];
                    for (int k = 0; k < 8; k++)
                        for (int p = 0; p < 10; p++)
                            if (k % 2 == 0 && p%2==1)
                            {
                                raspored[k, p] = true;
                                brojZauzetih++;
                            }                                
                            else
                                raspored[k, p] = false;
                                
                    rus = new Models.RasporedUSali(0,sale[i],(80+brojZauzetih-1)%80,raspored);

                    ispit.rasporedi.Add(rus);

                }
            }

            ((ViewModels.DodavanjeIspitaVM)DataContext).dodaj_ispit.Execute(ispit);           
            
            
        }
    }

    
}
