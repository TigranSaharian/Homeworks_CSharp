using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CarsDataBase())
            {
                if (!db.Database.Exists())
                {
                    InitData();
                }
            }
            QueryData();
            Console.ReadKey();
        }

        static void QueryData()
        {
            CarsDataBase dbContext = new CarsDataBase();
            var cars = dbContext.Cars;

            dbContext.Database.Log = SaveLog;
            var query = cars.Select(x => x.Name);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }


        private static void SaveLog(string obj)
        {
            Console.WriteLine(obj);
            //

        }

        static void InitData()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car() { Id = 0, Name = "BMW", year = 2000 });
            cars.Add(new Car() { Id = 1, Name = "Honda", year = 2010 });
            cars.Add(new Car() { Id = 2, Name = "Mercedes", year = 2012 });
            cars.Add(new Car() { Id = 3, Name = "Nissan", year = 2006 });

            CarsDataBase db = new CarsDataBase();
            foreach (var item in cars)
            {
                db.Cars.Add(item);
            }
            db.SaveChanges();
                
        }
    }
}
