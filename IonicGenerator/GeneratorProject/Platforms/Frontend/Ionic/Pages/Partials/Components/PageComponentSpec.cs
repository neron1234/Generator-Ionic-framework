using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageComponentSpec: TemplateBase
    {
        private string _concernId { get; set; }
        private LayoutInfo _layout { get; set; }
        private SmartAppInfo _smartApp { get; set; }
      
        public PageComponentSpec(SmartAppInfo smartApp, ConcernInfo concern, LayoutInfo layout)
        {
            _concernId = concern.Id;
            _layout = layout;
            _smartApp = smartApp;
        }

        public override string OutputPath => "src\\app\\pages";
    }
}
