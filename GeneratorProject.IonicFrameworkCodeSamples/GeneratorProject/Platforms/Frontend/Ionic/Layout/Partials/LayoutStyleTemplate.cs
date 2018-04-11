using Mobioos.Foundation.Jade.Models;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    public partial class LayoutStyleTemplate
    {
        private string _concernId;
        private LayoutInfo _layout;
        public LayoutStyleTemplate(string concernId, LayoutInfo layout)
        {
            _concernId = concernId;
            _layout = layout;
        }

        public override string OutputPath => "src\\pages";
    }
}
