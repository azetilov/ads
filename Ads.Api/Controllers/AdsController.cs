using System.Collections.Generic;
using System.Linq;
using Ads.Api.Database;
using Ads.Api.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ads.Api.Controllers
{
    /// <summary>
    /// RESTful service for advertisement management
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly AdsContext _context;

        /// <summary>
        /// Constructor of the advertisement service controller
        /// </summary>
        /// <param name="context">Database context</param>
        public AdsController(AdsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a particular advertisement
        /// </summary>
        /// <param name="id">Identifier of the advertisement</param>
        /// <response code="200">The advertisement was found.</response>
        /// <response code="404">The advertisement was not found.</response>
        /// <returns>The requested advertisement</returns>
        [HttpGet("{id:long}")]
        public ActionResult<Ad> Get(long id)
        {
            var result = _context.Ads.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        
        /// <summary>
        /// Returns all advertisements
        /// </summary>
        /// <response code="200">All advertisements</response>
        /// <returns>All advertisement</returns>
        [HttpGet]
        public IEnumerable<Ad> GetAll()
        {
            return _context.Ads.AsNoTracking().ToList();
        }

        /// <summary>
        /// Creates a new advertisement
        /// </summary>
        /// <param name="version">Version of the service</param>
        /// <param name="ad">The advertisement to create</param>
        /// <response code="201">The advertisement was created. See Location header.</response>
        /// <response code="404">The advertisement was not found.</response>
        [HttpPost]
        public CreatedAtActionResult Post([FromRoute] string version, [FromBody] Ad ad)
        {
            ad.Id = default(long);
            var result = _context.Ads.Add(ad);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = result.Entity.Id, version }, ad);
        }

        /// <summary>
        /// Updates a particular advertisement
        /// </summary>
        /// <param name="id">Identifier of the advertisement</param>
        /// <param name="ad">The updated advertisement</param>
        /// <response code="200">The advertisement was updated.</response>
        /// <response code="404">The advertisement was not found.</response>
        /// <returns>200 OK on success</returns>
        [HttpPut("{id:long}")]
        public StatusCodeResult Put(long id, [FromBody] Ad ad)
        {
            ad.Id = default(long);
            var exists = _context.Ads.Any(a => a.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            ad.Id = id;
            _context.Ads.Update(ad);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Deletes a particular advertisement
        /// </summary>
        /// <param name="id">Identifier of an advertisement</param>
        /// <response code="200">The advertisement was deleted.</response>
        /// <response code="404">The advertisement was not found.</response>
        /// <returns>200 OK on success</returns>
        [HttpDelete("{id:long}")]
        public ActionResult Delete(long id)
        {
            var ad = _context.Ads.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            _context.SaveChanges();
            return Ok();
        }
    }
}