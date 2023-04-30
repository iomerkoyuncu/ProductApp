using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Features.Queries.Product.GetCatalogById
{
    public class GetCatalogByIdViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
