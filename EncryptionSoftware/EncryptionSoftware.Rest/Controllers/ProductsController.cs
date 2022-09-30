using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Application.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionSoftware.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProudcts()
        {
            return await _mediator.Send(new GetProducts.QueryGetProducts());
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int codigo)
        {
            return await _mediator.Send(new GetProductById.QueryGetProductById { Codigo = codigo });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> NewProduct(CreateProduct.CommandCreateProduct data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{codigo:int}")]
        public async Task<ActionResult<Unit>> UpdateProduct(int codigo, EditProduct.CommandEditProduct data)
        {
            data.Codigo = codigo;
            return await _mediator.Send(data);
        }
    }
}