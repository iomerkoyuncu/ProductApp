using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await productRepository.GetById(request.Id);
            if (existingProduct == null)
            {
                return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: $"Product with Id {request.Id} not found.", isSuccess: false, value: default);
            }

            existingProduct.Name = request.Name;
            existingProduct.Description = request.Description;
            existingProduct.Price = request.Price;
            existingProduct.Quantity = request.Quantity;
            existingProduct.ImgURL = request.ImgURL;

            await productRepository.UpdateAsync(existingProduct);

            var updatedProduct = mapper.Map<ProductApp.Domain.Entities.Product>(existingProduct);

            return new ServiceResponse<Guid>(id: Guid.NewGuid(), message: "Product updated successfully.", value: updatedProduct.Id);
        }
    }
}