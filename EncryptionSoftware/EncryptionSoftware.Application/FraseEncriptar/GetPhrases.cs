using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Domain;
using EncryptionSoftware.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EncryptionSoftware.Application.FraseEncriptar
{
    public class GetPhrases
    {
        public class QueryGetPhrases : IRequest<List<FrasesDto>>
        {
        }

        public class Handler : IRequestHandler<QueryGetPhrases, List<FrasesDto>>
        {
            private readonly IMapper _mapper;
            private readonly EncryptionSoftwareContext _context;

            public Handler(IMapper mapper, EncryptionSoftwareContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<FrasesDto>> Handle(QueryGetPhrases request, CancellationToken cancellationToken)
            {
                var phrases = await _context.Frases.ToListAsync(cancellationToken: cancellationToken);
                var phrasesDto = _mapper.Map<List<FrasesDto>>(phrases);
                return phrasesDto;
            }
        }
    }
}