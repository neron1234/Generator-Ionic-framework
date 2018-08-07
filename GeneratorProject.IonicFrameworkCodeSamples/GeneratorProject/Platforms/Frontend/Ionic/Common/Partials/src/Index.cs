using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Index : TemplateBase
    {
        public Index(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "src\\index.html";
    }
}
