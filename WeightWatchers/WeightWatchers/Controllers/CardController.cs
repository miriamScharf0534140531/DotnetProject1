using Microsoft.AspNetCore.Mvc;
using Subscriber.core.Interfaces.BL;
using Subscriber.core.Response;

namespace WeightWatchers.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<BaseResponseGeneral<GetCardByIdRes>> GetCardById(int id)
        {
            return await _cardService.getCard(id);
        }
    }
}
