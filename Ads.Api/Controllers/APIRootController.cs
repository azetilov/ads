using System;
using System.Linq;
using Ads.Api.Representations;
using Microsoft.AspNetCore.Mvc;
using WebApi.Hal;

namespace Ads.Api.Controllers
{
    /// <summary>
    /// RESTful service for advertisement channels management
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/")]
    [ApiController]
    [Produces("application/hal+json")]
    public class APIRootController: Controller
    {
        [HttpGet]
        public ActionResult<APIRoot> Get()
        {
            return new APIRoot((new []
            {
                LinkTemplates.V1.Ads.GetAds.CreateLink(),
                LinkTemplates.V1.Ads.GetAd.CreateLink(new { id = "{id}" }),
                LinkTemplates.V1.Ads.GetChannels.CreateLink(new { id = "{id}" }),
                LinkTemplates.V1.Ads.GetChannel.CreateLink(new { id = "{id}", channelId = "{channelId}" }),
                LinkTemplates.V1.Channels.GetChannels.CreateLink(),
                LinkTemplates.V1.Channels.GetChannel.CreateLink(new { id = "{id}" })
            }).Select(Unescape));
        }

        private static Link Unescape(Link link)
        {
            link.Href = Uri.UnescapeDataString(link.Href).TrimStart('~');
            return link;
        }
    }
}