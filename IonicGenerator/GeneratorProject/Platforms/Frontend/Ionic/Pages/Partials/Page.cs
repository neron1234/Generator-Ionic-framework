using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Page: TemplateBase
    {
        private ConcernInfo _concern;
        public Page(SmartAppInfo smartApp, ConcernInfo concernInfo)
        {
            _concern = concernInfo;
        }
        public override string OutputPath => "src\\app\\pages";
    }
}
