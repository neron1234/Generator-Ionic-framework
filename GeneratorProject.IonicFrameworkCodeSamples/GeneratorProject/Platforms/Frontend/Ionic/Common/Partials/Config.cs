using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    [Generator(ActivityName = Constants.CommonActivityName, Order = 3)]
    public partial class Config : TemplateBase
    {
        private string _version { get; set; }
        public Config(SmartAppInfo smartApp) : base(smartApp)
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

        public override string OutputPath => "config.xml";
    }
}
