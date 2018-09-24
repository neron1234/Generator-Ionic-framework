using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ServiceSpecTemplate
    {
        private ApiInfo _api { get; set; }
        private List<string> _viewModels { get; set; }
        public ServiceSpecTemplate(ApiInfo api)
        {
            _api = api;
            _viewModels = api.GetApiViewModelsId();
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

        public override string OutputPath => "src\\services";
    }
}
