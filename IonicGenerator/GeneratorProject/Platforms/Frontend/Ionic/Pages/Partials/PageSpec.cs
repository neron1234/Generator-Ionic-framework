using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageSpec: TemplateBase
    {
        private ConcernInfo _concern { get; set; }
        public PageSpec(SmartAppInfo smartApp, ConcernInfo concern) : base(smartApp)
        {
            _concern = concern;
        }
        public override string OutputPath => "src\\app\\pages";
    }
}
