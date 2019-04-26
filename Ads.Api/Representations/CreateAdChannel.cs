using System.ComponentModel.DataAnnotations;
using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// Representation to assign new advertisement channel
    /// </summary>
    public class CreateAdChannel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public ChannelRepresentation Channel { get; set; }
    }
}