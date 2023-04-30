using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Catalog.CreateCatalog
{
        public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, ServiceResponse<Guid>>
        {
            ICatalogRepository catalogRepository;
            private readonly IMapper mapper;

            public CreateCatalogCommandHandler(ICatalogRepository catalogRepository, IMapper mapper)
            {
                this.catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
            {
                var catalog = mapper.Map<ProductApp.Domain.Entities.Catalog>(request);
                await catalogRepository.AddAsync(catalog);

                return new ServiceResponse<Guid>(catalog.Id);
            }
        }
}
