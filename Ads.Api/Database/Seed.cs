using System.Collections.Generic;
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
    }
}