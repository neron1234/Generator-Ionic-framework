using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Generators.Frontend.Ionic
{
    public class CommonGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public CommonGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_Common()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            CommonActivity activity = new CommonActivity("CommonActivity", basePath);
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
