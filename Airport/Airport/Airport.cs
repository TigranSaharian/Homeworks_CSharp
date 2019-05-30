using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public enum AirportSizes
    {
        Small, // 0
        Medium, // 1
        Large, // 2
        Mega, // 3
        SuperMega // 4
    }

    public interface IAirport
    {
        string Name { get; set; }
        string CountryCode { get; set; }
        string SizeEx { get; set; }
    }
    public class Airport : IAirport
    {
        //const string small = "Small";
        //const string medium = "Medium";

        //public static List<Airport> SortingAiroports(List<Airport> Airports)
        //{
        //    //var sportedAirports = Airports.OrderBy(x => x.Size);
        //    //var mediumCounts = Airports.Count(x => x.Size == AirportSizes.Medium);
        //    //var sz = AirportSizes.Small;
        //    return Airports
        //        .OrderBy(x => x.Size)
        //        .ToList();
        //}

        /// <summary>
        ///  Class represents an airport 
        /// </summary>
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public AirportSizes Size { get; set; }
        public string SizeEx { get; set; }

        public override string ToString()
        {
            return $"{Name}, {CountryCode}, {SizeEx}";
        }
    }

    public class SmallAirport : Airport
    {
        new public string SizeEx { get; private set; }

        public SmallAirport()
        {
            SizeEx = "Small";
        }
    }

    public abstract class Airport2
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public override string ToString()
        {
            return $"{Name}, {CountryCode}";
        }
    }
    public class SmallAirport2 : Airport2
    {
        public AirportSizes SizeE { get; } = AirportSizes.Small;
        public override string ToString()
        {
            return $"{base.ToString()}, {SizeE}";
        }
    }
}
