using Subscriber.core.DTO;
using Subscriber.core.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Interfaces.DAL
{
    public interface ISubsciberRepository
    {
        Task<BaseResponse> add(SubscriberTable s,float f);
        Task<BaseResponseGeneral<int>> login(LoginDTO l);
        public bool IsExistEmail(string mail);
        public bool IsInvalidLogin(LoginDTO l);
    }
}
