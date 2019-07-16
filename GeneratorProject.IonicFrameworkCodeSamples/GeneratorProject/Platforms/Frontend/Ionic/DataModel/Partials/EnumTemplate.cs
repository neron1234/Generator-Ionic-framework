using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class EnumTemplate
    {
        public EntityInfo Entity { get; set; }

        public EnumTemplate(EntityInfo entity)
        {
            Entity = entity;
        }

        public override string OutputPath => "src\\models";
    }
}
