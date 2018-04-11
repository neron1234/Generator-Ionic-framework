using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    [Generator(ActivityName = Constants.CommonActivityName, Order = 2)]
    public partial class IonicConfig : TemplateBase
    {
        public IonicConfig(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "ionic.config.json";
    }
}
