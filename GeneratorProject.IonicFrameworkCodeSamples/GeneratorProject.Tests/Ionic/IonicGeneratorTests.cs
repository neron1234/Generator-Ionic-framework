using GeneratorProject.Platforms.Frontend.Ionic;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests.Ionic
{
    public class IonicGeneratorTests : BaseGeneratorTests, IDisposable
    {
        public IonicGeneratorTests() : base() { }

        [Fact]
        public async Task Transform_ALL()
        {
            var basePath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            CommonActivity commonActivity = new CommonActivity("CommonActivity", basePath);
            await commonActivity.Initializing(_context);
            await commonActivity.Writing();
            Assert.NotNull(commonActivity);

            ApiActivity apiActivity = new ApiActivity("ApiActivity", basePath);
            await apiActivity.Initializing(_context);
            await apiActivity.Writing();
            Assert.NotNull(apiActivity);

            LayoutActivity layoutActivity = new LayoutActivity("LayoutActivity", basePath);
            await layoutActivity.Initializing(_context);
            await layoutActivity.Writing();
            Assert.NotNull(layoutActivity);

            DataModelActivity dataModelActivity = new DataModelActivity("DataModelActivity", basePath);
            await dataModelActivity.Initializing(_context);
            await dataModelActivity.Writing();
            Assert.NotNull(dataModelActivity);

            ViewModelActivity viewModelActivity = new ViewModelActivity("ViewModelActivity", basePath);
            await viewModelActivity.Initializing(_context);
            await viewModelActivity.Writing();
            Assert.NotNull(viewModelActivity);

            LanguageActivity languageActivity = new LanguageActivity("LanguageActivity", basePath);
            await languageActivity.Initializing(_context);
            await languageActivity.Writing();
            Assert.NotNull(languageActivity);

            UnitTestsActivity unitTestsActivity = new UnitTestsActivity("UnitTestsActivity", basePath);
            await unitTestsActivity.Initializing(_context);
            await unitTestsActivity.Writing();
            Assert.NotNull(unitTestsActivity);
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
