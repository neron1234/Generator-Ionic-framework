using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Theme: TemplateBase
    {
        public string _theme { get; set; }
        public Theme(SmartAppInfo smartApp, string theme) : base(smartApp)
        {
            _theme = theme;
        }
        public override string OutputPath => "src\\themes\\" + _theme + ".scss";
    }
}
