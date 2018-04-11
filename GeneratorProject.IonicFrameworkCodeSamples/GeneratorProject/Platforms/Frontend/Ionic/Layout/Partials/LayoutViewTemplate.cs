using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Generators.Helpers;
using System.Collections.Generic;
using System.Linq;

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
            _menu = getMenu(_concern);
        }

        /// <summary>
        /// Retrieve the specific menu for each concern.
        /// </summary>
        /// <param name="concern">A concern.</param>
        public Dictionary<string, string> getMenu(ConcernInfo concern)
        {
            Dictionary<string, string> menu = new Dictionary<string, string>();
            if (concern != null && concern.Id != null && concern.Layouts.AsEnumerable() != null)
                foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    if (layout.IsVisibleInMenu && layout.Id != null && layout.Title != null && !menu.ContainsKey(TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id)))
                        menu.Add(TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id), layout.Title);
            return menu;
        }

        public override string OutputPath => "src\\pages";
    }
}
