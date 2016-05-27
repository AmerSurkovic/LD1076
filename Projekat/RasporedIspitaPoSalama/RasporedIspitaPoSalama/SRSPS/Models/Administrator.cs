using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Models
{
    [DataContract]
    public class Administrator : Osoba, INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        private string rfidKartica;
        [DataMember]
        public string RfidKartica { get { return rfidKartica; } set { rfidKartica = Regex.Replace(value, "[^0-9a-zA-Z]+", ""); OnNotifyPropertyChanged("RfidKartica"); } }

        public Administrator(string _ime, string _prezime, DateTime _datumRodjenja) : base(_ime,_prezime,_datumRodjenja) { }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}