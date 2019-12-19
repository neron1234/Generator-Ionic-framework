using Common.Generator.Framework.Extensions;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class DataModel: TemplateBase
    {
        private List<PropertyInfo> _superProperties { get; set; }
        private List<EntityInfo> _directReferences { get; set; }
        private string _modelsuffix { get; set; }

        public DataModel(EntityInfo model, string appliationId, string modelsuffix) : base(model, appliationId)
        {
            _modelsuffix = modelsuffix.ToPascalCase();
            _superProperties = model.GetProperties();
            _directReferences = model.GetEntityIndirectReferences();
        }
        public override string OutputPath => "src\\app\\shared\\models";
    }
}
