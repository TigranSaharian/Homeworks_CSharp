using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentClient.StudentServiceReference;

namespace StudentClient
{
    class Program
    {
        private static IstudentServiceClient Client;
        static void Main(string[] args)
        {
            Client = new IstudentServiceClient();
            var res = Client.GetStudent();
            foreach (var item in res)
            {
                Console.WriteLine(item.Age);
            }
        }
    }
}
