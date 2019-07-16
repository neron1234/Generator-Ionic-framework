using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class LayoutStyleTemplate
    {
        public string ConcernId { get; set; }
        public LayoutInfo Layout { get; set; }

        public LayoutStyleTemplate(
            string concernId,
            LayoutInfo layout)
        {
            ConcernId = concernId;
            Layout = layout;
        }

        public override string OutputPath => "src\\pages";
    }
}
