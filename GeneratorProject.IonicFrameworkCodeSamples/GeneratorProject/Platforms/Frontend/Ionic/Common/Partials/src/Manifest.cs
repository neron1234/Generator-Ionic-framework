using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    [Generator(ActivityName = Constants.CommonActivityName, Order = 4)]
    public partial class Manifest : TemplateBase
    {
        public Manifest(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "src\\manifest.json";
    }
}
