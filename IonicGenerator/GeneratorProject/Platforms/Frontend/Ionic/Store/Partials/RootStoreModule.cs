using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class RootStoreModule: TemplateBase
    {
        private SchemaArray<ApiInfo> apiList { get; set; }
        public RootStoreModule(SmartAppInfo smartApp) : base(smartApp)
        {
            apiList = smartApp.Api;
        }
        public override string OutputPath => "src\\app\\store\\root-store.module.ts";
    }
}
