using RasporedIspitaPoSalama.SRSPS.Helper;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static RasporedIspitaPoSalama.SRSPS.Helper.VremenskaPrognozaProxy;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RasporedIspitaPoSalama.SRSPS.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VremenskaPrognoza : Page
    {
        public VremenskaPrognoza()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeComponent();
            var position = await LocationManager.DajPoziciju();
            RootObject myWeather = await VremenskaPrognozaProxy.DajVrijeme(position.Coordinate.Latitude, position.Coordinate.Longitude);
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            TemperaturaTextBlock.Text = ((int)myWeather.main.temp).ToString() + " °C";
            OpisTextBlock.Text = myWeather.weather[0].description;
            LokacijaTextBlock.Text = myWeather.name;

        }
    }
}
