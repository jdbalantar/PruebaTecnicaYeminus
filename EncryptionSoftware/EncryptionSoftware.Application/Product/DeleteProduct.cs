using System.Net;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Persistence;
using MediatR;

namespace EncryptionSoftware.Application.Product
{
    public class DeleteProduct
    {
        public class CommandDeleteProduct : IRequest
        {
            public int Codigo { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteProduct>
        {
            private readonly EncryptionSoftwareContext _context;

            public Handler(EncryptionSoftwareContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteProduct request, CancellationToken cancellationToken)
            {
                var product = await _context.Productos.FindAsync(request.Codigo);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"No se encontró producto asociado al id {request.Codigo}. Inténtelo nuevamente"
                        });

                _context.Productos.Remove(product);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo realizar la operación solicitada");
            }
        }
    }
}