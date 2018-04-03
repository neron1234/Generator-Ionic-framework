using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Generators.Frontend.Ionic
{
    public class LayoutGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public LayoutGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_Layouts()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            LayoutActivity activity = new LayoutActivity("LayoutActivity", basePath);
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
