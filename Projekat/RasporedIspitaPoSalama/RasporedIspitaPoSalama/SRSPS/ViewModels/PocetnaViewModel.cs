using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RasporedIspitaPoSalama.SRSPS.ViewModels
{
    //ne koristi se
    class PocetnaViewModel : INotifyPropertyChanged
    {
        public Frame glavniFrame;
        public event PropertyChangedEventHandler PropertyChanged;

        public PocetnaViewModel(Frame _frame)
        {
            glavniFrame = _frame;
        }
    }
}
