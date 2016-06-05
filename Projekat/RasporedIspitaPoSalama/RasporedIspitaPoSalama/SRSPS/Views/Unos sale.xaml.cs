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
    public sealed partial class Unos_sale : Page
    {
        UnosSaleViewModel unosSale;

        public Unos_sale()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();

            /*currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;*/
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            unosSale = (UnosSaleViewModel)e.Parameter;
            DataContext = unosSale;
            App.tbTrenutnaStranica.Text = "Unos sale";
        }

        /*private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }*/
    }
}
