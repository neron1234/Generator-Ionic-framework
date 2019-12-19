using Mobioos.Foundation.Jade.Models;
using Common.Generator.Framework.Extensions;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FeatureStoreModule: TemplateBase
    {
        private string _apiSuffix { get; set; }
        private ApiInfo _api { get; set; }

        public FeatureStoreModule(SmartAppInfo smartApp, ApiInfo api, string apiSuffix) : base(smartApp)
        {
            _api = api;
            _apiSuffix = apiSuffix;
        }
        public override string OutputPath => "src\\app\\store\\" + _api.Id.ToCamelCase() + "\\" + _api.Id.ToCamelCase() + "-store.module.ts";
    }
}
