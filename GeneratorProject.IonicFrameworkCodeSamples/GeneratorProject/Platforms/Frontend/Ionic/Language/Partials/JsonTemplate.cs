using Mobioos.Foundation.Jade.Models;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    public partial class JsonTemplate
    {
        private SmartAppInfo _smartApp { get; set; }
        private string _language { get; set; }
        public JsonTemplate(SmartAppInfo smartApp, string language)
        {
            _smartApp = smartApp;
            _language = language;
        }
        
        public override string OutputPath => "src\\assets\\i18n";
    }
}
