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

        public decimal Value { get; set; }

        public int Quantity { get; set; }
    }
}
