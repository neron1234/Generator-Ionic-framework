using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class AppModule : AppBaseClass
    {
        public LanguageList Languages { get; set; }

        public AppModule(SmartAppInfo smartApp)
            : base(smartApp)
        {
            if (smartApp.Languages != null)
            {
                Languages = smartApp.Languages;
            }
        }

        public override string OutputPath => "src\\app\\app.module.ts";
    }
}
