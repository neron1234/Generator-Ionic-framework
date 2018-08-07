using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Manifest : TemplateBase
    {
        public Manifest(SmartAppInfo smartApp) : base(smartApp)
        {
        }

        public override string OutputPath => "src\\manifest.json";
    }
}
