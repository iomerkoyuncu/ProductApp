using AutoMapper;
using ProductApp.Application.Features.Commands.Catalog.CreateCatalog;
using ProductApp.Application.Features.Commands.Product.CreateProduct;
using ProductApp.Application.Features.Queries.Product.GetCatalogById;
using ProductApp.Application.Features.Queries.Product.GetProductById;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping: Profile
    {

        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>()
                .ReverseMap();

            CreateMap<Domain.Entities.Product, CreateProductCommand>()
                .ReverseMap();

            CreateMap<Domain.Entities.Catalog, CreateCatalogCommand>()
                .ReverseMap();

            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.CatalogId));

            CreateMap<Domain.Entities.Product, GetProductByIdViewModel>()
                .ReverseMap();

            CreateMap<Domain.Entities.Catalog, GetCatalogByIdViewModel>()
                .ReverseMap();
        }

    }
}
