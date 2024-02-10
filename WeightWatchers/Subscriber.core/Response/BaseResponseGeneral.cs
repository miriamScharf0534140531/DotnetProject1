using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Response
{
    public class BaseResponseGeneral<T>:BaseResponse
    {
        public T ?Data { get; set; }
    }
}
