using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class ViewModelWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public ViewModelWritingStep(
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
                nameof(ViewModelWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic viewmodels");

            if (_context.BasePath != null)
            {
                TransformViewModels(smartApp);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Start function on generation of layout's viewmodels
        /// </summary>
        /// <param name="smartApp">SmartApp manifeste.</param>
        private void TransformViewModels(SmartAppInfo smartApp)
        {
            var alreadyCreated = new List<EntityInfo>();
            var viewModels = smartApp.GetViewModels();
            foreach (var entity in viewModels)
            {
                TransformViewModel(entity);
            }
        }

        /// <summary>
        /// Generating typescript models containing the
        /// definition of the viewmodel for the current layout.
        /// </summary>
        /// <param name="dataModel">A dataModel.</param>
        private void TransformViewModel(EntityInfo dataModel)
        {
            if (dataModel != null
                && dataModel.Id != null)
            {
                var viewModelTemplate = new ViewModelTemplate(dataModel);

                var viewModelDirectoryPath = viewModelTemplate.OutputPath;
                var viewModelFilename = $"{dataModel.Id.ToCamelCase()}.ts";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    viewModelDirectoryPath,
                    viewModelFilename);

                var textToWrite = viewModelTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        #endregion
    }
}
