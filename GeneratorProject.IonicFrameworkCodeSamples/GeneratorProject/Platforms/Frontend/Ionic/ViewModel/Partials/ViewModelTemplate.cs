using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ViewModelTemplate
    {
        public EntityInfo DataModel { get; set; }
        public List<PropertyInfo> ConstructorParametersObj { get; set; }

        public ViewModelTemplate(EntityInfo dataModel)
        {
            DataModel = dataModel;
            ConstructorParametersObj = dataModel.GetProperties();
        }

        public override string OutputPath => "src\\viewModels";
    }
}
