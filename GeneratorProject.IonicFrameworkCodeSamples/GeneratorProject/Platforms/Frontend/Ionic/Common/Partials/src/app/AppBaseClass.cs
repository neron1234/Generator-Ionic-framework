using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppBaseClass : TemplateBase
    {
        protected LayoutInfo _rootLayout { get; set; }
        protected ConcernInfo _rootConcern { get; set; }
        public AppBaseClass(SmartAppInfo smartApp) : base(smartApp)
        {
            Tuple<LayoutInfo, ConcernInfo> tuple = smartApp.GetRootLayout();
            _rootLayout = tuple.Item1;
            _rootConcern = tuple.Item2;
        }
    }
}
