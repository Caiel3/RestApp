using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Common.Helpers
{
    public interface IGeolocatorService
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task GetLocationAsync();
    }

}
