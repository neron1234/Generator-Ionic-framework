using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class RootState: TemplateBase
    {
        public RootState(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\app\\store\\root.state.ts";
    }
}
