using Mobioos.Foundation.Jade.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Generators.Helpers;
using System.Collections.Generic;
using System.Linq;

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
            _viewModels = new List<string>();
            getViewModels(layout, api);
            _apiDomainServices = getApiDomainServices(api, layout);
        }

        /// <summary>
        /// Retrieve viewModels from models and api.
        /// </summary>
        /// <param name="layout">A layout.</param>
        /// <param name="apis">A list of api.</param>
        public void getViewModels(LayoutInfo layout, ApiList apis)
        {
            if (_viewModels == null)
                _viewModels = new List<string>();

            if (layout != null && layout.Actions.AsEnumerable() != null)
                getApiViewModels(apis, layout.Actions);
        }

        /// <summary>
        /// Retrieve services from api defined in the api domain.
        /// </summary>
        /// <param name="apis">A list of api.</param>
        /// <param name="layoutActions">A list of layout actions</param>
        public List<string> getApiDomainServices(ApiList apis, LayoutInfo layout)
        {
            List<string> result = new List<string>();
            if (layout != null && layout.Actions.AsEnumerable() != null)
                foreach (ActionInfo action in layout.Actions.AsEnumerable())
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
            return result;
        }

        /// <summary>
        /// Retrieve viewModels from api actions.
        /// </summary>
        /// <param name="apis">A list of api.</param>
        /// <param name="layoutActions">A list of layout actions.</param>
        public void getApiViewModels(ApiList apis, ActionList layoutActions)
        {
            if (layoutActions.AsEnumerable() != null)
                foreach (ActionInfo action in layoutActions.AsEnumerable())
                    if (action.Type != null && action.Api != null && IsDataAction(action.Type))
                    {
                        char delimiter = '.';
                        string[] actionSplitted = action.Api.Split(delimiter);
                        string apiService = actionSplitted[0];
                        string apiAction = actionSplitted[1];

                        foreach (ApiInfo api in apis.AsEnumerable())
                            if (api.Actions.AsEnumerable() != null)
                                getApiActionViewModels(apiAction, api.Actions);
                    }
        }

        /// <summary>
        /// Retrieve viewModels from api actions parameters and return type.
        /// </summary>
        /// <param name="layoutAction">A layout action.</param>
        /// <param name="apiActions">A list of api actions.</param>
        public void getApiActionViewModels(string layoutAction, ApiActionList apiActions)
        {
            if (apiActions.AsEnumerable() != null)
                foreach (ApiActionInfo apiAction in apiActions.AsEnumerable())
                    if (apiAction.Id.ToLower().Equals(layoutAction.ToLower()) && apiAction.Parameters.AsEnumerable() != null)
                    {
                        foreach (ApiParameterInfo apiActionParameter in apiAction.Parameters.AsEnumerable())
                            if (IsModelBool(apiActionParameter.TypeScriptType()) && !_viewModels.AsEnumerable().Contains(TextConverter.PascalCase(apiActionParameter.TypeScriptType())))
                                _viewModels.Add(TextConverter.PascalCase(apiActionParameter.TypeScriptType()));

                        if (apiAction.ReturnType != null && apiAction.ReturnType.Id != null && !_viewModels.AsEnumerable().Contains(TextConverter.PascalCase(apiAction.ReturnType.Id)))
                            _viewModels.Add(TextConverter.PascalCase(apiAction.ReturnType.Id));
                    }
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

        /// <summary>
        /// Check if the type given is a model or a primitive type. Return a boolean.
        /// </summary>
        /// <param name="type">A type.</param>
        public bool IsModelBool(string type)
        {
            bool result = false;
            switch (type.ToLower())
            {
                case "date": break;
                case "string": break;
                case "number": break;
                case "boolean": break;
                default: result = true; break;
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
