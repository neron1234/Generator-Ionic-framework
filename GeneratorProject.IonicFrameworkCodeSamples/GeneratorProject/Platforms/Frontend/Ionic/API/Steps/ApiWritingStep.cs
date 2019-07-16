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
    public class ApiWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public ApiWritingStep(
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
            var apiTemplates = "Platforms\\Frontend\\Ionic\\API\\Templates";

            _workflowNotifier.Notify(
                nameof(ApiWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic apis");

            if (_context.BasePath != null
                && _context.GeneratorPath != null)
            {
                var apiTemplatesDirectoryPath = Path.Combine(
                    _context.GeneratorPath,
                    apiTemplates);

                TransformApi(
                    smartApp,
                    apiTemplatesDirectoryPath);
            }

            return Task.FromResult(ExecutionResult.Next());
        }


        #region Writing_methods

        /// <summary>
        /// Start function for the generation of all apis.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="apiTemplatesDirectoryPath">Path to api activity templates.</param>
        private void TransformApi(
            SmartAppInfo smartApp,
            string apiTemplatesDirectoryPath)
        {
            if (smartApp != null
                && smartApp.Api.AsEnumerable() != null)
            {
                foreach (var api in smartApp.Api.AsEnumerable())
                {
                    var apiTemplate = new ApiTemplate(api);

                    var apiDirectoryPath = apiTemplate.OutputPath;
                    var apiFilename = $"{api.Id.ToCamelCase()}.service.ts";

                    var fileToWritePath = Path.Combine(
                        _context.BasePath,
                        apiDirectoryPath,
                        apiFilename);

                    var textToWrite = apiTemplate.TransformText();

                    _writingService.WriteFile(
                        fileToWritePath,
                        textToWrite);
                }

                _writingService.CopyDirectory(
                    apiTemplatesDirectoryPath,
                    _context.BasePath);
            }
        }

        #endregion
    }
}
