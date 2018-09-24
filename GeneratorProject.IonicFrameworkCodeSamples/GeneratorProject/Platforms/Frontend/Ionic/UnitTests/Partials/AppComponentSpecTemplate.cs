using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System;

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
            Tuple<LayoutInfo, ConcernInfo> tuple = smartApp.GetRootLayout();
            _rootLayout = tuple.Item1;
            _rootConcern = tuple.Item2;
            _isMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\app";
    }
}
