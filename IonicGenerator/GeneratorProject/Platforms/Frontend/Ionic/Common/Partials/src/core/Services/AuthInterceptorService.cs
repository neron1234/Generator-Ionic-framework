using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AuthInterceptorService: TemplateBase
    {
        public AuthInterceptorService(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\core\\services\\auth-interceptor.service.ts";
    }
}
