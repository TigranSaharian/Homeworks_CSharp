using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        static void Main(string[] args) // Small, Medium, Large, Mega, Super Mega. 
        {
            var al = new List<Airport>();
            var exit = false;

            while (!exit)
            {
                var ap = new Airport();
                //var pp = new SmallAirport();
                //var aa = new SmallAirport2();
                //var ss = new Airport2();
                var ss = new Air2(ap);
                var dd = new Air<IAirport>(ap);


                // name
                Console.Write("\nEnter airport name [enter X for exist]: ");
                ap.Name = Console.ReadLine();
                if (ap.Name.ToLower() == "x")
                {
                    exit = true;
                    continue;
                }
                else if (ap.Name.Length == 0)
                {
                    Console.WriteLine("Airport name cannot be an empty string.");
                    continue;
                }

                // country code
                Console.Write("\nEnter country code: ");
                ap.CountryCode = Console.ReadLine();
                if (ap.CountryCode.Length == 0)
                {
                    Console.WriteLine("Country code cannot be an empty string.");
                    continue;
                }

                // size
                Console.Write("\nEnter airport size [Small/Medium/Large/Mega/Super Mega]: ");
                //Console.Write("\nEnter airport size [0 for Small, 1 for Medium, 2 for Large, 3 for Mega, 4 for Super Mega]: ");
                var sz = Console.ReadLine();
                if (int.TryParse(sz, out int size))
                {
                    if (Enum.TryParse(size.ToString(), out AirportSizes airportSize))
                    {
                        ap.Size = airportSize;
                    }
                    else
                    {
                        Console.WriteLine("Airport size must be a number between 0 and 4");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Airport size must be a number between 0 and 4");
                    continue;
                }
                //if (ap.SizeEx.Length == 0)
                //{
                //    Console.WriteLine("Airport size cannot be an empty string.");
                //    continue;
                //}
                //else if (new string[] { "Small", "Medium", "Large", "Mega", "Super Mega" }.Contains(ap.SizeEx))
                //{
                //    Console.WriteLine("Airport size must be one of the following nameed values Small, Medium, Large, Mega, Super Mega");
                //    continue;
                //}
                //ap.SizeEx = sz;

                al.Add(ap);
                var cc = ap.ToString();
            }

            Console.WriteLine("\nOriginal order:");
            foreach (var ap in al)
            {
                //Console.WriteLine(ap.ToString());
                Console.WriteLine($"{ap.Name}, {ap.CountryCode}, {ap.Size}");
            }

            Console.WriteLine("\nSorted order:");
            var ax = al
                .OrderBy(x => x.Size)
                //.OrderBy(x => x.SizeEx)
                .ToList();
            foreach (var ap in ax)
            {
                //Console.WriteLine(ap.ToString());
                Console.WriteLine($"{ap.Name}, {ap.CountryCode}, {ap.Size}");
            }

            Console.ReadLine();
        }
    }
}
