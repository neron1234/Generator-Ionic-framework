using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

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
            _apiDomainServices = layout.GetLayoutServices(api);
        }

        public override string OutputPath => "src\\pages";
    }
}
