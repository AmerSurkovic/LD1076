using RasporedIspitaPoSalama.SRSPS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    /// 

    public sealed partial class Sale : Page
    {

        public Sale()
        {
            this.InitializeComponent();

            SalaViewModel saleVM = new SalaViewModel();

            DataContext = saleVM;

            if (App.admin == true)
            {
                dodajSalu_button.Visibility = Visibility.Visible;
                izbrisiSalu_button.Visibility = Visibility.Visible;
                editujSalu_button.Visibility = Visibility.Visible;
            }
            else
            {

                dodajSalu_button.Visibility = Visibility.Collapsed;
                izbrisiSalu_button.Visibility = Visibility.Collapsed;
                editujSalu_button.Visibility = Visibility.Collapsed;
            }
        }

        public Sale(TextBlock _tb)
        {
            this.InitializeComponent();


        }

        public object SaleViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.tbTrenutnaStranica.Text = "Sale";

            if (e.Parameter != null)
                ((SalaViewModel)DataContext).trenutniFrame = (Frame)e.Parameter;

        }
    }
}
