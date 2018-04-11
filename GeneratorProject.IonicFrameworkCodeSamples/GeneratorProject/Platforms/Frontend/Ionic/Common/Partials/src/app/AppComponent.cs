using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;
using Mobioos.Scaffold.Generators.Helpers;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Generator(ActivityName = Constants.CommonActivityName, Order = 7)]
    public partial class AppComponent : AppBaseClass
    {
        private bool _isMenu { get; set; }
        public AppComponent(SmartAppInfo smartApp) : base(smartApp)
        {
            _isMenu = isMenu(smartApp.Concerns);
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

        public override string OutputPath => "src\\app\\app.component.ts";
    }
}
