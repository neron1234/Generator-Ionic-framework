using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Generators.Frontend.Ionic
{
    public class ViewModelGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public ViewModelGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_ViewModels()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            ViewModelActivity activity = new ViewModelActivity("ViewModelActivity", basePath);
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
