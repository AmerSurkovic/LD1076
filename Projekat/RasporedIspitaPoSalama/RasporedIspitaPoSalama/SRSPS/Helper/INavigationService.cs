using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
    }
}