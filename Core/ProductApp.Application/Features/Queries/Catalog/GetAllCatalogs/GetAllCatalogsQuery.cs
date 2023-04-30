using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.Catalog.GetAllCatalogs
{
    public class GetAllCatalogsQuery : IRequest<ServiceResponse<List<ProductApp.Domain.Entities.Catalog>>>
    {
        public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, ServiceResponse<List<ProductApp.Domain.Entities.Catalog>>>
        {
            private readonly ICatalogRepository catalogRepository;
            private readonly IMapper mapper;

            public GetAllCatalogsQueryHandler(ICatalogRepository catalogRepository, IMapper mapper)
            {
                this.catalogRepository = catalogRepository;
                this.mapper = mapper;
            }


            public async Task<ServiceResponse<List<ProductApp.Domain.Entities.Catalog>>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
            {
                var catalogs = await catalogRepository.GetAll();

                var viewModel = mapper.Map<List<ProductApp.Domain.Entities.Catalog>>(catalogs);

                return new ServiceResponse<List<ProductApp.Domain.Entities.Catalog>>(viewModel);
            }
        }
    }
}
