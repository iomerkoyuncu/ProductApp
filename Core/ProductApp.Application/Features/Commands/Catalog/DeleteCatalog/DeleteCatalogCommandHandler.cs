using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Catalog.DeleteCatalog
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, ServiceResponse<Guid>>
    {
        private readonly ICatalogRepository catalogRepository;
        private readonly IMapper mapper;

        public DeleteCatalogCommandHandler(ICatalogRepository catalogRepository, IMapper mapper)
        {
            this.catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var existingCatalog = await catalogRepository.GetById(request.Id);
            if (existingCatalog == null)
            {
                return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: $"Catalog with Id {request.Id} not found.", isSuccess: false, value: default);
            }

            await catalogRepository.DeleteAsync(existingCatalog);

            return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: "Deleted successfully.", value: existingCatalog.Id);
        }
    }
}
