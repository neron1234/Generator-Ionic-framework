using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class ApiTemplate
    {
        public ApiInfo Api { get; set; }
        public List<string> ViewModels { get; set; }

        public ApiTemplate(ApiInfo api)
        {
            Api = api;
            ViewModels = api.GetApiViewModelsId();
        }

        public override string OutputPath => "src\\services";
    }
}
