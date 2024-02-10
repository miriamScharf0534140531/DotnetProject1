using AutoMapper;
using Subscriber.core.DTO;
using Subscriber.core.Interfaces.BL;
using Subscriber.core.Interfaces.DAL;
using Subscriber.core.Response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Services_BL
{
    public class SubscriberService : ISubscriberService
    {
        readonly ISubsciberRepository _subsciberRepository;
        readonly IMapper _mapper;

        public SubscriberService(ISubsciberRepository subsciberRepository,IMapper mapper)
        {
            _subsciberRepository = subsciberRepository;
            _mapper = mapper;
        }
        public async Task< BaseResponse> add(SubscriberDTO s)
        {
            if (!_subsciberRepository.IsExistEmail(s.Email))
            {
              return await _subsciberRepository.add(_mapper.Map<SubscriberTable>(s), s.Height);
            }
            return new BaseResponse() { Message = "Bad!!!!!!" };

        }

        public async Task<BaseResponseGeneral<int>> login(LoginDTO l)
        {
            if (_subsciberRepository.IsInvalidLogin(l))
            {
                return await _subsciberRepository.login(l);
            }
            return new BaseResponseGeneral<int>() { Message = "Bad!!!!!!",Data=-1 };
        }
    }
}
