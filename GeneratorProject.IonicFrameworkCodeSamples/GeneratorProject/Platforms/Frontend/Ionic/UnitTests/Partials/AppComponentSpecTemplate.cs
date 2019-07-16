using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppComponentSpecTemplate
    {
        public SmartAppInfo SmartApp { get; set; }
        public LayoutInfo RootLayout { get; set; }
        public ConcernInfo RootConcern { get; set; }
        public bool IsMenu { get; set; }

        public AppComponentSpecTemplate(SmartAppInfo smartApp)
        {
            SmartApp = smartApp;
            var tuple = smartApp.GetRootLayout();
            RootLayout = tuple.Item1;
            RootConcern = tuple.Item2;
            IsMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\app";
    }
}
