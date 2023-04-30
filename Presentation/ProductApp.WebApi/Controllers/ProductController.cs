using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Features.Commands.UpdateProduct;
using ProductApp.Application.Features.Commands.DeleteProduct;

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
            // Set the ID of the command to the ID from the route
            command.Id = id;

            // Send the command to the mediator
            var response = await mediator.Send(command);

            // Check if the response indicates success or failure
            if (response.IsSuccess)
            {
                // Return the ID of the updated product
                return Ok(response.Id);
            }
            else
            {
                // Return the error message
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteProductCommand command)
        {
            // Set the ID of the command to the ID from the route
            command.Id = id;

            // Send the command to the mediator
            var response = await mediator.Send(command);

            // Check if the response indicates success or failure
            if (response.IsSuccess)
            {
                // Return the ID of the updated product
                return Ok(response.Id);
            }
            else
            {
                // Return the error message
                return BadRequest(response.Message);
            }
        }
    }
}
