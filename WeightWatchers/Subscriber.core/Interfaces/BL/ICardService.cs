using Subscriber.core.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.BL
{
    public interface ICardService
    {
        public Task<BaseResponseGeneral<GetCardByIdRes>> getCard(int id);
    }
}
