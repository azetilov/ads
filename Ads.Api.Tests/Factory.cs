using Ads.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Ads.Api.Tests
{
    public class Factory
    {
            public AdsContext GetArticleDbContext()
            {
                var options = new DbContextOptionsBuilder<AdsContext>()
                    .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                    .Options;
                var dbContext = new AdsContext(options);

                return dbContext;
            }
    }
}