using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Main: TemplateBase
    {
        public Main(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\main.ts";
    }
}
