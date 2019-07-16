using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Config : TemplateBase
    {
        public string SmartAppVersion { get; set; }

        public Config(SmartAppInfo smartApp)
            : base(smartApp)
        {
            SmartAppVersion = smartApp.GetVersion();
        }

        public override string OutputPath => "config.xml";
    }
}
