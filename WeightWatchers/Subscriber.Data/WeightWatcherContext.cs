using Microsoft.EntityFrameworkCore;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data
{
    public class WeightWatcherContext:DbContext
    {
        public WeightWatcherContext(DbContextOptions<WeightWatcherContext> options) : base(options)
        {
        }
        public DbSet<SubscriberTable> Subscribers { get; set; }
        public DbSet<CardTable> Cards { get; set; }

    }
}
