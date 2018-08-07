using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppModule : AppBaseClass
    {
        private LanguageList _languages { get; set; }
        public AppModule(SmartAppInfo smartApp) : base(smartApp)
        {
            if (smartApp.Languages != null)
                _languages = smartApp.Languages;
        }

        public override string OutputPath => "src\\app\\app.module.ts";
    }
}
