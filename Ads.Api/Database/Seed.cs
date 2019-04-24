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
    }
}