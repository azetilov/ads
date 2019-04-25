using System.Collections.Generic;
using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// HAL representation of the list of advertisements
    /// </summary>
    public class AdChannelsListRepresentation : SimpleListRepresentation<AdChannelRepresentation>
    {
        private readonly Link uriTemplate;

        public AdChannelsListRepresentation(IList<AdChannelRepresentation> res, int totalResults, Link uriTemplate)
            : base(res)
        {
            this.uriTemplate = uriTemplate;
            TotalResults = totalResults;
        }

        public int TotalResults { get; set; }

        protected object UriTemplateSubstitutionParams;

        protected override void CreateHypermedia()
        {
            Links.Add(new Link { Href = Href, Rel = "self" });
        }
    }
}