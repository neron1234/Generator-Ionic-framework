namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LanguagePageSpecTemplate
    {
        private string _smartAppId;
        public LanguagePageSpecTemplate(string smartAppId)
        {
            _smartAppId = smartAppId;
        }
        
        public override string OutputPath => "src\\pages\\language";
    }
}
