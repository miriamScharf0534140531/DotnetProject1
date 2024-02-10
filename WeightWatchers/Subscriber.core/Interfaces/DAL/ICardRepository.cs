using Subscriber.core.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.DAL
{
    public interface ICardRepository
    {
        public bool IsExistId(int id);
        public Task<BaseResponseGeneral<GetCardByIdRes>> getCard(int id);

    }
}
