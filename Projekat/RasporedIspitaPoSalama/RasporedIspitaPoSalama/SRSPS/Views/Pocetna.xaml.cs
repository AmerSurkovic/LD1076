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
    
    public sealed partial class Pocetna : Page
    {
      
        public Pocetna()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            App.tbTrenutnaStranica = tBlockStranica;
            tBlockStranica.Text = "Ispitni rokovi";
           
            tBoxSearch.FontStyle = Windows.UI.Text.FontStyle.Italic;
            glavniFrame.Navigate(typeof(ListIspitnihRokova), glavniFrame);
        }

        private void buttonHamburger_Click(object sender, RoutedEventArgs e)
        {
            splitViewPocetna.IsPaneOpen = !splitViewPocetna.IsPaneOpen;
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tBoxSearch.Text.ToString().Equals("Search"))
            {
                tBoxSearch.Text = "";
                tBoxSearch.FontStyle = Windows.UI.Text.FontStyle.Normal;
            }
        }

        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tBoxSearch.Text.ToString()))
            {
                tBoxSearch.Text = "Search";
                tBoxSearch.FontStyle = Windows.UI.Text.FontStyle.Italic;
            }
        }

        private void listBoxMeni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                glavniFrame.Navigate(typeof(Prijava_administratora));


            }
            else if (listBoxItem_Vrijeme.IsSelected)
            {
                tBlockStranica.Text = "Vremenska prognoza";
               // glavniFrame.Navigate(typeof(VremenskaPrognoza), tBlockStranica);
            }
            
        }

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {            
                glavniFrame.GoBack();
            
        }

    }
}
