using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FeatureEffects: TemplateBase
    {
        private string _apiSuffix { get; set; }
        private string _viewModelSuffix { get; set; }
        private ApiInfo _api { get; set; }
        private List<string> _viewModels { get; set; }

        public FeatureEffects(SmartAppInfo smartApp, ApiInfo api, string apiSuffix, string viewModelSuffix) : base(smartApp)
        {
            _api = api;
            _apiSuffix = apiSuffix;
            _viewModelSuffix = viewModelSuffix;
            _viewModels = api.GetApiViewModelsId();
        }

        public string getReturnType(ApiActionInfo apiA)
        {
            if (apiA.ReturnType != null)
            {
                return apiA.ReturnType.Id;
            }
            else
            {
                if (apiA.Parameters.AsEnumerable() != null && apiA.Parameters.AsEnumerable().Any() && apiA.Parameters.AsEnumerable().FirstOrDefault().DataModel != null)
                {
                    return apiA.Parameters.AsEnumerable().FirstOrDefault().DataModel.Id;
                }

                return apiA.Parameters.AsEnumerable().FirstOrDefault().Type;
            }
        }

        public string RemoveViewModelSuffix(string viewModelName)
        {
            return viewModelName.Replace(_viewModelSuffix, "");
        }

        public override string OutputPath => "src\\app\\store\\" + _api.Id.ToCamelCase() + "\\" + "effects.ts";
    }
}
