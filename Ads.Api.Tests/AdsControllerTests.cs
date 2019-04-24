using System;
using System.Collections.Generic;
using System.Linq;
using Ads.Api.Controllers;
using Ads.Api.Database;
using Ads.Api.Database.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Ads.Api.Tests
{
    public class AdsControllerTests : IDisposable
    {
        private readonly AdsContext _dbContext;
        private readonly AdsController _adsController;
 
        public AdsControllerTests()
        {
            _dbContext = new Factory().GetArticleDbContext();
            _adsController = new AdsController(_dbContext);
        }

        public void Dispose()
        {
            // Cleanup
            _dbContext.Ads.RemoveRange(_dbContext.Ads.ToList());
            _dbContext.SaveChanges();
        }
        
        [Fact]
        public void WhenGettingById_ShouldReturnCorrectAd()
        {
            // Arrange
            var expected = new Ad {Id = 2, Name = "MWC"};
            var ads = new List<Ad>
            {
                new Ad { Id = 1, Name = "WWDC" },
                expected,
            };
            _dbContext.Ads.AddRange(ads);
            _dbContext.SaveChanges();

            // Act
            var actual = _adsController.Get(2);

            // Assert
            actual.Value.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void WhenGettingAll_ShouldReturnAllAds()
        {
            // Arrange
            var ads = new List<Ad>
            {
                new Ad { Id = 1, Name = "WWDC" },
                new Ad { Id = 2, Name = "MWC"},
            };
            _dbContext.Ads.AddRange(ads);
            _dbContext.SaveChanges();

            // Act
            var actual = _adsController.GetAll();

            // Assert
            actual.Should().BeEquivalentTo(ads);
        }
        
        [Fact]
        public void WhenAdDoesNotExist_ShouldReturnNotFound()
        {
            // Arrange
            var ads = new List<Ad>
            {
                new Ad { Id = 1, Name = "WWDC" }
            };
            _dbContext.Ads.AddRange(ads);
            _dbContext.SaveChanges();

            // Act
            var actual = _adsController.Get(2);

            // Assert
            actual.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}