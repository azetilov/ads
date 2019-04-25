using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ads.Api
{
    /// <summary>
    /// Options for swagger generator
    /// </summary>
    public class SwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerOptions"/> class.
        /// </summary>
        public SwaggerOptions( IApiVersionDescriptionProvider provider ) => this._provider = provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerOptions"/> class.
        /// </summary>
        public void Configure( SwaggerGenOptions options )
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach ( var description in _provider.ApiVersionDescriptions )
            {
                options.SwaggerDoc( description.GroupName, CreateInfoForApiVersion( description ) );
            }
        }

        static Info CreateInfoForApiVersion( ApiVersionDescription description )
        {
            var info = new Info()
            {
                Title = "Advertisement API",
                Version = description.ApiVersion.ToString(),
                Description = "The advertisement API",
                License = new License() { Name = "MS-PL", Url = "https://opensource.org/licenses/MS-PL" }
            };

            if ( description.IsDeprecated )
            {
                info.Description += " This version is deprecated.";
            }

            return info;
        }
    }
}