using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class TabsPageView: TemplateBase
    {
        private string _rootScreen { get; set; }
        public TabsPageView(SmartAppInfo smartApp) : base(smartApp)
        {
            _rootScreen = string.Empty;
            SetRootScreen(smartApp);
        }
        private void SetRootScreen(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Concerns.AsEnumerable() != null && smartApp.Concerns.AsEnumerable().Any())
            {
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    var layout = concern.Layouts.FirstOrDefault(l => l.IsRoot);
                    if (layout != null)
                    {
                        _rootScreen = concern.Id.ToLower();
                    }
                }
            }
        }
        public override string OutputPath => "src\\app\\pages\\apptabs\\app-tabs.page.html";
    }
}
