using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;
using Common.Generator.Framework.Extensions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Enum: TemplateBase
    {
        private string _modelsuffix { get; set; }
        public Enum(EntityInfo model, string modelsuffix) : base(model)
        {
            _modelsuffix = modelsuffix.ToPascalCase();
        }
        public override string OutputPath => "src\\app\\shared\\models\\enum";
    }
}
