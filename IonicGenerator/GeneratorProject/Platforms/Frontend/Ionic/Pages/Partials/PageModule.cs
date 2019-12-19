using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageModule: TemplateBase
    {
        private string _concernId;
        private ConcernInfo _concern;

        public PageModule(SmartAppInfo smartApp, ConcernInfo concernInfo) : base(smartApp)
        {
            _concern = concernInfo;
            _concernId = concernInfo.Id;
        }
        public override string OutputPath => "src\\app\\pages";
    }
}
