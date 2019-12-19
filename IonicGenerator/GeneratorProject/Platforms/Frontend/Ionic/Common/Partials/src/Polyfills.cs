using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Polyfills: TemplateBase
    {
        public Polyfills(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\polyfills.ts";
    }
}
