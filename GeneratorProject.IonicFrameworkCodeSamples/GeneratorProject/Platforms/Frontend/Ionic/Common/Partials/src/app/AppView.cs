using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppView : AppBaseClass
    {
        private bool _isMenu { get; set; }
        public AppView(SmartAppInfo smartApp) : base(smartApp)
        {
            _isMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\app\\app.html";
    }
}
