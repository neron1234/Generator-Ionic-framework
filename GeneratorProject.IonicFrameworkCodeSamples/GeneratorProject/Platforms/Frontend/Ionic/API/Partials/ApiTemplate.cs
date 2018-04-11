using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Jade.Extensions;
using System.Collections.Generic;
using System.Linq;
using Mobioos.Scaffold.Generators.Helpers;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ApiTemplate
    {
        private ApiInfo _api { get; set; }
        private List<string> _viewModels { get; set; }
        public ApiTemplate(ApiInfo api)
        {
            _api = api;
            _viewModels = getViewModels(api);
        }
        
        /// <summary>
        /// Retrieve viewModels from an api.
        /// </summary>
        /// <param name="api">An api.</param>
        public List<string> getViewModels(ApiInfo api)
        {
            List<string> viewModels = new List<string>();
            if (api != null && api.Actions.AsEnumerable() != null)
            {
                foreach (ApiActionInfo action in _api.Actions.AsEnumerable())
                {
                    if (action.Parameters.AsEnumerable() != null)
                    {
                        foreach (ApiParameterInfo apiParameter in action.Parameters.AsEnumerable())
                        {
                            bool parameterIsModel = IsModelBool(TextConverter.PascalCase(apiParameter.TypeScriptType()));
                            if (parameterIsModel && !viewModels.AsEnumerable().Contains(TextConverter.PascalCase(apiParameter.TypeScriptType())))
                                viewModels.Add(TextConverter.PascalCase(apiParameter.TypeScriptType()));
                        }
                    }
                    
                    if (action.ReturnType != null && action.ReturnType.Id != null && !viewModels.AsEnumerable().Contains(TextConverter.PascalCase(action.ReturnType.Id)))
                        viewModels.Add(TextConverter.PascalCase(action.ReturnType.Id));
                }
            }
            return viewModels;
        }

        /// <summary>
        /// Check if the given type is a model or primitive type. Return a string
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
        /// Check if the given type is a model or primitive type. Return a boolean.
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

        public override string OutputPath => "src\\services";
    }
}
