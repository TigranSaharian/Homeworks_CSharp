using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Air<T1> where T1 : IAirport
    {
        //
        public Air(T1 qaz)
        {

        }
    }

    public class Air2
    {
        public Air2(Airport airport)
        {

        }
    }
}
