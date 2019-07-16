namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Variables
    {
        public string Theme { get; set; }

        public Variables(string theme)
        {
            Theme = theme;
        }

        public override string OutputPath => "src\\theme\\variables.scss";
    }
}
