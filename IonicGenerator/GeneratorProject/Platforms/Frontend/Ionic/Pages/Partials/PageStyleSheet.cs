using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;


namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PageStyleSheet: TemplateBase
    {
        private ConcernInfo _concern { get; set; }
        public PageStyleSheet(SmartAppInfo smartApp, ConcernInfo concern) : base(smartApp)
        {
            _concern = concern;
       }
        public override string OutputPath => "src\\app\\pages";
    }
}
