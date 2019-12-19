using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Variables: TemplateBase
    {
        public Variables(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\themes\\variables.scss";
    }
}
