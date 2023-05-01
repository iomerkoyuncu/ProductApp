using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgURL { get; set; }
        public Guid CatalogId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
