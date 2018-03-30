using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Jade.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutComponentTemplate
    {
        private string _concernId { get; set; }
        private LayoutInfo _layout { get; set; }
        private LanguageList _languages { get; set; }
        private ApiList _api { get; set; }
        private List<string> _viewModels { get; set; }
        private List<string> _apiDomainServices { get; set; }
        private Dictionary<string, string> _menu { get; set; }
        public LayoutComponentTemplate(ConcernInfo concern, LayoutInfo layout, LanguageList languages, ApiList api)
        {
            if (concern != null && concern.Id != null)
                _concernId = concern.Id;
            _layout = layout;
            _languages = languages;
            _api = api;
            _viewModels = new List<string>();
            getViewModels(layout, api);
            _apiDomainServices = getApiDomainServices(api, layout);
            _menu = getMenu(concern);
        }

        /// <summary>
        /// Retrieve the specific menu for each concern.
        /// </summary>
        /// <param name="concern">A concern.</param>
        public Dictionary<string, string> getMenu(ConcernInfo concern)
        {
            Dictionary<string, string> menu = new Dictionary<string, string>();
            if (concern != null && concern.Id != null && concern.Layouts.AsEnumerable() != null)
                foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    if (layout.IsVisibleInMenu && layout.Id != null && layout.Title != null && !menu.ContainsKey(CamelCase(concern.Id) + "-" + CamelCase(layout.Id)))
                        menu.Add(CamelCase(concern.Id) + "-" + CamelCase(layout.Id), layout.Title);
            return menu;
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

            //if (layout != null && layout.DataModel != null && layout.DataModel.Id != null && !_viewModels.AsEnumerable().Contains(PascalCase(layout.DataModel.Id)))
            //    _viewModels.Add(PascalCase(layout.DataModel.Id));
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
                                if (!result.AsEnumerable().Contains(PascalCase(apiService)))
                                    result.Add(PascalCase(apiService));
                        }
                    }
            return result;
        }

        /// <summary>
        /// Retrieve viewModels from api actions.
        /// </summary>
        /// <param name="apis">A list of api.</param>
        /// <param name="layoutActions">A list of layout actions.</param>
        /// <returns></returns>
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
                            if (IsModelBool(apiActionParameter.TypeScriptType()) && !_viewModels.AsEnumerable().Contains(PascalCase(apiActionParameter.TypeScriptType())))
                                _viewModels.Add(PascalCase(apiActionParameter.TypeScriptType()));

                        if (apiAction.ReturnType != null && apiAction.ReturnType.Id != null && !_viewModels.AsEnumerable().Contains(PascalCase(apiAction.ReturnType.Id)))
                            _viewModels.Add(PascalCase(apiAction.ReturnType.Id));
                    }
        }

        /// <summary>
        /// Check if the type given is a model or a primitive type. Return a string.
        /// </summary>
        /// <param name="type">A type.</param>
        public string IsModel(string type)
        {
            string result = "";
            switch (type.ToLower())
            {
                case "date": break;
                case "string": break;
                case "number": break;
                case "boolean": break;
                default: result = ""; break;
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

        /// <summary>
        /// Convert a string to PascalCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string PascalCase(string word)
        {
            string result = "";
            word = word.Trim();
            if (word.Length > 0)
            {
                char[] separators = new char[] {
                    ' ',
                    '-',
                    '_',
                    '/'
                };
                string[] splittedString = word.Split(separators);

                splittedString[0] = Regex.Replace(splittedString[0], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                splittedString[0] = splittedString[0].Replace(" ", string.Empty);
                splittedString[0] = splittedString[0].Substring(0, 1).ToUpper() + splittedString[0].Substring(1);
                result += splittedString[0];

                for (int i = 1; i < splittedString.Count(); i++)
                {
                    splittedString[i] = Regex.Replace(splittedString[i], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                    splittedString[i] = splittedString[i].Replace(" ", string.Empty);
                    splittedString[i] = splittedString[i].Substring(0, 1).ToUpper() + splittedString[i].Substring(1);
                    result += splittedString[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a string to CamelCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string CamelCase(string word)
        {
            string result = "";
            word = word.Trim();
            if (word.Length > 0)
            {
                char[] separators = new char[] {
                    ' ',
                    '-',
                    '_',
                    '/'
                };
                string[] splittedString = word.Split(separators);

                splittedString[0] = Regex.Replace(splittedString[0], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                splittedString[0] = splittedString[0].Replace(" ", string.Empty);
                splittedString[0] = splittedString[0].Substring(0, 1).ToLower() + splittedString[0].Substring(1);
                result += splittedString[0];

                for (int i = 1; i < splittedString.Count(); i++)
                {
                    splittedString[i] = Regex.Replace(splittedString[i], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                    splittedString[i] = splittedString[i].Replace(" ", string.Empty);
                    splittedString[i] = splittedString[i].Substring(0, 1).ToUpper() + splittedString[i].Substring(1);
                    result += splittedString[i];
                }
            }
            return result;
        }

        public override string OutputPath => "src\\pages";
    }
}
