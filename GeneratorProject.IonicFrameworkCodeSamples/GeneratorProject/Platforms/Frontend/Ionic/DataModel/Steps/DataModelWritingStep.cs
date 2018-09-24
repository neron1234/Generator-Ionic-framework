using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.IO;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class DataModelWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public DataModelWritingStep(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
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
            _workflowNotifier.Notify(nameof(DataModelWritingStep), NotificationType.GeneralInfo, "Generating ionic models");
            if (_context.BasePath != null)
            {
                TransformDataModels(smartApp);
            }
            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Generating typescript models of the SmartApp.
        /// In frontend context, essentially backend
        /// models which are used by the viewmodels.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformDataModels(SmartAppInfo smartApp)
        {
            var models = smartApp.GetModels();

            foreach (EntityInfo entity in models)
                TransformDataModel(entity);
        }

        /// <summary>
        /// Generating a typescript model. 
        /// </summary>
        /// <param name="entity">An entity.</param>
        private void TransformDataModel(EntityInfo entity)
        {
            if (entity != null && entity.Id != null)
            {
                string fileToWritePath = "";
                string textToWrite = "";
                if (entity.IsEnum)
                {
                    EnumTemplate enumTemplate = new EnumTemplate(entity);
                    string enumDirectoryPath = Path.Combine(enumTemplate.OutputPath);
                    string enumFilename = entity.Id.ToCamelCase() + "Enum.ts";
                    fileToWritePath = Path.Combine(_context.BasePath, enumDirectoryPath, enumFilename);
                    textToWrite = enumTemplate.TransformText();
                }
                else
                {
                    DataModelTemplate dataModelTemplate = new DataModelTemplate(entity);
                    string dataModelDirectoryPath = Path.Combine(dataModelTemplate.OutputPath);
                    string dataModelFilename = entity.Id.ToCamelCase() + "Model.ts";
                    fileToWritePath = Path.Combine(_context.BasePath, dataModelDirectoryPath, dataModelFilename);
                    textToWrite = dataModelTemplate.TransformText();
                }

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        #endregion
    }
}
