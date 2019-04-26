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
        
        public override string Rel
        {
            get { return "adsChannels"; }
            set { }
        }
        
        public override string Href
        {
            get { return LinkTemplates.V1.Ads.GetChannels.CreateLink(new { id = 1 }).Href; }
            set { }
        }
        
        protected override void CreateHypermedia()
        {
            Links.Add(new Link { Href = uriTemplate.Href, Rel = "self"});
        }
    }
}