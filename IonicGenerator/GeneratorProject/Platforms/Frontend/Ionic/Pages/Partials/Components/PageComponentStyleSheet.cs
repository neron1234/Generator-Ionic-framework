using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageComponentStyleSheet: TemplateBase
    {
        private ConcernInfo _concern { get; set; }
        private LayoutInfo _layout { get; set; }

        public PageComponentStyleSheet(SmartAppInfo smartApp, ConcernInfo concern, LayoutInfo layout) : base(smartApp)
        {
            _concern = concern;
            _layout = layout;
        }

        public override string OutputPath => "src\\app\\pages";
    }
}
