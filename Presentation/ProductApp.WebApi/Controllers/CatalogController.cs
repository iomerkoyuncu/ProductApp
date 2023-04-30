using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dtos;
using ProductApp.Application.Features.Commands.Catalog.CreateCatalog;
using ProductApp.Application.Features.Commands.Catalog.DeleteCatalog;
using ProductApp.Application.Features.Commands.Catalog.UpdateCatalog;
using ProductApp.Application.Features.Queries.Catalog.GetAllCatalogs;
using ProductApp.Application.Features.Queries.Product.GetAllProductsByCatalogId;
using ProductApp.Application.Features.Queries.Product.GetCatalogById;
using ProductApp.Application.Wrappers;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator mediator;

        public CatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCatalogsQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCatalogByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCatalogCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCatalogCommand command)
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
        public async Task<IActionResult> Delete(Guid id, DeleteCatalogCommand command)
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
