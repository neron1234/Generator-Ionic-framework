using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppView : AppBaseClass
    {
        public bool IsMenu { get; set; }

        public AppView(SmartAppInfo smartApp)
            : base(smartApp)
        {
            IsMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\app\\app.html";
    }
}
