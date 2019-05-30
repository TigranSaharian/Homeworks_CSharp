using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    public interface ICloneable<T> where T : new()
    {
        T Clone();        
    }
}
