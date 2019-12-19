using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppModule: TemplateBase
    {
        public AppModule(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\app.module.ts";
    }
}
