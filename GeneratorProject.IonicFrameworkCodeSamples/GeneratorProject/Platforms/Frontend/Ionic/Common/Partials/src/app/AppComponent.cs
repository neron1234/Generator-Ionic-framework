using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppComponent : AppBaseClass
    {
        public bool IsMenu { get; set; }

        public AppComponent(SmartAppInfo smartApp)
            : base(smartApp)
        {
            IsMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\app\\app.component.ts";
    }
}
