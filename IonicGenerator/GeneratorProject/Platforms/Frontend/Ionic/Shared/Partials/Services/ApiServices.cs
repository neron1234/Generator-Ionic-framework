using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ApiServices: TemplateBase
    {
        private string _apiSuffix { get; set; }
        private string _viewModelSuffix { get; set; }
        private ApiInfo _api { get; set; }
        private List<string> _viewModels { get; set; }

        public ApiServices(SmartAppInfo smartApp, ApiInfo api, string apiSuffix, string viewModelSuffix) : base(smartApp)
        {

            _api = api;
            _apiSuffix = apiSuffix;
            _viewModelSuffix = viewModelSuffix;
            _viewModels = api.GetApiViewModelsId();
        }
        public override string OutputPath => "src\\app\\shared\\services";
    }
}
