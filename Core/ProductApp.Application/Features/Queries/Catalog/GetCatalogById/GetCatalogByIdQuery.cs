using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Features.Queries.Product.GetCatalogById
{
    public class GetCatalogByIdQuery : IRequest<ServiceResponse<GetCatalogByIdViewModel>>
    {
        public Guid Id { get; set; }

    }
}
