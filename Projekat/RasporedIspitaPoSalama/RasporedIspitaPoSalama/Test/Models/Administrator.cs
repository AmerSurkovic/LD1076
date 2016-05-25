using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.Test.Models
{
    [DataContract]
    public class Administrator : INotifyPropertyChanged
    {
        string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        string password;
        public string Password { get { return password; } set { password = value; } }

        private string rfidKartica;
        [DataMember]
        public string RfidKartica { get { return rfidKartica; } set { rfidKartica = Regex.Replace(value, "[^0-9a-zA-Z]+", ""); OnNotifyPropertyChanged("RfidKartica"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
