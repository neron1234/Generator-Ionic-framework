using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutModuleTemplate
    {
        public string ConcernId { get; set; }
        public LayoutInfo Layout { get; set; }
        public LanguageList Languages { get; set; }
        public ApiList Api { get; set; }
        public List<string> ApiDomainServices { get; set; }

        public LayoutModuleTemplate(
            string concernId,
            LayoutInfo layout,
            LanguageList languages,
            ApiList api)
        {
            ConcernId = concernId;
            Layout = layout;
            Languages = languages;
            Api = api;
            ApiDomainServices = Layout.GetLayoutServices(api);
        }

        public override string OutputPath => "src\\pages";
    }
}
