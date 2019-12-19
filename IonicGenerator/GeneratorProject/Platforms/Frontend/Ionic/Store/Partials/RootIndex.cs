using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class RootIndex: TemplateBase
    {
        private SchemaArray<ApiInfo> apiList { get; set; }
        public RootIndex(SmartAppInfo smartApp) : base(smartApp)
        {
            apiList = smartApp.Api;
        }
        public override string OutputPath => "src\\app\\store\\index.ts";
    }
}
