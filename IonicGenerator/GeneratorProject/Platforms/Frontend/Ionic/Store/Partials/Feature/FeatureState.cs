using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FeatureState: TemplateBase
    {
        private string _modelSuffix { get; set; }
        private string _viewModelSuffix { get; set; }
        private string _apiSuffix { get; set; }
        private ApiInfo _api { get; set; }
     
        public FeatureState(SmartAppInfo smartApp, ApiInfo api, string apiSuffix, string modelSuffix, string viewModelSuffix) : base(smartApp)
        {
            _api = api;
            _modelSuffix = modelSuffix;
            _apiSuffix = apiSuffix;
            _viewModelSuffix = viewModelSuffix;
        }

        public string RemoveApiSuffix(string ApiName)
        {
            return ApiName.Replace(_apiSuffix.ToLower(), "");
        }

        public override string OutputPath => "src\\app\\store\\" + _api.Id.ToCamelCase() + "\\" + "state.ts";
    }
}
