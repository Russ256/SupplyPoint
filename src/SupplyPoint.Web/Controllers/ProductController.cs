namespace SupplyPoint.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SupplyPoint.Application.Commands.Products;
    using SupplyPoint.Application.Queries;

    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductQueries queries;
        IMediator mediator;

        public ProductController(IMediator mediator, IProductQueries queries)
        {
            this.mediator = mediator;
            this.queries = queries;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductDto>> Products()
        {
            return await this.queries.GetProductsAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody]CreateRequest request)
        {
            return new JsonResult(await this.mediator.Send(request));
        }
    }
}