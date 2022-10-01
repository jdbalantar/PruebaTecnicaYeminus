using System.Net;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using FluentValidation;
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

        public class CommandValidator : AbstractValidator<CommandEncriptPhrase>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Frase).NotEmpty().WithMessage("Escriba la frase a encriptar");
                RuleFor(x => x.Clave).NotEmpty()
                    .WithMessage("Escriba la cantidad de caracteres usados para la encriptación");

                RuleFor(x => x).Must(x => x.Clave > 0)
                    .WithMessage("Escriba la cantidad de caracteres usados para la encriptación")
                    .OverridePropertyName("Clave");
            }
        }

        public class Handler : IRequestHandler<CommandEncriptPhrase>
        {
            private readonly EncryptionSoftwareContext _context;
            private readonly IUtil _util;

            public Handler(EncryptionSoftwareContext context, IUtil util)
            {
                _context = context;
                _util = util;
            }

            public async Task<Unit> Handle(CommandEncriptPhrase request, CancellationToken cancellationToken)
            {
                var phrase = new Domain.Frases {Frase = _util.Encrypt(request.Frase, request.Clave)};


                try
                {
                    _context.Frases.Add(phrase);
                }
                catch (Exception)
                {
                    throw new RestException(HttpStatusCode.InternalServerError,
                        new {message = "Lo sentimos. No pudimos encriptar su frase"});
                }

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo ejecutar la operación solicitada");
            }
        }
    }
}