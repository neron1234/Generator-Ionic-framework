using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ViewModelTemplate
    {
        private EntityInfo _dataModel { get; set; }
        private List<PropertyInfo> _constructorParametersObj { get; set; }
        public ViewModelTemplate(EntityInfo dataModel)
        {
            _dataModel = dataModel;
            _constructorParametersObj = dataModel.GetProperties();
        }

        public string IsModelOrEnum(PropertyInfo property)
        {
            if (property.IsModel())
                return "Model";
            else if (property.IsEnum())
                return "Enum";
            return "";
        }

        public override string OutputPath => "src\\viewModels";
    }
}
