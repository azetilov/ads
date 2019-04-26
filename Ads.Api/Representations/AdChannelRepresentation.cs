using Newtonsoft.Json;
using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// HAL representation of advertisement channel
    /// </summary>
    public class AdChannelRepresentation : Representation
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        [JsonIgnore]
        public long AdId { get; set; }

        [JsonIgnore]
        public long ChannelId { get; set; }

        public override string Rel
        {
            get { return "adsChannels"; }
            set { }
        }

        public override string Href
        {
            get { return LinkTemplates.V1.Ads.GetChannel.CreateLink(new { id = AdId, channelId = Id }).Href; }
            set { }
        }
        
        protected override void CreateHypermedia()
        {
            base.CreateHypermedia();
            Links.Add(LinkTemplates.V1.Ads.GetAd.CreateLink(new { id = AdId }));
            Links.Add(LinkTemplates.V1.Ads.GetChannels.CreateLink(new { id = AdId }));
            Links.Add(LinkTemplates.V1.Channels.GetChannel.CreateLink(new { id = ChannelId }));
        }
    }
}