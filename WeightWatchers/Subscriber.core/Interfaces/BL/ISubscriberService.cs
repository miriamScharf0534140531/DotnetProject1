using Subscriber.core.DTO;
using Subscriber.core.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.BL
{
    public interface ISubscriberService
    {
        Task<BaseResponse> add(SubscriberDTO s);
        Task<BaseResponseGeneral<int>> login(LoginDTO l);
    }
}
