using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Generators.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    public partial class LanguageViewTemplate
    {
        private LanguageList _languages { get; set; }
        private bool _isMenu { get; set; }
        public LanguageViewTemplate(ConcernList concerns, LanguageList languages)
        {
            _languages = languages;
            _isMenu = isMenu(concerns);
        }

        /// <summary>
        /// Check if there is at least one menu in the application.
        /// </summary>
        /// <param name="concerns">A list of concerns.</param>
        public bool isMenu(ConcernList concerns)
        {
            if (concerns.AsEnumerable() != null)
                foreach (ConcernInfo concern in concerns.AsEnumerable())
                    if (getMenu(concern).AsEnumerable().Count() > 0)
                        return true;
            return false;
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

        public override string OutputPath => "src\\pages\\language\\language.html";
    }
}
