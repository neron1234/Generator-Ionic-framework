using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LoggerService: TemplateBase
    {
        public LoggerService(SmartAppInfo smartApp) : base(smartApp)
        {

        }
        public override string OutputPath => "src\\app\\shared\\services\\common\\loggerService.ts";
    }
}
