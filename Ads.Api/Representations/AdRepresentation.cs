using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// HAL representation of the advertisement
    /// </summary>
    public class AdRepresentation : Representation
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public override string Rel
        {
            get { return LinkTemplates.V1.Ads.GetAds.Rel; }
            set { }
        }

        public override string Href
        {
            get { return LinkTemplates.V1.Ads.GetAd.CreateLink(new { id = Id }).Href; }
            set { }
        }
        
        protected override void CreateHypermedia()
        {
            base.CreateHypermedia();
            Links.Add(LinkTemplates.V1.Ads.GetAds.CreateLink());
            Links.Add(LinkTemplates.V1.Ads.GetChannels.CreateLink(new { id = Id }));
        }
    }
}

    