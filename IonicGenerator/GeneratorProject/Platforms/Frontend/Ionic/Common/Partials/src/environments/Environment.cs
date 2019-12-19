using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Environment: TemplateBase
    {
        public Environment(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\environments\\environment.ts";
    }
}
