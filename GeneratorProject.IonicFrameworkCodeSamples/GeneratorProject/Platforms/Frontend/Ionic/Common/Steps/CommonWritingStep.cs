using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
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
        private readonly IWorkflowNotifier _workflowNotifier;

        public CommonWritingStep(
            ISessionContext context,
            IWriting writingService,
            IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (_context.Manifest == null)
            {
                throw new ArgumentNullException(nameof(_context.Manifest));
            }

            var commonTemplates = "Platforms\\Frontend\\Ionic\\Common\\Templates";

            _workflowNotifier.Notify(
                nameof(CommonWritingStep),
                NotificationType.GeneralInfo,
                "Generating common ionic files");

            if (_context.BasePath != null
                && _context.GeneratorPath != null)
            {
                var commonTemplatesDirectoryPath = Path.Combine(
                    _context.GeneratorPath,
                    commonTemplates);

                var smartApp = _context.Manifest;

                var themes = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("Themes") ?
                    _context.DynamicContext.Themes as List<Answer> : new List<Answer>();

                var theme = (themes != null && themes.Count > 0) ?
                    themes.FirstOrDefault().Value : "light";

                TransformCommon(
                    smartApp,
                    commonTemplatesDirectoryPath);

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
        private void TransformCommon(
            SmartAppInfo smartApp,
            string commonTemplatesDirectoryPath)
        {
            if (smartApp != null
                && commonTemplatesDirectoryPath != null)
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

            _writingService.CopyDirectory(
                commonTemplatesDirectoryPath,
                _context.BasePath);
        }

        /// <summary>
        /// Generating package.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformPackage(SmartAppInfo smartApp)
        {
            var packageTemplate = new Package(smartApp);
            var packageDirectoryPath = packageTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                packageDirectoryPath);

            var textToWrite = packageTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating ionic.config.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformIonicConfig(SmartAppInfo smartApp)
        {
            var ionicConfigTemplate = new IonicConfig(smartApp);
            var ionicConfigDirectoryPath = ionicConfigTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                ionicConfigDirectoryPath);

            var textToWrite = ionicConfigTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating config.xml
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformConfig(SmartAppInfo smartApp)
        {
            var configTemplate = new Config(smartApp);
            var configDirectoryPath = configTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                configDirectoryPath);

            var textToWrite = configTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating manifest.json
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformManifest(SmartAppInfo smartApp)
        {
            var manifestTemplate = new Manifest(smartApp);
            var manifestDirectoryPath = manifestTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                manifestDirectoryPath);

            var textToWrite = manifestTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating index.html
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformIndex(SmartAppInfo smartApp)
        {
            var indexTemplate = new Index(smartApp);
            var indexDirectoryPath = indexTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                indexDirectoryPath);

            var textToWrite = indexTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating app.module.ts
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppModule(SmartAppInfo smartApp)
        {
            var appModuleTemplate = new AppModule(smartApp);
            var appModuleDirectoryPath = appModuleTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                appModuleDirectoryPath);

            var textToWrite = appModuleTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating app.component.ts
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppComponent(SmartAppInfo smartApp)
        {
            var appComponentTemplate = new AppComponent(smartApp);
            var appComponentDirectoryPath = appComponentTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                appComponentDirectoryPath);

            var textToWrite = appComponentTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating app.html
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifest</param>
        private void TransformAppView(SmartAppInfo smartApp)
        {
            var appViewTemplate = new AppView(smartApp);
            var appViewDirectoryPath = appViewTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                appViewDirectoryPath);

            var textToWrite = appViewTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating a simple theme selection between dark and light
        /// </summary>
        /// <param name="theme">A theme.</param>
        private void TransformSimpleTheme(string theme)
        {
            var variablesTemplate = new Variables(theme);
            var variablesDirectoryPath = variablesTemplate.OutputPath;

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                variablesDirectoryPath);

            var textToWrite = variablesTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        #endregion
    }
}
