using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// HAL representation of the Channel
    /// </summary>
    public class ChannelRepresentation : Representation
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public override string Rel
        {
            get { return LinkTemplates.V1.Channels.GetChannels.Rel; }
            set { }
        }

        public override string Href
        {
            get { return LinkTemplates.V1.Channels.GetChannel.CreateLink(new { id = Id }).Href; }
            set { }
        }
        
        protected override void CreateHypermedia()
        {
            base.CreateHypermedia();
            Links.Add(LinkTemplates.V1.Channels.GetChannels.CreateLink());
        }
    }
}