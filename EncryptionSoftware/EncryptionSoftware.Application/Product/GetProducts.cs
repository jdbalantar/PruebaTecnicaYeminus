using AutoMapper;
using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EncryptionSoftware.Application.Product
{
    public class GetProducts
    {
        public class QueryGetProducts : IRequest<List<ProductDto>>
        {
        }

        public class Handler : IRequestHandler<QueryGetProducts, List<ProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly EncryptionSoftwareContext _context;

            public Handler(IMapper mapper, EncryptionSoftwareContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<ProductDto>> Handle(QueryGetProducts request, CancellationToken cancellationToken)
            {
                var products = await _context.Productos.ToListAsync(cancellationToken: cancellationToken);
                var productsDto = _mapper.Map<List<ProductDto>>(products);
                return productsDto;
            }
        }
    }
}