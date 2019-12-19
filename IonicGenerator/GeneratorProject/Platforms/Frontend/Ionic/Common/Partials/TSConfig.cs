using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TSConfig: TemplateBase
    {
        public TSConfig(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "tsconfig.json";
    }
}
