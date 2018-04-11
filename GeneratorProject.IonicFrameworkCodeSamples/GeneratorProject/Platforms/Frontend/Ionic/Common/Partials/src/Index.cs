using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    [Generator(ActivityName = Constants.CommonActivityName, Order = 5)]
    public partial class Index : TemplateBase
    {
        public Index(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "src\\index.html";
    }
}
