using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TabsPageStyleSheet: TemplateBase
    {
        public TabsPageStyleSheet(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\pages\\apptabs\\app-tabs.page.scss";
    }
}
