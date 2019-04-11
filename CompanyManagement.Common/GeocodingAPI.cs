using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velyo.Google.Services;
using Velyo.Google.Services.Models;

namespace CompanyManagement.Common
{
    public class GeocodingAPI : IGeocodingAPI
    {
        public GeoObject GetGeoObject(string address)
        {
            GeocodingRequest request = new GeocodingRequest(address);//store.Address+store.City
            request.IsSensor = false;
            GeocodingResponse response = request.GetResponse();
            var result = response.Results.First();

            LatLng location = result.Geometry.Location;
            double latitude = location.Latitude;
            double longitude = location.Longitude;
            System.Diagnostics.Debug.WriteLine("---------------  " + latitude);
            System.Diagnostics.Debug.WriteLine("+++++++++++  " + longitude);
            GeoObject obj = new GeoObject
            {
                Latitude = latitude,
                Longitude = longitude
            };
            return obj;
        }
        public string CheckZip(string address, string city,string zip)
        {
            GeocodingRequest request = new GeocodingRequest(address+" "+city );//store.Address+store.City
            request.IsSensor = false;
            GeocodingResponse response = request.GetResponse();
            var result = response.Results.First();
            IEnumerable<AddressComponent> items = result.AddressComponents;
            foreach(AddressComponent item in items)
            {
                if (item.Types[0].Equals("postal_code"))
                {
                    
                    string long_name = item.LongName.Replace(" ","");
                    System.Diagnostics.Debug.WriteLine(long_name.Trim());
                    if (long_name.Equals(zip))
                        return "";
                }
            }
            return "zip number is invalid!";
        }
        
        
    }
}
