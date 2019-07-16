using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
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
    public class UnitTestsWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public UnitTestsWritingStep(
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
            var unitTestsTemplates = "Platforms\\Frontend\\Ionic\\UnitTests\\Templates";

            _workflowNotifier.Notify(
                nameof(UnitTestsWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic unit tests");

            if (_context.BasePath != null
                && _context.GeneratorPath != null)
            {
                var unitTestsTemplatesDirectoryPath = Path.Combine(
                    _context.GeneratorPath,
                    unitTestsTemplates);

                TransformUnitTests(
                    smartApp,
                    unitTestsTemplatesDirectoryPath);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Generating unit tests.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="unitTestsTemplatesDirectoryPath">Path to common unit tests templates.</param>
        private void TransformUnitTests(
            SmartAppInfo smartApp,
            string unitTestsTemplatesDirectoryPath)
        {
            if (smartApp != null
                && unitTestsTemplatesDirectoryPath != null)
            {
                TransformServicesMocks(smartApp);
                TransformServicesSpecs(smartApp);
                TransformAppComponentSpec(smartApp);
                TransformComponentSpecs(smartApp);

                if (smartApp.Languages.AsEnumerable() != null
                    && smartApp.Languages.AsEnumerable().Count() > 0)
                {
                    TransformLanguagePageSpec(smartApp);
                }

                _writingService.CopyDirectory(
                    unitTestsTemplatesDirectoryPath,
                    _context.BasePath);
            }
        }

        /// <summary>
        /// Transform each services into mocks form.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesMocks(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Api.AsEnumerable() != null)
            {
                foreach (var api in smartApp.Api.AsEnumerable())
                {
                    var mocksTemplate = new MocksTemplate(api);

                    var mocksDirectoryPath = mocksTemplate.OutputPath;
                    var mocksFilename = $"{api.Id.ToCamelCase()}Mock.ts";

                    var fileToWritePath = Path.Combine(
                        _context.BasePath,
                        mocksDirectoryPath,
                        mocksFilename);

                    var textToWrite = mocksTemplate.TransformText();

                    _writingService.WriteFile(
                        fileToWritePath,
                        textToWrite);
                }
            }
        }

        /// <summary>
        /// Create a spec file for each service.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesSpecs(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Api.AsEnumerable() != null)
            {
                foreach (var api in smartApp.Api.AsEnumerable())
                {
                    var servicesSpecsTemplate = new ServiceSpecTemplate(api);

                    var servicesSpecsDirectoryPath = servicesSpecsTemplate.OutputPath;
                    var servicesSpecsFilename = $"{api.Id.ToCamelCase()}.spec.ts";

                    var fileToWritePath = Path.Combine(
                        _context.BasePath,
                        servicesSpecsDirectoryPath,
                        servicesSpecsFilename);

                    var textToWrite = servicesSpecsTemplate.TransformText();

                    _writingService.WriteFile(
                        fileToWritePath,
                        textToWrite);
                }
            }
        }

        /// <summary>
        /// Create a spec file for app.component.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformAppComponentSpec(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                var appComponentSpecTemplate = new AppComponentSpecTemplate(smartApp);

                var appComponentSpecDirectoryPath = appComponentSpecTemplate.OutputPath;
                var appComponentSpecFilename = "app.component.spec.ts";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    appComponentSpecDirectoryPath,
                    appComponentSpecFilename);

                var textToWrite = appComponentSpecTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        /// <summary>
        /// Create a spec file for each component.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformComponentSpecs(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Concerns.AsEnumerable() != null
                && smartApp.Version != null)
            {
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern != null
                        && concern.Id != null
                        && concern.Layouts.AsEnumerable() != null)
                    {
                        foreach (var layout in concern.Layouts.AsEnumerable())
                        {
                            if (layout != null)
                            {
                                var componentsSpecTemplate = new ComponentSpecTemplate(
                                    smartApp.Id,
                                    concern,
                                    layout,
                                    smartApp.Languages,
                                    smartApp.Api);

                                var componentsSpecDirectoryPath = Path.Combine(
                                    componentsSpecTemplate.OutputPath,
                                    concern.Id.ToCamelCase(),
                                    layout.Id.ToCamelCase());

                                var componentsSpecFilename =
                                    $"{concern.Id.ToCamelCase()}-{layout.Id.ToCamelCase()}.spec.ts";

                                var fileToWritePath = Path.Combine(
                                    _context.BasePath,
                                    componentsSpecDirectoryPath,
                                    componentsSpecFilename);

                                var textToWrite = componentsSpecTemplate.TransformText();

                                _writingService.WriteFile(
                                    fileToWritePath,
                                    textToWrite);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create a spec file for the language page.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformLanguagePageSpec(SmartAppInfo smartApp)
        {
            if (smartApp != null
                && smartApp.Id != null)
            {
                var languagePageSpecTemplate = new LanguagePageSpecTemplate(smartApp.Id);

                var languagePageSpecDirectoryPath = languagePageSpecTemplate.OutputPath;
                var languagePageSpecFilename = "language.spec.ts";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    languagePageSpecDirectoryPath,
                    languagePageSpecFilename);

                var textToWrite = languagePageSpecTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        #endregion
    }
}
