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
    public sealed partial class ListIspitnihRokova : Page
    {
        public Frame glavniFrame;
        public ListIspitnihRokova()
        {
            this.InitializeComponent();
            ViewModels.ListIspitnihRokovaVM listaIspitnihRokovaVM = new ViewModels.ListIspitnihRokovaVM(glavniFrame);

            DataContext = listaIspitnihRokovaVM;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                glavniFrame = (Frame)e.Parameter;
                ((ViewModels.ListIspitnihRokovaVM)DataContext).glavniFrame = glavniFrame;
            }

            App.tbTrenutnaStranica.Text = "Ispitni rokovi";
                
            
        }


        private void listViewIspitniRokovi_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((ViewModels.ListIspitnihRokovaVM)DataContext).klikNaRok.Execute((Models.IspitniRok)e.ClickedItem);
        }
    }
}
