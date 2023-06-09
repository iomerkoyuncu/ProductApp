﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Application.Features.Commands.Product.UpdateProduct;
using ProductApp.Application.Features.Commands.Product.CreateProduct;
using ProductApp.Application.Features.Commands.Product.DeleteProduct;
using ProductApp.Application.Features.Queries.Product.GetAllProducts;
using ProductApp.Application.Features.Queries.Product.GetProductById;
using ProductApp.Application.Features.Queries.Product.GetAllProductsByCatalogId;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("catalog/{catalogId}")]
        public async Task<IActionResult> GetAllByCatalogId(Guid catalogId)
        {
            var query = new GetAllProductsByCatalogIdQuery { CatalogId = catalogId };
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            command.Id = id;

            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response.Id);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteProductCommand command)
        {
            command.Id = id;

            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response.Id);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
