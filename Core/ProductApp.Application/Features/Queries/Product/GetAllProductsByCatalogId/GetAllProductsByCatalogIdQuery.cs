using AutoMapper;
using MediatR;
using ProductApp.Application.Dtos;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Product.GetAllProductsByCatalogId
{
    public class GetAllProductsByCatalogIdQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        public Guid CatalogId { get; set; }

        public class GetAllProductsByCatalogIdQueryHandler : IRequestHandler<GetAllProductsByCatalogIdQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductsByCatalogIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsByCatalogIdQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllByCatalogId(request.CatalogId);

                var viewModel = mapper.Map<List<ProductViewDto>>(products);

                return new ServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}
