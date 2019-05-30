using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 20;
                int b = 0;
                double s = a / b;
                Console.WriteLine(s);
            }
            catch (Exception erroe)
            {
                Console.WriteLine(erroe.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
