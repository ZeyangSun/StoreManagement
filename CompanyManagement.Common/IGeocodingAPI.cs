using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Common
{
    public interface IGeocodingAPI
    {
        GeoObject GetGeoObject(string address);
        string CheckZip(string address, string city, string zip);
    }
}
