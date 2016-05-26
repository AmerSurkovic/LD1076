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
    
    public sealed partial class Pocetna : Page
    {
        public String trenutnaStranica;
        public Pocetna()
        {
            this.InitializeComponent();
            glavniFrame.Navigate(typeof(IspitniRok));
            trenutnaStranica = "Ispitni rok";
            tBlockStranica.Text = trenutnaStranica;
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
            if(listBoxItem_Admin.IsSelected)
            {
                tBlockStranica.Text = "Admin Login";
                button_Back.Visibility = Visibility.Visible;
               
                glavniFrame.Navigate(typeof(Prijava_administratora), tBlockStranica);
                RasporedIspitaPoSalama.App.stekListBox.Push(4);

            }
            else if(listBoxItem_drugi.IsSelected)
            {
                tBlockStranica.Text = "Sale";
                button_Back.Visibility = Visibility.Visible;
                glavniFrame.Navigate(typeof(Sale), tBlockStranica);
                RasporedIspitaPoSalama.App.stekListBox.Push(2);
                
            }
            else if(listBoxItem_Home.IsSelected)
            { 
                tBlockStranica.Text = "Ispitni Rok";
                button_Back.Visibility = Visibility.Collapsed;
                glavniFrame.Navigate(typeof(IspitniRok), tBlockStranica);
                RasporedIspitaPoSalama.App.stekListBox.Push(1);
            }
            else if(listBoxItem_treci.IsSelected)
            {
               
                    tBlockStranica.Text = "Prijašnji ispiti";
                    button_Back.Visibility = Visibility.Visible;
                    glavniFrame.Navigate(typeof(PrijasnjiRokovi), tBlockStranica);
                RasporedIspitaPoSalama.App.stekListBox.Push(3);

            }
        }

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {
            if(glavniFrame.CanGoBack && RasporedIspitaPoSalama.App.stekListBox.Count>0)
            {
                if (RasporedIspitaPoSalama.App.stekListBox.Peek() == 1)
                {
                    tBlockStranica.Text = "Početna";
                    listBoxItem_Home.IsSelected = true;
                }
                    
                else if (RasporedIspitaPoSalama.App.stekListBox.Peek() == 2)
                {
                    tBlockStranica.Text = "Sale";
                    listBoxItem_drugi.IsSelected = true;
                }
                    
                else if (RasporedIspitaPoSalama.App.stekListBox.Peek() == 3)
                {
                    tBlockStranica.Text = "Prijašnji ispiti";
                    listBoxItem_treci.IsSelected = true;
                }
                    
                else
                {
                    tBlockStranica.Text = "Admin Login";
                    listBoxItem_Admin.IsSelected=true;
                }
                    
                RasporedIspitaPoSalama.App.stekListBox.Pop();
                glavniFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        }


    }
}
