using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Jade.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                            bool parameterIsModel = IsModelBool(PascalCase(apiParameter.TypeScriptType()));
                            if (parameterIsModel && !viewModels.AsEnumerable().Contains(PascalCase(apiParameter.TypeScriptType())))
                                viewModels.Add(PascalCase(apiParameter.TypeScriptType()));
                        }
                    }
                    
                    if (action.ReturnType != null && action.ReturnType.Id != null && !viewModels.AsEnumerable().Contains(PascalCase(action.ReturnType.Id)))
                        viewModels.Add(PascalCase(action.ReturnType.Id));
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

        public override string OutputPath => "src\\services";
    }
}
