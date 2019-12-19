using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FilteringService: TemplateBase
    {
        public FilteringService(SmartAppInfo smartApp) : base(smartApp)
        {

        }
        public override string OutputPath => "src\\app\\shared\\pipes\\filteringService.ts";
    }
}
