using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ComponentSpecTemplate
    {
        public string SmartAppId { get; set; }
        public string ConcernId { get; set; }
        public LayoutInfo Layout { get; set; }
        public LanguageList Languages { get; set; }
        public ApiList Api { get; set; }
        public List<string> ViewModels { get; set; }
        public List<string> ApiDomainServices { get; set; }

        public ComponentSpecTemplate(
            string smartAppId,
            ConcernInfo concern,
            LayoutInfo layout,
            LanguageList languages,
            ApiList api)
        {
            SmartAppId = smartAppId;

            if (concern != null 
                && concern.Id != null)
            {
                ConcernId = concern.Id;
            }

            Layout = layout;
            Languages = languages;
            Api = api;
            ViewModels = layout.GetLayoutViewModelsId(api);
            ApiDomainServices = layout.GetLayoutServices(api);
        }

        /// <summary>
        /// Retrieve a standard value for each type supposed
        /// to be in the generated code.
        /// </summary>
        /// <param name="type">A type.</param>
        public string GetValueFromType(string type)
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
