using ProductApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProductApp.Domain.Entities
{
    public class Product: BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public String ImgURL { get; set; }

    }
}
