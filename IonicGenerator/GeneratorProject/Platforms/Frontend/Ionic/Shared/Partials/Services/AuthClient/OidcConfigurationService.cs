using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class OidcConfigurationService : TemplateBase
    {
        public OidcConfigurationService(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => @"src\app\shared\services\auth-client\oidc-configuration.service.ts";
    }
}

