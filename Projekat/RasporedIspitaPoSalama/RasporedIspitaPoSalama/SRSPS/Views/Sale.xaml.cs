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
    /// 
    
    public sealed partial class Sale : Page
    {

        TextBlock tb;
        public Sale()
        {
            this.InitializeComponent();
        }

        public Sale(TextBlock _tb)
        {
            this.InitializeComponent();
            tb = _tb;
            tb.Text = "Sale";
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            /*TextBlock _tb = (TextBlock)e.Parameter;
            tb = _tb;
            tb.Text = "Sale";*/

            RasporedIspitaPoSalama.App.stekListBox.Push(2);
        }
    }
}
