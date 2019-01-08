using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class IonicConfig : TemplateBase
    {
        public IonicConfig(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "ionic.config.json";
    }
}
