using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class EnvironmentProd: TemplateBase
    {
        public EnvironmentProd(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\environments\\environment.prod.ts";
    }
}
