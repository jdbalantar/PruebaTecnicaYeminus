using System.Net;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Domain;
using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using FluentValidation;
using MediatR;

namespace EncryptionSoftware.Application.Product
{
    public class CreateProduct
    {
        public class CommandCreateProduct : IRequest
        {
            public string Descripcion { get; set; }
            public List<int> ListaDePrecios { get; set; }
            public string Imagen { get; set; }
            public bool ProductoParaLaVenta { get; set; }
            public int Iva { get; set; }
        }

        public class CommandValidator : AbstractValidator<CommandCreateProduct>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Descripcion).NotEmpty().WithMessage("El campo es requerido");
                RuleFor(x => x.Imagen).NotEmpty().WithMessage("El campo es requerido");
                RuleFor(x => x.Iva).NotEmpty().WithMessage("El campo es requerido");
                RuleFor(x => x.ListaDePrecios).NotEmpty().WithMessage("El campo es requerido");

                RuleFor(x => x).Must(x => x.ListaDePrecios.Count > 0)
                    .WithMessage("El campo es requerido")
                    .OverridePropertyName("ListaDePrecios");
            }
        }

        public class Handler : IRequestHandler<CommandCreateProduct>
        {
            private readonly EncryptionSoftwareContext _context;

            public Handler(EncryptionSoftwareContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandCreateProduct request, CancellationToken cancellationToken)
            {
                var product = new Productos
                {
                    Descripcion = request.Descripcion,
                    ProductoParaLaVenta = request.ProductoParaLaVenta,
                    Iva = request.Iva
                };

                if (Util.ImgUrlIsValid(request.Imagen))
                    product.Imagen = request.Imagen;
                else
                    throw new RestException(HttpStatusCode.BadRequest,
                        "La Url de la imágen es inválida. Inténtelo nuevamente");

                if (product.ListaDePrecios is { Count: > 0 })
                {
                    foreach (var precio in request.ListaDePrecios)
                    {
                        product.ListaDePrecios.Add(precio);
                    }
                }
                else
                    product.ListaDePrecios?.Add(0);

                _context.Productos.Add(product);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo realizar la operación solicitada");
            }
        }
    }
}