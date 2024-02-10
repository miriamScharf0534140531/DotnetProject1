using Subscriber.core.Interfaces.DAL;
using Subscriber.core.Response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class CardRepository : ICardRepository
    {
        readonly WeightWatcherContext _weightWatcherContext;

        public CardRepository(WeightWatcherContext weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }
        public bool IsExistId(int id)
        {
            return _weightWatcherContext.Subscribers.Where(t => t.Id == id).Any();

        }
        public async Task<BaseResponseGeneral<GetCardByIdRes>> getCard(int id)
        {
            
            CardTable c =_weightWatcherContext.Cards.Where(x => x.Id == id).First();
            SubscriberTable s=_weightWatcherContext.Subscribers.Where(x => x.Id == id).First();
            return new BaseResponseGeneral<GetCardByIdRes>()
            {
                Data = new GetCardByIdRes()
                {
                    FirstName = s.firstName,
                    LastName = s.lastName,
                    Weight = c.Weight,
                    Height = c.Height,
                    Bmi = c.Bmi,
                },
                Message="secceed!!!!!!",
                Succeed=true
            };
        }
    }
}
