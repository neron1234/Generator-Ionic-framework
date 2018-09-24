using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class DataModelTemplate
    {
        private EntityInfo _entity { get; set; }
        private List<PropertyInfo> _constructorParametersObj { get; set; }
        private List<PropertyInfo> _superPropertiesObj { get; set; }
        public DataModelTemplate(EntityInfo entity)
        {
            _entity = entity;
            _constructorParametersObj = entity.GetProperties();
            _superPropertiesObj = entity.BaseEntity.GetProperties();
        }

        public string IsModelOrEnum(PropertyInfo property)
        {
            if (property.IsModel())
                return "Model";
            else if (property.IsEnum())
                return "Enum";
            return "";
        }

        public override string OutputPath => "src\\models";
    }
}
