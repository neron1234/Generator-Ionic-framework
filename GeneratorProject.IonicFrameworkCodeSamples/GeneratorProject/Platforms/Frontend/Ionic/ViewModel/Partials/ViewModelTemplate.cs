using Mobioos.Foundation.Jade.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ViewModelTemplate
    {
        private EntityInfo _dataModel { get; set; }
        private List<PropertyInfo> _constructorParametersObj { get; set; }
        public ViewModelTemplate(EntityInfo dataModel)
        {
            _dataModel = dataModel;
            _constructorParametersObj = getReferences(dataModel);
        }

        /// <summary>
        /// Retrieve all references of an Entity.
        /// </summary>
        /// <param name="entity">Entity which need to be inspected.</param>
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
        /// Check if the type given is a model or a primitive type. Return a string.
        /// </summary>
        /// <param name="property">A model property.</param>
        public string IsModel(PropertyInfo property)
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
        
        public override string OutputPath => "src\\viewModels";
    }
}
