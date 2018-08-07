using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Package : TemplateBase
    {
        public string _version { get; set; }
        public Package(SmartAppInfo smartApp) : base(smartApp)
        {
            _version = getVersion(smartApp.Version);
        }

        /// <summary>
        /// Retrieve a 3-digit version from VersionInfo
        /// </summary>
        /// <param name="version">A version.</param>
        public string getVersion(VersionInfo version)
        {
            if (version != null)
                return version.Major + "." + version.Minor + "." + version.Release;
            return "";
        }

        public override string OutputPath => "package.json";
    }
}
