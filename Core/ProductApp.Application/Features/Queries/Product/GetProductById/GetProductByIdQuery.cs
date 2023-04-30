using MediatR;
using ProductApp.Application.Dtos;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<GetProductByIdViewModel>>
    {
        public Guid Id { get; set; }
    }
}
