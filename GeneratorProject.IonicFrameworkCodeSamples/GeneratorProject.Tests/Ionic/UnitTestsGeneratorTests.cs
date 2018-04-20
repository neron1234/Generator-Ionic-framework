using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Ionic
{
    public class UnitTestsGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public UnitTestsGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_UnitTests()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            UnitTestsActivity activity = new UnitTestsActivity("UnitTestsActivity", basePath);
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
