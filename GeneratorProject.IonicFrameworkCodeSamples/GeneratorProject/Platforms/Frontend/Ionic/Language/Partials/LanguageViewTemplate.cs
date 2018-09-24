using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LanguageViewTemplate
    {
        private LanguageList _languages { get; set; }
        private bool _isMenu { get; set; }
        public LanguageViewTemplate(ConcernList concerns, LanguageList languages)
        {
            _languages = languages;
            _isMenu = concerns.HasMenu();
        }

        public override string OutputPath => "src\\pages\\language\\language.html";
    }
}
