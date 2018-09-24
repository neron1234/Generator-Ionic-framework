using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class MocksTemplate
    {
        private ApiInfo _api { get; set; }
        private List<string> _viewModels { get; set; }
        public MocksTemplate(ApiInfo api)
        {
            _api = api;
            _viewModels = api.GetApiViewModelsId();
        }

        public override string OutputPath => "test-config\\mocks";
    }
}
