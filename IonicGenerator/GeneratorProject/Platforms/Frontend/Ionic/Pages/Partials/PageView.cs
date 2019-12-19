using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageView: TemplateBase
    {
        private ConcernInfo _concern;
        public PageView(SmartAppInfo smartApp, ConcernInfo concernInfo)
        {
            _concern = concernInfo;
        }
        public override string OutputPath => "src\\app\\pages";
    }
}
