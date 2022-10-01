using System.Net;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using MediatR;

namespace EncryptionSoftware.Application.Product
{
    public class EditProduct
    {
        public class CommandEditProduct : IRequest
        {
            public int Codigo { get; set; }
            public string Descripcion { get; set; }
            public List<int> ListaDePrecios { get; set; }
            public string Imagen { get; set; }
            public bool? ProductoParaLaVenta { get; set; }
            public int? Iva { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditProduct>
        {
            private readonly EncryptionSoftwareContext _context;
            private readonly IUtil _util;

            public Handler(EncryptionSoftwareContext context, IUtil util)
            {
                _context = context;
                _util = util;
            }

            public async Task<Unit> Handle(CommandEditProduct request, CancellationToken cancellationToken)
            {
                var product = await _context.Productos.FindAsync(request.Codigo);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"No se encontró producto asociado al id {request.Codigo}. Inténtelo nuevamente"
                        });

                if (_util.ImgUrlIsValid(request.Imagen))
                    product.Imagen = request.Imagen;
                else
                    throw new RestException(HttpStatusCode.BadRequest,
                        "La Url de la imágen es inválida. Inténtelo nuevamente");

                product.Descripcion = request.Descripcion ?? product.Descripcion;
                product.ProductoParaLaVenta = request.ProductoParaLaVenta ?? product.ProductoParaLaVenta;
                product.Iva = request.Iva ?? product.Iva;


                foreach (var precio in request.ListaDePrecios)
                {
                    product.ListaDePrecios.Add(precio);
                }

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo realizar la operación solicitada");
            }
        }
    }
}