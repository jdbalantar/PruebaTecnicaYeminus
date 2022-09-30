using AutoMapper;
using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Persistence;
using MediatR;
using System.Net;

namespace EncryptionSoftware.Application.Product
{
    public class GetProductById
    {
        public class QueryGetProductById : IRequest<ProductDto>
        {
            public int Codigo { get; set; }
        }

        public class Handler : IRequestHandler<QueryGetProductById, ProductDto>
        {
            private readonly IMapper _mapper;
            private readonly EncryptionSoftwareContext _context;

            public Handler(IMapper mapper, EncryptionSoftwareContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ProductDto> Handle(QueryGetProductById request, CancellationToken cancellationToken)
            {
                var product = await _context.Productos.FindAsync(request.Codigo);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"No se encontró producto asociado al id {request.Codigo}. Inténtelo nuevamente"
                        });

                var productDto = _mapper.Map<ProductDto>(product);
                return productDto;
            }
        }
    }
}