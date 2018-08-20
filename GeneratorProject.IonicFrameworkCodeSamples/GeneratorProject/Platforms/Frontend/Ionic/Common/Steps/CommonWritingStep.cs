using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class CommonWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;

        public CommonWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            var commonTemplates = "Platforms\\Frontend\\Ionic\\Common\\Templates";
            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                var commonTemplatesDirectoryPath = Path.Combine(_context.GeneratorPath, commonTemplates);
                SmartAppInfo smartApp = _context.Manifest;
                var themes = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("Themes") ? _context.DynamicContext.Themes as List<Answer> : new List<Answer>();
                string theme = (themes != null && themes.Count > 0) ? themes.FirstOrDefault().Value : "light";
                TransformCommon(smartApp, commonTemplatesDirectoryPath);
                TransformSimpleTheme(theme);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Generating common components required by Ionic 2 applications' minimal
        /// specifications in order to be compiled.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="commonTemplatesDirectoryPath">Path to common activity templates.</param>
        private void TransformCommon(SmartAppInfo smartApp, string commonTemplatesDirectoryPath)
        {
            if (smartApp != null && commonTemplatesDirectoryPath != null)
            {
                TransformPackage(smartApp);
                TransformIonicConfig(smartApp);
                TransformConfig(smartApp);
                TransformManifest(smartApp);
                TransformIndex(smartApp);
                TransformAppModule(smartApp);
                TransformAppComponent(smartApp);
                TransformAppView(smartApp);
            }
            _writingService.CopyDirectory(commonTemplatesDirectoryPath, _context.BasePath);
        }

        /// <summary>
        /// Generating package.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformPackage(SmartAppInfo smartApp)
        {
            Package packageTemplate = new Package(smartApp);
            string packageDirectoryPath = packageTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, packageDirectoryPath);
            string textToWrite = packageTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating ionic.config.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformIonicConfig(SmartAppInfo smartApp)
        {
            IonicConfig ionicConfigTemplate = new IonicConfig(smartApp);
            string ionicConfigDirectoryPath = ionicConfigTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, ionicConfigDirectoryPath);
            string textToWrite = ionicConfigTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating config.xml
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformConfig(SmartAppInfo smartApp)
        {
            Config configTemplate = new Config(smartApp);
            string configDirectoryPath = configTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, configDirectoryPath);
            string textToWrite = configTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating manifest.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformManifest(SmartAppInfo smartApp)
        {
            Manifest manifestTemplate = new Manifest(smartApp);
            string manifestDirectoryPath = manifestTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, manifestDirectoryPath);
            string textToWrite = manifestTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating index.html
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformIndex(SmartAppInfo smartApp)
        {
            Index indexTemplate = new Index(smartApp);
            string indexDirectoryPath = indexTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, indexDirectoryPath);
            string textToWrite = indexTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating app.module.ts
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppModule(SmartAppInfo smartApp)
        {
            AppModule appModuleTemplate = new AppModule(smartApp);
            string appModuleDirectoryPath = appModuleTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, appModuleDirectoryPath);
            string textToWrite = appModuleTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating app.component.ts
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppComponent(SmartAppInfo smartApp)
        {
            AppComponent appComponentTemplate = new AppComponent(smartApp);
            string appComponentDirectoryPath = appComponentTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, appComponentDirectoryPath);
            string textToWrite = appComponentTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating app.html
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppView(SmartAppInfo smartApp)
        {
            AppView appViewTemplate = new AppView(smartApp);
            string appViewDirectoryPath = appViewTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, appViewDirectoryPath);
            string textToWrite = appViewTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating a simple theme selection between dark and light
        /// </summary>
        /// <param name="theme">A theme.</param>
        private void TransformSimpleTheme(string theme)
        {
            Variables variablesTemplate = new Variables(theme);
            string variablesDirectoryPath = variablesTemplate.OutputPath;
            string fileToWritePath = Path.Combine(_context.BasePath, variablesDirectoryPath);
            string textToWrite = variablesTemplate.TransformText();
            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        #endregion
    }
}
