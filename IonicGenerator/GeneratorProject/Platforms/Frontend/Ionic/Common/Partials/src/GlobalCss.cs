using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class GlobalCss: TemplateBase
    {
        public GlobalCss(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\global.scss";
    }
}
