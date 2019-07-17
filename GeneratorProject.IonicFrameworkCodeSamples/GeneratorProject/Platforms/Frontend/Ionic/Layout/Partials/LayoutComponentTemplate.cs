using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutComponentTemplate
    {
        public string ConcernId { get; set; }
        public LayoutInfo Layout { get; set; }
        public LanguageList Languages { get; set; }
        public ApiList Api { get; set; }
        public List<string> ViewModels { get; set; }
        public List<string> ApiDomainServices { get; set; }
        public Dictionary<string, string> Menu { get; set; }

        public LayoutComponentTemplate(
            ConcernInfo concern,
            LayoutInfo layout,
            LanguageList languages,
            ApiList api)
        {
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
            Menu = concern.GetMenu();
        }

        public override string OutputPath => "src\\pages";
    }
}
