using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ViewModelTemplate: TemplateBase
    {
        private EntityInfo _dataModel { get; set; }
        private List<PropertyInfo> _constructorParametersObj { get; set; }
        private string _viewModelSuffix { get; set; }
        private string _modelSuffix { get; set; }
      
        public ViewModelTemplate(EntityInfo dataModel, string viewModelSuffix, string modelSuffix) : base(dataModel)
        {
            _dataModel = dataModel;
            _viewModelSuffix = viewModelSuffix;
            _modelSuffix = modelSuffix;
            _constructorParametersObj = dataModel.GetProperties();
        }
        public override string OutputPath => "src\\app\\viewModels";
    }
}
