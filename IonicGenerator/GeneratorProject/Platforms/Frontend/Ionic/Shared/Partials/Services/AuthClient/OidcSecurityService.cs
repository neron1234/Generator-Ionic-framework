using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class OidcSecurityService : TemplateBase
    {
        public OidcSecurityService(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\shared\\services\\auth-client\\oidc-security.service.ts";
    }
}
