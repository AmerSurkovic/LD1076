using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
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
    
    public sealed partial class Pocetna : Page
    {
      
        public Pocetna()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            App.tbTrenutnaStranica = tBlockStranica;
            tBlockStranica.Text = "Ispitni rokovi";
           
            glavniFrame.Navigate(typeof(ListIspitnihRokova), glavniFrame);
        }

        private void buttonHamburger_Click(object sender, RoutedEventArgs e)
        {
            splitViewPocetna.IsPaneOpen = !splitViewPocetna.IsPaneOpen;
        }

     

        private void listBoxMeni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (App.admin)
                buttonLogout.Visibility = Visibility.Visible;
            if (listBoxItem_Home.IsSelected)
            {
                tBlockStranica.Text = "Ispitni Rokovi";
                glavniFrame.Navigate(typeof(ListIspitnihRokova), glavniFrame);
            }
            
            else if(listBoxItem_drugi.IsSelected)
            {
                tBlockStranica.Text = "Sale"; 
                glavniFrame.Navigate(typeof(Sale), glavniFrame);
                     
            }
        
            else if (listBoxItem_Admin.IsSelected)
            {
                tBlockStranica.Text = "Admin Login";
                glavniFrame.Navigate(typeof(Prijava_administratora), listBoxItem_Admin);


            }
            else if (listBoxItem_Vrijeme.IsSelected)
            {
                tBlockStranica.Text = "Vremenska prognoza";
                 glavniFrame.Navigate(typeof(VremenskaPrognoza), tBlockStranica);
            }
            else if (listBoxItem_Help.IsSelected)
            {
                tBlockHelp.Text = "Pomoć";
                glavniFrame.Navigate(typeof(Pomoc), tBlockStranica);
            }


        }

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {            
                glavniFrame.GoBack();
            
        }

        private async void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            var d = new MessageDialog("Uspjesan log out.", "Log out");
            await d.ShowAsync();
            listBoxItem_Admin.Visibility = Visibility.Visible;
            App.admin = false;
            buttonLogout.Visibility = Visibility.Collapsed;
            glavniFrame.Navigate(typeof(ListIspitnihRokova),glavniFrame);

        }

        
    }
}
