using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    class Program
    {
        static void Main(string[] args)
        {
            ICloneable<A> a1 = new A() { Money = 10 };
            A a2 = a1.Clone();
            ICloneable<B> b1 = new B() { Status = "sss" };
            B b2 = b1.Clone();

            Console.WriteLine(a2.Money);
            Console.WriteLine(b2.Status);
            Console.Read();
        }
    }
}
