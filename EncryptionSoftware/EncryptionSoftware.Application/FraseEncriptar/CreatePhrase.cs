using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using MediatR;

namespace EncryptionSoftware.Application.FraseEncriptar
{
    public class CreatePhrase
    {
        public class CommandEncriptPhrase : IRequest
        {
            public string Frase { get; set; }
            public int Clave { get; set; }
        }

        public class Handler : IRequestHandler<CommandEncriptPhrase>
        {
            private readonly EncryptionSoftwareContext _context;

            public Handler(EncryptionSoftwareContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandEncriptPhrase request, CancellationToken cancellationToken)
            {
                var phrase = new Domain.Frases { Frase = Util.Encrypt(request.Frase, request.Clave) };

                _context.Frases.Add(phrase);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new NotImplementedException();
            }
        }
    }
}