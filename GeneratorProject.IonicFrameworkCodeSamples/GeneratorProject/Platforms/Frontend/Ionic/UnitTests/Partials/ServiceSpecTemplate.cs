using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ServiceSpecTemplate
    {
        public ApiInfo Api { get; set; }
        public List<string> ViewModels { get; set; }

        public ServiceSpecTemplate(ApiInfo api)
        {
            Api = api;
            ViewModels = api.GetApiViewModelsId();
        }

        /// <summary>
        /// Retrieve a standard value for each type supposed
        /// to be in the generated code.
        /// </summary>
        /// <param name="type">A type.</param>
        public string GetValueFromType(string type)
        {
            var result = "null";
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
        /// Convert an Mobioos action type to typescript action type.
        /// </summary>
        /// <param name="actionType">A Mobioos action type.</param>
        public string ConvertActionType(string actionType)
        {
            var result = "";

            switch (actionType.ToLower())
            {
                case "dataget":
                    result = "get";
                    break;
                case "datalist":
                    result = "get";
                    break;
                case "datacreate":
                    result = "post";
                    break;
                case "dataupdate":
                    result = "put";
                    break;
                case "datadelete":
                    result = "delete";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }

        public override string OutputPath => "src\\services";
    }
}
