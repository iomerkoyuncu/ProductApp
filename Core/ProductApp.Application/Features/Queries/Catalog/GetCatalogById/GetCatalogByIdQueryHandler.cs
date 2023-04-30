using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Product.GetCatalogById
{
    public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, ServiceResponse<GetCatalogByIdViewModel>>
    {
        ICatalogRepository catalogRepository;
        private readonly IMapper mapper;

        public GetCatalogByIdQueryHandler(ICatalogRepository catalogRepository, IMapper mapper)
        {
            this.catalogRepository = catalogRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetCatalogByIdViewModel>> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            var catalog = await catalogRepository.GetById(request.Id);
            var dto = mapper.Map<GetCatalogByIdViewModel>(catalog);

            return new ServiceResponse<GetCatalogByIdViewModel>(dto);
        }
    }
}
