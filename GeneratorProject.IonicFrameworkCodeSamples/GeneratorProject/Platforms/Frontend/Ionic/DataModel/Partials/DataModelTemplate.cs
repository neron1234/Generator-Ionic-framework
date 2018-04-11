using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Jade.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    public partial class DataModelTemplate
    {
        private EntityInfo _entity { get; set; }
        private List<PropertyInfo> _constructorParametersObj { get; set; }
        private List<PropertyInfo> _superPropertiesObj { get; set; }

        public DataModelTemplate(EntityInfo entity)
        {
            _entity = entity;
            _constructorParametersObj = getReferences(entity);
            _superPropertiesObj = getReferences(entity.BaseEntity);
        }

        /// <summary>
        /// Retrieve references from an entity going further when it is a reference.
        /// </summary>
        /// <param name="entity">An entity.</param>
        public List<PropertyInfo> getReferenceProperties(EntityInfo entity)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            if (entity != null)
            {
                if (entity.BaseEntity != null)
                    foreach (PropertyInfo property in getReferenceProperties(entity.BaseEntity).AsEnumerable())
                        result.Add(property);

                if (entity.Properties.AsEnumerable() != null)
                    foreach (PropertyInfo property in entity.Properties.AsEnumerable())
                        result.Add(property);

                if (entity.References.AsEnumerable() != null)
                    foreach (ReferenceInfo reference in entity.References.AsEnumerable())
                        if (reference.Target != null && !reference.Target.IsAbstract && !reference.IsCollection)
                        {
                            if (reference.Target.IsEnum)
                                result.Add(reference);
                            else
                                foreach (PropertyInfo property in getReferenceProperties(reference.Target).AsEnumerable())
                                    result.Add(property);

                        }
                        else
                            result.Add(reference);
            }
            return result;
        }

        /// <summary>
        /// Retrieve references from an entity.
        /// </summary>
        /// <param name="entity">An entity.</param>
        public List<PropertyInfo> getReferences(EntityInfo entity)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            if (entity != null)
            {
                if (entity.BaseEntity != null)
                    foreach (PropertyInfo property in getReferences(entity.BaseEntity).AsEnumerable())
                        result.Add(property);

                if (entity.Properties.AsEnumerable() != null)
                    foreach (PropertyInfo property in entity.Properties.AsEnumerable())
                        result.Add(property);

                if (entity.References.AsEnumerable() != null)
                    foreach (ReferenceInfo reference in entity.References.AsEnumerable())
                        result.Add(reference);
            }
            return result;
        }

        /// <summary>
        /// Check if the type of the property given is from backend models or not. Return a string.
        /// </summary>
        /// <param name="property">A property.</param>
        public string IsModelOrEnum(PropertyInfo property)
        {
            string result = "";
            switch (property.TypeScriptType().ToLower())
            {
                case "date": break;
                case "string": break;
                case "number": break;
                case "boolean": break;
                default: result = "Model"; break;
            }
            if (property.Target != null && property.Target.IsEnum)
                result = "Enum";
            return result;
        }

        public override string OutputPath => "src\\models";
    }
}
