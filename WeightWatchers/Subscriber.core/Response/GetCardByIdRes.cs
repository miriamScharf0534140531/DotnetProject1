using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.core.Response
{
    public class GetCardByIdRes
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float Bmi { get; set; }
    }
}
