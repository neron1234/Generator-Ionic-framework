using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Generators.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutModuleTemplate
    {
        private string _concernId { get; set; }
        private LayoutInfo _layout { get; set; }
        private LanguageList _languages { get; set; }
        private ApiList _api { get; set; }
        private List<string> _apiDomainServices { get; set; }
        public LayoutModuleTemplate(string concernId, LayoutInfo layout, LanguageList languages, ApiList api)
        {
            _concernId = concernId;
            _layout = layout;
            _languages = languages;
            _api = api;
            _apiDomainServices = getApiDomainServices(api, layout.Actions);
        }
        
        /// <summary>
        /// Retrieve all services from a list of api.
        /// </summary>
        /// <param name="apis">A list of api.</param>
        /// <param name="layoutActions">A list of layout actions.</param>
        public List<string> getApiDomainServices(ApiList apis, ActionList layoutActions)
        {
            List<string> result = new List<string>();
            if (layoutActions.AsEnumerable() != null)
            {
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                {
                    if (action.Type != null && action.Api != null && IsDataAction(action.Type))
                    {
                        char delimiter = '.';
                        string[] actionSplitted = action.Api.Split(delimiter);
                        string apiService = actionSplitted[0];
                        string apiAction = actionSplitted[1];

                        foreach (ApiInfo api in apis.AsEnumerable())
                        {
                            if (api.Id.ToLower().Equals(apiService.ToLower()))
                                if (!result.AsEnumerable().Contains(TextConverter.PascalCase(apiService)))
                                    result.Add(TextConverter.PascalCase(apiService));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check if the action type given is a data action or not. Return a boolean.
        /// </summary>
        /// <param name="actionType">An action type.</param>
        public bool IsDataAction(string actionType)
        {
            bool result = false;
            switch (actionType.ToLower())
            {
                case "dataget":
                case "datalist":
                case "datacreate":
                case "dataupdate":
                case "datadelete":
                    result = true; break;
            }
            return result;
        }
        
        public override string OutputPath => "src\\pages";
    }
}
