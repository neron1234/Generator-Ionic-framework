using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;
using Common.Generator.Framework.Extensions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class UserModel: TemplateBase
    {
        private string _modelsuffix { get; set; }

        public UserModel(SmartAppInfo model, string appliationId, string modelSuffix) : base(model, appliationId)
        {
            _modelsuffix = modelSuffix.ToPascalCase();
        }

        public override string OutputPath => "src\\app\\shared\\models\\user-login." + _modelsuffix.ToLower() + ".ts";
    }
}
