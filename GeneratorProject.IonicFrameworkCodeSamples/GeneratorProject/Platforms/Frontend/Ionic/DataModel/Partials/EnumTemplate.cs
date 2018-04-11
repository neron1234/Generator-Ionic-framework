using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class EnumTemplate
    {
        private EntityInfo _entity { get; set; }

        public EnumTemplate(EntityInfo entity)
        {
            _entity = entity;
        }

        public override string OutputPath => "src\\models";
    }
}
