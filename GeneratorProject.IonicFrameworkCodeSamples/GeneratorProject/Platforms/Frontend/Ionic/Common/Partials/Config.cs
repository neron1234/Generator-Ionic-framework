using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Config : TemplateBase
    {
        private string _version { get; set; }
        public Config(SmartAppInfo smartApp) : base(smartApp)
        {
            _version = smartApp.GetVersion();
        }

        public override string OutputPath => "config.xml";
    }
}
