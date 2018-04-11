namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Variables
    {
        public string _theme { get; set; }
        public Variables(string theme)
        {
            _theme = theme;
        }

        public override string OutputPath => "src\\theme\\variables.scss";
    }
}
