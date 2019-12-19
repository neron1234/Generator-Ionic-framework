using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FeatureReducers: TemplateBase
    {
        private string _apiSuffix { get; set; }
        private string _viewModelSuffix { get; set; }
        private ApiInfo _api { get; set; }
     
        public FeatureReducers(SmartAppInfo smartApp, ApiInfo api, string apiSuffix, string viewModelSuffix) : base(smartApp)
        {
            _api = api;
            _apiSuffix = apiSuffix;
            _viewModelSuffix = viewModelSuffix;
        }

        public string RemoveApiSuffix(string ApiName)
        {
            return ApiName.Replace(_apiSuffix.ToLower(), "");
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
        public override string OutputPath => "src\\app\\store\\" + _api.Id.ToCamelCase() + "\\" + "reducers.ts";
    }
}
