using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TSConfigAppSpec: TemplateBase
    {
        public TSConfigAppSpec(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\tsconfig.spec.json";
    }
}
