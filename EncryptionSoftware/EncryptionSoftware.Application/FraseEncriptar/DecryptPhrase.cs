using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using MediatR;
using System.Net;
using FluentValidation;

namespace EncryptionSoftware.Application.FraseEncriptar
{
    public class DecryptPhrase
    {
        public class CommandDecryptPhrase : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<DecryptPhrase.CommandDecryptPhrase>
        {
            private readonly EncryptionSoftwareContext _context;

            public Handler(EncryptionSoftwareContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDecryptPhrase request, CancellationToken cancellationToken)
            {
                var phraseEncrypted = await _context.Frases.FindAsync(request.Id);
                if (phraseEncrypted == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"No se encontró ninguna frase encriptada, asociada al id {request.Id}. Inténtelo  nuevamente"
                        });

                var frase = new string(phraseEncrypted.Frase);

                var phraseDecrypted = Util.Decrypt(frase, 5);
                phraseEncrypted.Frase = phraseDecrypted;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("No se pudo ejecutar la operación solicitada");
            }
        }
    }
}