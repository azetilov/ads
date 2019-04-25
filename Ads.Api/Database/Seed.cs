using System.Collections.Generic;
using System.Linq;
using Ads.Api.Database.Entities;

namespace Ads.Api.Database
{
    /// <summary>
    /// Initial data for development and testing purposes
    /// </summary>
    internal static class Seed
    {
        /// <summary>
        /// Adds advertisements to the database context
        /// </summary>
        /// <param name="context"></param>
        internal static void Ads(AdsContext context)
        {
            context.Ads.AddRange(new[]
            {
                new Ad()
                {
                    Name = ".NET Core"
                },
                new Ad()
                {
                    Name = "ASP.NET Core"
                },
                new Ad()
                {
                    Name = "EF Core"
                }
            });
            context.SaveChanges();
        }

        /// <summary>
        /// Adds channels to the database context
        /// </summary>
        /// <param name="context"></param>
        internal static void Channels(AdsContext context)
        {
            context.Channels.AddRange(new[]
            {
                new Channel()
                {
                    Name = "GDN"
                },
                new Channel()
                {
                    Name = "Email"
                },
                new Channel()
                {
                    Name = "Facebook"
                }
            });
            context.SaveChanges();
        }

        /// <summary>
        /// Adds ad channels to the database context
        /// </summary>
        /// <param name="context"></param>
        internal static void AdChannels(AdsContext context)
        {
            var ads = context.Ads.ToList();
            var channels = context.Channels.ToList();
            ads.ForEach(ad =>
            {
                channels.ForEach(channel =>
                {
                    context.AdChannels.Add(new AdChannel()
                    {
                        Name = string.Join("-", ad.Name, channel.Name),
                        Ad = ad,
                        Channel = channel
                    });
                });
                
            });
            context.SaveChanges();
        }
    }
}