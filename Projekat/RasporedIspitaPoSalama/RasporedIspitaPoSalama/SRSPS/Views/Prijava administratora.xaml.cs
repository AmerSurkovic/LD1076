using RasporedIspitaPoSalama.SRSPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Prijava_administratora : Page
    {
        TextBlock tb;
        AdministratorViewModel administratorViewModel;
        ListBoxItem lbAdmin;
        public Prijava_administratora()
        {
            this.InitializeComponent();
            administratorViewModel = new AdministratorViewModel();
            this.DataContext = administratorViewModel;


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           if(e.Parameter!=null)
            {
                lbAdmin = (ListBoxItem)e.Parameter;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (App.admin)
            {
                lbAdmin.Visibility = Visibility.Collapsed;

            }
                
        }
    }
}
