using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Ionic
{
    public class ApiGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public ApiGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_Apis()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            ApiWorkflow activity = new ApiWorkflow();
            await activity.Initializing(_context);
            await activity.Writing();
            Assert.NotNull(activity);
        }
        
        public void Dispose()
        {
            Clear();
        }
    }
}
