using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class IonicConfig: TemplateBase
    {
         public IonicConfig(SmartAppInfo smartApp) : base(smartApp)
        {
           
        }
        public override string OutputPath => "ionic.config.json";
    }
}
