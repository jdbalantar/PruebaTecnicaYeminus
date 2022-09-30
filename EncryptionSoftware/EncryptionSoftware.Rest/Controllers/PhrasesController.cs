using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Application.FraseEncriptar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionSoftware.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhrasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<FrasesDto>>> GetAllPhrases()
        {
            return await _mediator.Send(new GetPhrases.QueryGetPhrases());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FrasesDto>> GetPhrase(int id)
        {
            return await _mediator.Send(new Getphrase.QueryGetPhrase { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreatePhraseEncrypt(CreatePhrase.CommandEncriptPhrase data)
        {
            return await _mediator.Send(data);
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult<Unit>> UpdatePhraseDecrypt(int id)
        {
            return await _mediator.Send(new DecryptPhrase.CommandDecryptPhrase { Id = id });
        }
    }
}