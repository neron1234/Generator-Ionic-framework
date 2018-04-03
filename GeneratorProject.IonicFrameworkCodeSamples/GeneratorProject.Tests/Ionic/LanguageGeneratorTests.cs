using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Generators.Frontend.Ionic
{
    public class LanguageGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public LanguageGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_Language()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            LanguageActivity activity = new LanguageActivity("LanguageActivity", basePath);
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
