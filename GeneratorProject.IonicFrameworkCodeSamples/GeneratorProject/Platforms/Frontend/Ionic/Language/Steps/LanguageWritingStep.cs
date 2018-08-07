using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.Helpers;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
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

        public LanguageWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            SmartAppInfo smartApp = _context.Manifest;
            TransformLanguage(smartApp);
            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Start function for the generation of languages functionnalities.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformLanguage(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
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
            if (smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                foreach (LanguageInfo languageInfo in smartApp.Languages.AsEnumerable())
                {
                    JsonTemplate jsonTemplate = new JsonTemplate(smartApp, languageInfo.Id);
                    string jsonDirectoryPath = Path.Combine(jsonTemplate.OutputPath);
                    string enJsonFile = TextConverter.PascalCase(languageInfo.Id) + ".json";

                    string fileToWritePath = Path.Combine(_context.BasePath, jsonDirectoryPath, enJsonFile);
                    string textToWrite = jsonTemplate.TransformText();

                    _writingService.WriteFile(fileToWritePath, textToWrite);
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
            LanguageComponentTemplate languageComponentTemplate = new LanguageComponentTemplate();

            string fileToWritePath = Path.Combine(_context.BasePath, languageComponentTemplate.OutputPath);
            string textToWrite = languageComponentTemplate.TransformText();

            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating an angular module which integrates the language page
        /// in the routing of the application.
        /// </summary>
        public void TransformLanguageModuleTemplate()
        {
            LanguageModuleTemplate languageModuleTemplate = new LanguageModuleTemplate();

            string fileToWritePath = Path.Combine(_context.BasePath, languageModuleTemplate.OutputPath);
            string textToWrite = languageModuleTemplate.TransformText();

            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating a SCSS file containing the language page's
        /// graphics specifications for the view. 
        /// </summary>
        public void TransformLanguageStyleTemplate()
        {
            LanguageStyleTemplate languageStyleTemplate = new LanguageStyleTemplate();

            string fileToWritePath = Path.Combine(_context.BasePath, languageStyleTemplate.OutputPath);
            string textToWrite = languageStyleTemplate.TransformText();

            _writingService.WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating a HTML file for the declaration of the view
        /// of the language page.
        /// </summary>
        /// <param name="smartApp">A SmartApp manifeste.</param>
        public void TransformLanguageViewTemplate(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                LanguageViewTemplate languageViewTemplate = new LanguageViewTemplate(smartApp.Concerns, smartApp.Languages);

                string fileToWritePath = Path.Combine(_context.BasePath, languageViewTemplate.OutputPath);
                string textToWrite = languageViewTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        #endregion
    }
}
