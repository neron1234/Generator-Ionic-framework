using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppComponent: TemplateBase
    {
        public AppComponent(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\app.component.ts";
    }
}
