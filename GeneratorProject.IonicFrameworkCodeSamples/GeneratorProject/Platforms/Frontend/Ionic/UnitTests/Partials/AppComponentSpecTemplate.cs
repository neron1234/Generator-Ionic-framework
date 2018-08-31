using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppComponentSpecTemplate
    {
        private SmartAppInfo _smartApp;
        private LayoutInfo _rootLayout { get; set; }
        private ConcernInfo _rootConcern { get; set; }
        private bool _isMenu { get; set; }
        public AppComponentSpecTemplate(SmartAppInfo smartApp)
        {
            _smartApp = smartApp;
            Tuple<LayoutInfo, ConcernInfo> tuple = getRootLayout(smartApp);
            _rootLayout = tuple.Item1;
            _rootConcern = tuple.Item2;
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

        /// <summary>
        /// Helper to retrieve the rootLayout from the manifeste.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        public Tuple<LayoutInfo, ConcernInfo> getRootLayout(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Concerns.AsEnumerable() != null)
            {
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern.Layouts.AsEnumerable() != null)
                    {
                        foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                        {
                            if (layout.IsRoot)
                            {
                                return new Tuple<LayoutInfo, ConcernInfo>(layout, concern);
                            }
                        }
                    }
                }
            }
            return null;
        }

        public override string OutputPath => "src\\app";
    }
}
