using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DocReloadBug.Swagger
{
    public class BasePathDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var version = "v1";

            swaggerDoc.BasePath = "/" + version;

            foreach (var description in context.ApiDescriptions)
            {
                if (description.RelativePath.StartsWith(version))
                {
                    var pathComponents = description.RelativePath.Split('/');
                    description.RelativePath = string.Join("/", pathComponents.Skip(1));
                }
            }
        }
    }
}
