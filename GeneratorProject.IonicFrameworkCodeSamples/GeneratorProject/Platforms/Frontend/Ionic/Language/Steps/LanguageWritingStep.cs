using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseGenerators.Helpers;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class LanguageWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public LanguageWritingStep(
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

            var smartApp = _context.Manifest;

            _workflowNotifier.Notify(
                nameof(LanguageWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic internationalization files");

            if (_context.BasePath != null)
            {
                TransformLanguage(smartApp);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Start function for the generation of languages functionnalities.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformLanguage(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Languages.AsEnumerable() != null
                && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                TransformJsonTemplate(smartApp);
                TransformLanguageComponentTemplate();
                TransformLanguageModuleTemplate();
                TransformLanguageViewTemplate(smartApp);
            }
        }

        /// <summary>
        /// Generating a JSON file for the configuration of internationalization
        /// for each languages described in the manifeste.
        /// </summary>
        /// <param name="smartApp">A SmartApp manifeste.</param>
        public void TransformJsonTemplate(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Languages.AsEnumerable() != null
                && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                foreach (LanguageInfo languageInfo in smartApp.Languages.AsEnumerable())
                {
                    var jsonTemplate = new JsonTemplate(
                        smartApp,
                        languageInfo.Id);

                    var jsonDirectoryPath = jsonTemplate.OutputPath;
                    var enJsonFile = $"{TextConverter.PascalCase(languageInfo.Id)}.json";

                    var fileToWritePath = Path.Combine(
                        _context.BasePath,
                        jsonDirectoryPath,
                        enJsonFile);

                    var textToWrite = jsonTemplate.TransformText();

                    _writingService.WriteFile(
                        fileToWritePath,
                        textToWrite);
                }
            }
        }

        /// <summary>
        /// Generating an angular component giving the ability to change
        /// language in the generated application.
        /// Integrated in the application as a page.
        /// </summary>
        public void TransformLanguageComponentTemplate()
        {
            var languageComponentTemplate = new LanguageComponentTemplate();

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                languageComponentTemplate.OutputPath);

            var textToWrite = languageComponentTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating an angular module which integrates the language page
        /// in the routing of the application.
        /// </summary>
        public void TransformLanguageModuleTemplate()
        {
            var languageModuleTemplate = new LanguageModuleTemplate();

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                languageModuleTemplate.OutputPath);

            var textToWrite = languageModuleTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating a SCSS file containing the language page's
        /// graphics specifications for the view. 
        /// </summary>
        public void TransformLanguageStyleTemplate()
        {
            var languageStyleTemplate = new LanguageStyleTemplate();

            var fileToWritePath = Path.Combine(
                _context.BasePath,
                languageStyleTemplate.OutputPath);

            var textToWrite = languageStyleTemplate.TransformText();

            _writingService.WriteFile(
                fileToWritePath,
                textToWrite);
        }

        /// <summary>
        /// Generating a HTML file for the declaration of the view
        /// of the language page.
        /// </summary>
        /// <param name="smartApp">A SmartApp manifeste.</param>
        public void TransformLanguageViewTemplate(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Languages.AsEnumerable() != null
                && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                var languageViewTemplate = new LanguageViewTemplate(
                    smartApp.Concerns,
                    smartApp.Languages);

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    languageViewTemplate.OutputPath);

                var textToWrite = languageViewTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        #endregion
    }
}
