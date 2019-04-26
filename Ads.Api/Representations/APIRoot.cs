using System.Collections.Generic;
using Newtonsoft.Json;
using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// HAL representation of API root
    /// </summary>
    public class APIRoot
    {
        public APIRoot(IEnumerable<Link> links)
        {
            Links = links;
        }
        
        /// <summary>
        /// List of available affordances
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public IEnumerable<Link> Links { get; }
    }
}