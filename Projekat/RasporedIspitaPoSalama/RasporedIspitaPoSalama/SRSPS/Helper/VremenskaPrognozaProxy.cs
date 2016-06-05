using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RasporedIspitaPoSalama.SRSPS.Helper
{
    public class VremenskaPrognozaProxy
    {
        public async static Task<RootObject> DajVrijeme(double lat, Double lon)
        {

            var http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=a9c09e734753ec511198d3cd6744b3f8&units=metric", lat, lon);
            var odgovor = await http.GetAsync(url);
            var rezultat = await odgovor.Content.ReadAsStringAsync();
            var serialzer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(rezultat));
            var podaci = (RootObject)serialzer.ReadObject(ms);

            return podaci;
        }
        [DataContract] 
        public class Coord
        {
            [DataMember]
            public double lon { get; set; }
            [DataMember]
            public double lat { get; set; }
        }
        [DataContract]
        public class Weather
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }
        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public int pressure { get; set; }
            [DataMember]
            public int humidity { get; set; }
            [DataMember]
            public double temp_min { get; set; }
            [DataMember]
            public double temp_max { get; set; }
        }
        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public double deg { get; set; }
        }
        [DataContract]
        public class Clouds
        {
            [DataMember]
            public int all { get; set; }
        }
        [DataContract]
        public class Sys
        {
            [DataMember]
            public int type { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public int sunrise { get; set; }
            [DataMember]
            public int sunset { get; set; }
        }
        public class Sys2
        {
            [DataMember]
            public string pod { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public string @base { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            // public Rain rain { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public int dt { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public int cod { get; set; }
        }
    }
}
