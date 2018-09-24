using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ComponentSpecTemplate
    {
        private string _smartAppId;
        private string _concernId;
        private LayoutInfo _layout;
        private LanguageList _languages;
        private ApiList _api;
        private List<string> _viewModels { get; set; }
        private List<string> _apiDomainServices { get; set; }
        public ComponentSpecTemplate(string smartAppId, ConcernInfo concern, LayoutInfo layout, LanguageList languages, ApiList api)
        {
            _smartAppId = smartAppId;
            if (concern != null && concern.Id != null)
                _concernId = concern.Id;
            _layout = layout;
            _languages = languages;
            _api = api;
            _viewModels = layout.GetLayoutViewModelsId(api);
            _apiDomainServices = layout.GetLayoutServices(api);
        }
        
        /// <summary>
        /// Retrieve a standard value for each type supposed
        /// to be in the generated code.
        /// </summary>
        /// <param name="type">A type.</param>
        public string getValueFromType(string type)
        {
            string result = "null";
            switch (type.ToLower())
            {
                case "date": break;
                case "string":
                    result = "'test'";
                    break;
                case "number":
                    result = "0";
                    break;
                case "boolean":
                    result = "true";
                    break;
                default:
                    result = "null";
                    break;
            }
            return result;
        }

        public override string OutputPath => "src\\pages";
    }
}
