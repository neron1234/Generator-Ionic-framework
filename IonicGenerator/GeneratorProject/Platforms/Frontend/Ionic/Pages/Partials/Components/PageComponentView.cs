using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageComponentView: TemplateBase
    {
        private string _smartAppTitle { get; set; }
        private ConcernInfo _concern { get; set; }
        private LayoutInfo _layout { get; set; }
        private LanguageList _languages { get; set; }
        private SmartAppInfo _smartApp { get; set; }
        private EntityInfo dataModel { get; set; }
        private List<PropertyInfo> dataProperties { get; set; }

        public PageComponentView(SmartAppInfo smartApp, string smartAppTitle, ConcernInfo concern, LayoutInfo layout, LanguageList languages)
        {
            _smartAppTitle = smartAppTitle;
            _concern = concern;
            _layout = layout;
            _languages = languages;
            _smartApp = smartApp;
            dataModel = _layout.DataModel;
            dataProperties = _layout.DataModel.GetLinkedProperties();
        }

        public override string OutputPath => "src\\app\\pages";
    }
}
