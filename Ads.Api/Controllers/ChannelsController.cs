using System.Linq;
using System.Net;
using Ads.Api.Database;
using Ads.Api.Representations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ads.Api.Controllers
{
    /// <summary>
    /// RESTful service for channel management
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/hal+json")]
    public class ChannelsController : ControllerBase
    {
        private readonly AdsContext _context;

        /// <summary>
        /// Constructor of the channel service controller
        /// </summary>
        /// <param name="context">Database context</param>
        public ChannelsController(AdsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a particular channel
        /// </summary>
        /// <param name="id">Identifier of the channel</param>
        /// <response code="200">The channel was found.</response>
        /// <response code="404">The channel was not found.</response>
        /// <returns>The requested channel</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ChannelRepresentation), (int)HttpStatusCode.OK)]
        public ActionResult<ChannelRepresentation> Get(long id)
        {
            var result = _context.Channels.AsNoTracking()
                .Select(a => new ChannelRepresentation()
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        
        /// <summary>
        /// Returns all channels
        /// </summary>
        /// <response code="200">All channels</response>
        /// <returns>All channels</returns>
        [HttpGet]
        public ActionResult<ChannelsListRepresentation> GetAll()
        {
            var channels = _context.Channels.AsNoTracking()
                .Select(a => new ChannelRepresentation()
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
            var representation = new ChannelsListRepresentation(
                channels, 
                channels.Count, 
                LinkTemplates.V1.Channels.GetChannels.CreateLink()
            );
            return representation;
        }

        /// <summary>
        /// Creates a new channel
        /// </summary>
        /// <param name="version">Version of the service</param>
        /// <param name="channel">The channel to create</param>
        /// <response code="201">The channel was created. See Location header.</response>
        /// <response code="404">The channel was not found.</response>
        [HttpPost]
        public CreatedAtActionResult Post([FromRoute] string version, [FromBody] Database.Entities.Channel channel)
        {
            channel.Id = default(long);
            var result = _context.Channels.Add(channel);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = result.Entity.Id, version }, channel);
        }

        /// <summary>
        /// Updates a particular channel
        /// </summary>
        /// <param name="id">Identifier of the channel</param>
        /// <param name="channel">The updated channel</param>
        /// <response code="200">The channel was updated.</response>
        /// <response code="404">The channel was not found.</response>
        /// <returns>200 OK on success</returns>
        [HttpPut("{id:long}")]
        public StatusCodeResult Put(long id, [FromBody] Ads.Api.Database.Entities.Channel channel)
        {
            channel.Id = default(long);
            var exists = _context.Channels.Any(a => a.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            channel.Id = id;
            _context.Channels.Update(channel);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Deletes a particular channel
        /// </summary>
        /// <param name="id">Identifier of an channel</param>
        /// <response code="200">The channel was deleted.</response>
        /// <response code="404">The channel was not found.</response>
        /// <returns>200 OK on success</returns>
        [HttpDelete("{id:long}")]
        public ActionResult Delete(long id)
        {
            var channel = _context.Channels.FirstOrDefault(a => a.Id == id);
            if (channel == null)
            {
                return NotFound();
            }

            _context.Channels.Remove(channel);
            _context.SaveChanges();
            return Ok();
        }
    }
}