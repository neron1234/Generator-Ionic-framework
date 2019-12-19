using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class FeatureSelectors: TemplateBase
    {
        private ApiInfo _api { get; set; }
     
        public FeatureSelectors(SmartAppInfo smartApp, ApiInfo api) : base(smartApp)
        {
            _api = api;
        }
       
        public override string OutputPath => "src\\app\\store\\" + _api.Id.ToCamelCase() + "\\" + "selector.ts";
    }
}
