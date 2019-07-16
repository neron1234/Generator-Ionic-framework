using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppBaseClass : TemplateBase
    {
        protected LayoutInfo RootLayout { get; set; }
        protected ConcernInfo RootConcern { get; set; }

        public AppBaseClass(SmartAppInfo smartApp)
            : base(smartApp)
        {
            var tuple = smartApp.GetRootLayout();
            RootLayout = tuple.Item1;
            RootConcern = tuple.Item2;
        }
    }
}
