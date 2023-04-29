using ProductApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Entities
{
    public class Catalog : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }

    }
}
