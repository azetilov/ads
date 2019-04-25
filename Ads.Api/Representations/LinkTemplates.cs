using WebApi.Hal;

namespace Ads.Api.Representations
{
    /// <summary>
    /// API link templates
    /// </summary>
    public class LinkTemplates
    {
        /// <summary>
        /// Version 1
        /// </summary>
        public static class V1
        {
            /// <summary>
            /// Ads link templates
            /// </summary>
            public static class Ads
            {
                /// <summary>
                /// /ads
                /// </summary>
                public static Link GetAds => new Link("ads", "~/api/v1/ads");

                /// <summary>
                /// /ads/{id}
                /// </summary>
                public static Link GetAd => new Link("ad", "~/api/v1/ads/{id}");

                /// <summary>
                /// /ads/{id}/channels
                /// </summary>
                public static Link GetChannels => new Link("channels", "~/api/v1/ads/{id}/channels");
            }

            /// <summary>
            /// Channels link templates
            /// </summary>
            public static class Channels
            {
                /// <summary>
                /// /channels
                /// </summary>
                public static Link GetChannels => new Link("channels", "~/api/v1/channels");

                /// <summary>
                /// /channels/{id}
                /// </summary>
                public static Link GetChannel => new Link("channel", "~/api/v1/channels/{id}");
            }
        }
    }
}