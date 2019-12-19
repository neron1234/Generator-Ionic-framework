using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LoadingService: TemplateBase
    {
        public LoadingService(SmartAppInfo smartApp) : base(smartApp)
        {

        }
        public override string OutputPath => "src\\app\\shared\\services\\common\\loadingService.ts";
    }
}
