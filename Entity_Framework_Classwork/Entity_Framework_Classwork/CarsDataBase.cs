using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity_Framework_Classwork
{
    class CarsDataBase : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
