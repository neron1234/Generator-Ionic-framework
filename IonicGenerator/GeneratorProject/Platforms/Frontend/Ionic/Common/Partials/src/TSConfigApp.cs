using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TSConfigApp: TemplateBase
    {
        public TSConfigApp(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\tsconfig.app.json";
    }
}
