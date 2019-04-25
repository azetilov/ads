using System.Collections.Generic;
using WebApi.Hal;

namespace Ads.Api.Representations
{
    public class ChannelsListRepresentation : SimpleListRepresentation<ChannelRepresentation>
    {
        private readonly Link uriTemplate;

        public ChannelsListRepresentation(IList<ChannelRepresentation> res, int totalResults, Link uriTemplate)
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