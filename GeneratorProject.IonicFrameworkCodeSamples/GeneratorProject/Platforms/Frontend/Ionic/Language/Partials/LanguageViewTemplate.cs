using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LanguageViewTemplate
    {
        public LanguageList Languages { get; set; }
        public bool IsMenu { get; set; }
        public LanguageViewTemplate(SmartAppInfo smartApp)
        {
            if (smartApp.Languages != null)
            {
                Languages = smartApp.Languages;
            }

            IsMenu = smartApp.HasMenu();
        }

        public override string OutputPath => "src\\pages\\language\\language.html";
    }
}
