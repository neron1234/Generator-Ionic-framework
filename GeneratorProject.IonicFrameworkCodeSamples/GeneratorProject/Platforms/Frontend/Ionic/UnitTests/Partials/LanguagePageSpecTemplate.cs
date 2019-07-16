namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LanguagePageSpecTemplate
    {
        public string SmartAppId { get; set; }

        public LanguagePageSpecTemplate(string smartAppId)
        {
            SmartAppId = smartAppId;
        }

        public override string OutputPath => "src\\pages\\language";
    }
}
