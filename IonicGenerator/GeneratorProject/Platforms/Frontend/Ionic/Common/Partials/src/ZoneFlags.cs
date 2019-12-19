using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ZoneFlags: TemplateBase
    {
        public ZoneFlags(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\zone-flags.ts";
    }
}
