using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class BaseViewModelTemplate : TemplateBase
    {
        public BaseViewModelTemplate(SmartAppInfo smartApp) : base(smartApp)
        {

        }
        public override string OutputPath => "src\\app\\viewModels\\baseViewModel.ts";
    }
}
