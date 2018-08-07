using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppBaseClass : TemplateBase
    {
        protected LayoutInfo _rootLayout { get; set; }
        protected ConcernInfo _rootConcern { get; set; }
        public AppBaseClass(SmartAppInfo smartApp) : base(smartApp)
        {
            Tuple<LayoutInfo, ConcernInfo> tuple = getRootLayout(smartApp);
            _rootLayout = tuple.Item1;
            _rootConcern = tuple.Item2;
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
    }
}
