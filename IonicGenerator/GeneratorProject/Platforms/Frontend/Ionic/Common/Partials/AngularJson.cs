using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AngularJson: TemplateBase
    {
        public AngularJson(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "angular.json";
    }
}
