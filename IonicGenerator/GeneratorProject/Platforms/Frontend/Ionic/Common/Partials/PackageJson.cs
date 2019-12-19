using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class PackageJson: TemplateBase
    {
        public string _version { get; set; }

        public PackageJson(SmartAppInfo smartApp) : base(smartApp)
        {
            _version = getVersion(smartApp.Version);
        }

        public string getVersion(VersionInfo version)
        {
            if (version != null)
                return version.Major + "." + version.Minor + "." + version.Release;
            return "";
        }

        public override string OutputPath => "package.json";
    }
}
