using AutoMapper;
using Subscriber.core.DTO;
using Subscriber.Data.Entities;

namespace WeightWatchers.Config
{
    public class WeightWatdherProfile:Profile
    {
        public WeightWatdherProfile()
        {
            CreateMap<SubscriberTable,SubscriberDTO>().ForMember(x => x.Height, y=>y.Ignore()).ReverseMap();

        }

    }
}
