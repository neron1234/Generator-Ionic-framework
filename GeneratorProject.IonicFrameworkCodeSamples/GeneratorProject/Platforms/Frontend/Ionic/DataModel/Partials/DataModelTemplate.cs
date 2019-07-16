using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class DataModelTemplate
    {
        public EntityInfo Entity { get; set; }
        public List<PropertyInfo> ConstructorParametersObj { get; set; }
        public List<PropertyInfo> SuperPropertiesObj { get; set; }

        public DataModelTemplate(EntityInfo entity)
        {
            Entity = entity;
            ConstructorParametersObj = entity.GetProperties();
            SuperPropertiesObj = entity.BaseEntity.GetProperties();
        }

        /// <summary>
        /// Check if the type of the property given is from backend models or not. Return a string.
        /// </summary>
        /// <param name="property">A property.</param>
        public string IsModelOrEnum(PropertyInfo property)
        {
            if (property.IsModel())
            {
                return "Model";
            }
            else if (property.IsEnum())
            {
                return "Enum";
            }

            return "";
        }

        public override string OutputPath => "src\\models";
    }
}
