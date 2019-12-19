using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TSLintJson: TemplateBase
    {
        public TSLintJson(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\tslint.json";
    }
}
