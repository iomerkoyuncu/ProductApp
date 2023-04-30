using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Commands.Catalog.UpdateCatalog
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, ServiceResponse<Guid>>
    {
        private readonly ICatalogRepository catalogRepository;
        private readonly IMapper mapper;

        public UpdateCatalogCommandHandler(ICatalogRepository catalogRepository, IMapper mapper)
        {
            this.catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var existingCatalog = await catalogRepository.GetById(request.Id);
            if (existingCatalog == null)
            {
                return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: $"Catalog with Id {request.Id} not found.", isSuccess: false, value: default);
            }

            existingCatalog.Name = request.Name;
            existingCatalog.Description = request.Description;

            await catalogRepository.UpdateAsync(existingCatalog);

            var updatedCatalog = mapper.Map<ProductApp.Domain.Entities.Catalog>(existingCatalog);

            return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: "Catalog updated successfully.", value: updatedCatalog.Id);
        }
    }
}