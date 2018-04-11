using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Jade.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
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
