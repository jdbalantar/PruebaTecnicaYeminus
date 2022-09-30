using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Persistence;
using MediatR;
using System.Net;

namespace EncryptionSoftware.Application.FraseEncriptar
{
    public class DeletePhrase
    {
        public class CommandDeletePhrase : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeletePhrase>
        {
            private readonly EncryptionSoftwareContext _context;

            public Handler(EncryptionSoftwareContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeletePhrase request, CancellationToken cancellationToken)
            {
                var phrase = await _context.Frases.FindAsync(request.Id);
                if (phrase == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"No se encontró ninguna frase encriptada, asociada al id {request.Id}. Inténtelo  nuevamente"
                        });

                _context.Frases.Remove(phrase);

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo ejecutar la operación solicitada");
            }
        }
    }
}