using EncryptionSoftware.Persistence;
using MediatR;

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

            public Task<Unit> Handle(CommandDeletePhrase request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
