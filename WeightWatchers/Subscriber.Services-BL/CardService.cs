using Subscriber.core.Interfaces.BL;
using Subscriber.core.Interfaces.DAL;
using Subscriber.core.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services_BL
{
    public class CardService : ICardService
    {
        readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<BaseResponseGeneral<GetCardByIdRes>> getCard(int id)
        {
            if(_cardRepository.IsExistId(id))
                return await _cardRepository.getCard(id);
            return new BaseResponseGeneral<GetCardByIdRes>() { Message = "not found!!!!!",Data=null };
        }
    }
}
