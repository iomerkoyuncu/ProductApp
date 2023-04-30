using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await productRepository.GetById(request.Id);
            if (existingProduct == null)
            {
                return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: $"Product with Id {request.Id} not found.", isSuccess: false, value: default);
            }

            await productRepository.DeleteAsync(existingProduct);

            return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: "Deleted successfully.", value: existingProduct.Id);
        }
    }
}
