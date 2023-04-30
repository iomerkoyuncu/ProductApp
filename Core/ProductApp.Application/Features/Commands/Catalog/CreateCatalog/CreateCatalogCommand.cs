using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Catalog.CreateCatalog
{
    public class CreateCatalogCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
