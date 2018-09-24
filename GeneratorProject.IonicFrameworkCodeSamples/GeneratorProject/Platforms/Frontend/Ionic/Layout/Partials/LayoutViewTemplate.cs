using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutViewTemplate
    {
        private string _smartAppTitle { get; set; }
        private ConcernInfo _concern { get; set; }
        private LayoutInfo _layout { get; set; }
        private LanguageList _languages { get; set; }
        private Dictionary<string, string> _menu { get; set; }
        public LayoutViewTemplate(string smartAppTitle, ConcernInfo concern, LayoutInfo layout, LanguageList languages)
        {
            _smartAppTitle = smartAppTitle;
            _concern = concern;
            _layout = layout;
            _languages = languages;
            _menu = concern.GetMenu();
        }

        public override string OutputPath => "src\\pages";
    }
}
