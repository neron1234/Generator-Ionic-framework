using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TSLint: TemplateBase
    {
        public TSLint(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "tslint.json";
    }
}
