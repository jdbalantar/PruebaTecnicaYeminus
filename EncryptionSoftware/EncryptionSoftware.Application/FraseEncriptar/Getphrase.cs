using AutoMapper;
using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Application.ErrorHandler;
using EncryptionSoftware.Persistence;
using MediatR;
using System.Net;

namespace EncryptionSoftware.Application.FraseEncriptar
{
    public class Getphrase
    {
        public class QueryGetPhrase : IRequest<FrasesDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<QueryGetPhrase, FrasesDto>
        {
            private readonly EncryptionSoftwareContext _context;
            private readonly IMapper _mapper;

            public Handler(EncryptionSoftwareContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FrasesDto> Handle(QueryGetPhrase request, CancellationToken cancellationToken)
            {
                var phrase = await _context.Frases.FindAsync(request.Id);
                if (phrase == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"No se encontró ninguna frase encriptada, asociada al id {request.Id}. Inténtelo  nuevamente"
                        });

                var phraseDto = _mapper.Map<FrasesDto>(phrase);
                return phraseDto;
            }
        }
    }
}