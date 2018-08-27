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
    public class UnitTestsWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public UnitTestsWritingStep(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            SmartAppInfo smartApp = _context.Manifest;
            var unitTestsTemplates = "Platforms\\Frontend\\Ionic\\UnitTests\\Templates";
            _workflowNotifier.Notify(nameof(UnitTestsWritingStep), NotificationType.GeneralInfo, "Generating ionic unit tests");
            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                var unitTestsTemplatesDirectoryPath = Path.Combine(_context.GeneratorPath, unitTestsTemplates);
                TransformUnitTests(smartApp, unitTestsTemplatesDirectoryPath);
            }
            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Generating unit tests.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="unitTestsTemplatesDirectoryPath">Path to common unit tests templates.</param>
        private void TransformUnitTests(SmartAppInfo smartApp, string unitTestsTemplatesDirectoryPath)
        {
            if (smartApp != null && unitTestsTemplatesDirectoryPath != null)
            {
                TransformServicesMocks(smartApp);
                TransformServicesSpecs(smartApp);
                TransformAppComponentSpec(smartApp);
                TransformComponentSpecs(smartApp);
                if (smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
                {
                    TransformLanguagePageSpec(smartApp);
                }
                _writingService.CopyDirectory(unitTestsTemplatesDirectoryPath, _context.BasePath);
            }
        }

        /// <summary>
        /// Transform each services into mocks form.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesMocks(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Api.AsEnumerable() != null)
            {
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    MocksTemplate mocksTemplate = new MocksTemplate(api);

                    string mocksDirectoryPath = mocksTemplate.OutputPath;
                    string mocksFilename = TextConverter.CamelCase(api.Id) + "Mock.ts";

                    string fileToWritePath = Path.Combine(_context.BasePath, mocksDirectoryPath, mocksFilename);
                    string textToWrite = mocksTemplate.TransformText();

                    _writingService.WriteFile(fileToWritePath, textToWrite);
                }
            }
        }

        /// <summary>
        /// Create a spec file for each service.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesSpecs(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Api.AsEnumerable() != null)
            {
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    ServiceSpecTemplate servicesSpecsTemplate = new ServiceSpecTemplate(api);

                    string servicesSpecsDirectoryPath = servicesSpecsTemplate.OutputPath;
                    string servicesSpecsFilename = TextConverter.CamelCase(api.Id) + ".spec.ts";

                    string fileToWritePath = Path.Combine(_context.BasePath, servicesSpecsDirectoryPath, servicesSpecsFilename);
                    string textToWrite = servicesSpecsTemplate.TransformText();

                    _writingService.WriteFile(fileToWritePath, textToWrite);
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
                AppComponentSpecTemplate appComponentSpecTemplate = new AppComponentSpecTemplate(smartApp);

                string appComponentSpecDirectoryPath = appComponentSpecTemplate.OutputPath;
                string appComponentSpecFilename = "app.component.spec.ts";

                string fileToWritePath = Path.Combine(_context.BasePath, appComponentSpecDirectoryPath, appComponentSpecFilename);
                string textToWrite = appComponentSpecTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        /// <summary>
        /// Create a spec file for each component.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformComponentSpecs(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Concerns.AsEnumerable() != null && smartApp.Version != null)
            {
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern != null && concern.Id != null && concern.Layouts.AsEnumerable() != null)
                    {
                        foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                        {
                            if (layout != null)
                            {
                                ComponentSpecTemplate componentsSpecTemplate = new ComponentSpecTemplate(smartApp.Id, concern, layout, smartApp.Languages, smartApp.Api);

                                string componentsSpecDirectoryPath = Path.Combine(componentsSpecTemplate.OutputPath, TextConverter.CamelCase(concern.Id), TextConverter.CamelCase(layout.Id));
                                string componentsSpecFilename = TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id) + ".spec.ts";

                                string fileToWritePath = Path.Combine(_context.BasePath, componentsSpecDirectoryPath, componentsSpecFilename);
                                string textToWrite = componentsSpecTemplate.TransformText();

                                _writingService.WriteFile(fileToWritePath, textToWrite);
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
            if (smartApp != null && smartApp.Id != null)
            {
                LanguagePageSpecTemplate languagePageSpecTemplate = new LanguagePageSpecTemplate(smartApp.Id);

                string languagePageSpecDirectoryPath = languagePageSpecTemplate.OutputPath;
                string languagePageSpecFilename = "language.spec.ts";

                string fileToWritePath = Path.Combine(_context.BasePath, languagePageSpecDirectoryPath, languagePageSpecFilename);
                string textToWrite = languagePageSpecTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        #endregion
    }
}
