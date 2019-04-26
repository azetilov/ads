using System.Linq;
using Ads.Api.Database;
using Ads.Api.Database.Entities;
using Ads.Api.Representations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ads.Api.Controllers
{
    /// <summary>
    /// RESTful service for advertisement channels management
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/ads/{adId}/channels")]
    [ApiController]
    [Produces("application/hal+json")]
    public class AdChannelsController : Controller
    {
        private readonly AdsContext _context;

        /// <summary>
        /// Constructor of the advertisement channel service controller
        /// </summary>
        /// <param name="context">Database context</param>
        public AdChannelsController(AdsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all advertisement channels
        /// </summary>
        /// <response code="200">All advertisement channels</response>
        /// <response code="404">Channels not found</response>
        /// <returns>All advertisement channels</returns>
        [HttpGet]
        public ActionResult<AdChannelsListRepresentation> GetChannels([FromRoute] long adId)
        {
            var adChannels = _context.AdChannels.AsNoTracking()
                .Where(a => a.AdId == adId)
                .Select(a => new AdChannelRepresentation
                {
                    Id = a.Id,
                    Name = a.Name,
                    AdId = a.AdId,
                    ChannelId = a.ChannelId
                })
                .ToList();
            return new AdChannelsListRepresentation(
                adChannels, 
                adChannels.Count, 
                //LinkTemplates.V1.Ads.GetChannels.CreateLink(new {id = adId})
                LinkTemplates.V1.Ads.GetAds.CreateLink()
            );
        }

        /// <summary>
        /// Returns advertisement channel by Id
        /// </summary>
        /// <response code="200">Advertisement channel</response>
        /// <response code="404">Advertisement channel not found</response>
        /// <returns>Advertisement channel</returns>
        [HttpGet("{id:long}")]
        public ActionResult<AdChannelRepresentation> GetChannel([FromRoute] long adId, [FromRoute] long id)
        {
            var adChannel = _context.AdChannels.AsNoTracking()
                .Where(a => a.Id == id && a.AdId == adId)
                .Select(a => new AdChannelRepresentation
                {
                    Id = a.Id,
                    Name = a.Name,
                    AdId = a.AdId,
                    ChannelId = a.ChannelId
                })
                .FirstOrDefault();
            if (adChannel == null)
            {
                return NotFound();
            }
            return adChannel;
        }

        /// <summary>
        /// Updates advertisement channel by Id
        /// </summary>
        /// <response code="201">Advertisement channel created. See location header.</response>
        /// <response code="404">Advertisement channel not found</response>
        /// <returns>Advertisement channel</returns>
        [HttpPost]
        public ActionResult Create(
            [FromRoute] string version,
            [FromRoute] long adId,
            [FromBody] CreateAdChannel adChannel)
        {
            var channel = _context.Channels.FirstOrDefault(a => a.Id == adChannel.Channel.Id);
            var ad = _context.Ads.FirstOrDefault(a => a.Id == adId);

            if (channel == null || ad == null)
            {
                return NotFound();
            }
            var created = _context.AdChannels.Add(new AdChannel
            {
                Name = adChannel.Name,
                Channel = channel,
                Ad = ad
            });
            var result = new AdChannelRepresentation
            {
                Id = created.Entity.Id,
                Name = adChannel.Name,
                AdId = ad.Id,
                ChannelId = channel.Id
            };
            _context.SaveChanges();
            return CreatedAtAction("GetChannel", new { adId, id = created.Entity.Id, version }, result);
        }

        /// <summary>
        /// Updates advertisement channel by Id
        /// </summary>
        /// <response code="200">Advertisement channel</response>
        /// <response code="404">Advertisement channel not found</response>
        /// <returns>Advertisement channel</returns>
        [HttpPut("{id:long}")]
        public StatusCodeResult Update(
            [FromRoute] long adId,
            [FromRoute] long id,
            [FromBody] AdChannelRepresentation channel)
        {
            var adChannel = _context.AdChannels.FirstOrDefault(a => a.Id == id && a.AdId == adId);

            if (adChannel == null)
            {
                return NotFound();
            }
            adChannel.Name = channel.Name;
            _context.AdChannels.Update(adChannel);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Deletes advertisement channel by Id
        /// </summary>
        /// <response code="200">Advertisement channel</response>
        /// <response code="404">Advertisement channel not found</response>
        /// <returns>Advertisement channel</returns>
        [HttpDelete("{id:long}")]
        public StatusCodeResult Delete(
            [FromRoute] long adId,
            [FromRoute] long id)
        {
            var adChannel = _context.AdChannels.FirstOrDefault(a => a.Id == id && a.AdId == adId);

            if (adChannel == null)
            {
                return NotFound();
            }
            _context.AdChannels.Remove(adChannel);
            _context.SaveChanges();
            return Ok();
        }
    }
}