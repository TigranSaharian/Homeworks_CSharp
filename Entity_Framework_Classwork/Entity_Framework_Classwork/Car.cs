using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Classwork
{
    class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int year { get; set; }
    }
}
