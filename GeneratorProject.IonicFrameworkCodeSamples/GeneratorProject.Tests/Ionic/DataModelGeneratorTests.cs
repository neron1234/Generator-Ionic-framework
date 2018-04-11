using Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Mobioos.Scaffold.CoreTests.Generators.Frontend.Ionic
{
    public class DataModelGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public DataModelGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_DataModel()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            DataModelActivity activity = new DataModelActivity("DataModelActivity", basePath);
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
