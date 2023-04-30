using MediatR;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.Catalog.DeleteCatalog
{
    public class DeleteCatalogCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
    }
}
