using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

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
            _viewModels = layout.GetLayoutViewModelsId(api);
            _apiDomainServices = layout.GetLayoutServices(api);
            _menu = concern.GetMenu();
        }

        public override string OutputPath => "src\\pages";
    }
}
