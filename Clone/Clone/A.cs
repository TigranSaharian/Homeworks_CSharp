using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    public class A: BaseClass<A>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public int Money { get; set; }
    }
}
