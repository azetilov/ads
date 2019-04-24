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
                public static Link GetAds { get { return new Link("ads", "~/api/v1/ads"); } }

                /// <summary>
                /// /ads/{id}
                /// </summary>
                public static Link GetAd { get { return new Link("ad", "~/api/v1/ads/{id}"); } }
            }
        }
    }
}