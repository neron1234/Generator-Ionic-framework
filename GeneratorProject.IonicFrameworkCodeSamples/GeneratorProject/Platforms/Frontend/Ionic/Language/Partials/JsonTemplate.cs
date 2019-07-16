using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class JsonTemplate
    {
        public SmartAppInfo SmartApp { get; set; }
        public string Language { get; set; }

        public JsonTemplate(
            SmartAppInfo smartApp,
            string language)
        {
            SmartApp = smartApp;
            Language = language;
        }
        
        public override string OutputPath => "src\\assets\\i18n";
    }
}
