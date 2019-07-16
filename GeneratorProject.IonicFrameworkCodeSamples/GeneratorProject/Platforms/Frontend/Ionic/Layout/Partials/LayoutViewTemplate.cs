using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutViewTemplate
    {
        public string SmartAppTitle { get; set; }
        public ConcernInfo Concern { get; set; }
        public LayoutInfo Layout { get; set; }
        public LanguageList Languages { get; set; }
        public Dictionary<string, string> Menu { get; set; }

        public LayoutViewTemplate(
            string smartAppTitle,
            ConcernInfo concern,
            LayoutInfo layout,
            LanguageList languages)
        {
            SmartAppTitle = smartAppTitle;
            Concern = concern;
            Layout = layout;
            Languages = languages;
            Menu = concern.GetMenu();
        }

        public override string OutputPath => "src\\pages";
    }
}
