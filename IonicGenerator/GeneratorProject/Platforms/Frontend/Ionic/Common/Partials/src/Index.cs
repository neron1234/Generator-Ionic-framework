using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Index : TemplateBase
    {
        public string _theme { get; set; }
        public Index(SmartAppInfo smartApp, string theme) : base(smartApp)
        {
            _theme = getTheme(theme);
        }

        private string getTheme(string theme)
        {
            if (theme.ToLower() == "dark" || theme.ToLower() == "light")
            {
                return theme.ToLower();
            }
            else
            {
                return "other";
            }
        }
        public override string OutputPath => "src\\index.html";
    }
}
