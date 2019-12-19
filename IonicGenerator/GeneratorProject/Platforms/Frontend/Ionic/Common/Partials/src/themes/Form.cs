using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Form: TemplateBase
    {
        public Form(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\themes\\form.scss";
    }
}
