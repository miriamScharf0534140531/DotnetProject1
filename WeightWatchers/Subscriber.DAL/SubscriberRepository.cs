using Subscriber.Data.Entities;
using Subscriber.core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscriber.Data;
using Subscriber.core.Response;
using Subscriber.core.DTO;

namespace Subscriber.DAL
{
    public class SubscriberRepository : ISubsciberRepository
    {
        readonly WeightWatcherContext _weightWatcherContext;

        public SubscriberRepository(WeightWatcherContext weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }
        public async Task<BaseResponse> add(SubscriberTable s,float height)
        {
            BaseResponseGeneral<bool> res = new BaseResponseGeneral<bool>();
            _weightWatcherContext.Subscribers.AddAsync(s);
            _weightWatcherContext.SaveChangesAsync();
            var card = new CardTable
            {
                SubscriberId = s.Id,
                OpenDate = DateTime.Now,
                Bmi = 0,
                Height = height,
                Weight = 0,
                UpdateDate = DateTime.Now,
            };
            _weightWatcherContext.Cards.AddAsync(card);
            _weightWatcherContext.SaveChangesAsync();
            res.Succeed = true;
            res.Message = "Secceed!!!!!!!";
            return res;
        }
        public bool IsInvalidLogin(LoginDTO l)
        {
            return _weightWatcherContext.Subscribers.Where(t => t.Email == l.Email && t.Password == l.Password).Any();
        }


        public bool IsExistEmail(string mail)
        {
            return _weightWatcherContext.Subscribers.Where(t => t.Email == mail).Any();
        }


        public async Task<BaseResponseGeneral<int>> login(LoginDTO l)
        {
            BaseResponseGeneral<int> res = new BaseResponseGeneral<int>();
                res.Data = _weightWatcherContext.Subscribers.Where(x => x.Email == l.Email && x.Password == l.Password).First().Id;
                res.Message = "nice!!!!!!!!!!";
            return res;

        }
    }
}
