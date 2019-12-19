using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class SettingsStyleSheet: TemplateBase
    {
        public SettingsStyleSheet(SmartAppInfo smartApp) : base(smartApp)
        {
           
        }
        public override string OutputPath => "src\\app\\pages\\appsettings\\app-settings.page.scss";
    }
}
