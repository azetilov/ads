using Ads.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ads.Api.Database
{
    public class AdsContext : DbContext
    {
        public AdsContext(DbContextOptions<AdsContext> options) : base(options)
        {
        }
        
        public DbSet<Ad> Ads { get; set; }
        
        public DbSet<Channel> Channels { get; set; }
        
        public DbSet<AdChannel> AdChannels { get; set; }
    }
}