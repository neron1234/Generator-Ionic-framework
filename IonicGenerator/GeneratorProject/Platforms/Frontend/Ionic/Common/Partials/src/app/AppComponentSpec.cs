using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppComponentSpec: TemplateBase
    {
        public AppComponentSpec(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\app.component.spec.ts";
    }
}
