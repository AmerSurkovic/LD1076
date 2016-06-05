using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RasporedIspitaPoSalama.SRSPS.Helper
{
    public class LocationManager
    {
        public async static Task<Geoposition> DajPoziciju()
        {
            var statusPristupanja = await Geolocator.RequestAccessAsync();
            if (statusPristupanja != GeolocationAccessStatus.Allowed) throw new Exception();

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var pozicija = await geolocator.GetGeopositionAsync();

            return pozicija;
        }
    }
}
