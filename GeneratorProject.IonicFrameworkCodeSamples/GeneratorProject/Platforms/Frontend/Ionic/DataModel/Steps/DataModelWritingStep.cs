using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseGenerators.Helpers;
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
    public class DataModelWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public DataModelWritingStep(
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
                nameof(DataModelWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic models");

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
            var layoutApiReferences = new List<EntityInfo>();
            var references = new List<EntityInfo>();

            if (smartApp != null
                && smartApp.Version != null
                && smartApp.DataModel != null
                && smartApp.DataModel.Entities.AsEnumerable() != null
                && smartApp.Concerns.AsEnumerable() != null)
            {
                // Search for references in layout's datamodels
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern.Layouts.AsEnumerable() != null)
                    {
                        foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                        {
                            if (layout.DataModel != null
                                && layout
                                    .DataModel
                                    .References
                                    .AsEnumerable() != null)
                            {
                                foreach (ReferenceInfo reference
                                    in layout.DataModel.References.AsEnumerable())
                                {
                                    if (reference.Target != null
                                        && !layoutApiReferences
                                            .AsEnumerable()
                                            .Contains(reference.Target))
                                    {
                                        layoutApiReferences.Add(reference.Target);
                                    }
                                }
                            }
                        }
                    }
                }

                // Search for references in api's datamodels
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    if (api.Actions.AsEnumerable() != null)
                    {
                        foreach (ApiActionInfo apiAction in api.Actions.AsEnumerable())
                        {
                            if (apiAction.Parameters.AsEnumerable() != null)
                            {
                                foreach (ApiParameterInfo apiActionParameter in
                                    apiAction.Parameters.AsEnumerable())
                                {
                                    if (apiActionParameter.DataModel != null
                                        && apiActionParameter
                                            .DataModel
                                            .References
                                            .AsEnumerable() != null)
                                    {
                                        foreach (ReferenceInfo reference in
                                            apiActionParameter.DataModel.References.AsEnumerable())
                                        {
                                            if (reference.Target != null
                                                && !layoutApiReferences
                                                    .AsEnumerable()
                                                    .Contains(reference.Target))
                                            {
                                                layoutApiReferences.Add(reference.Target);
                                            }
                                        }
                                    }
                                }
                            }

                            if (apiAction.ReturnType != null
                                && apiAction
                                    .ReturnType
                                    .References
                                    .AsEnumerable() != null)
                            {
                                foreach (ReferenceInfo reference in apiAction.ReturnType.References.AsEnumerable())
                                {
                                    if (reference.Target != null
                                        && !layoutApiReferences
                                            .AsEnumerable()
                                            .Contains(reference.Target))
                                    {
                                        layoutApiReferences.Add(reference.Target);
                                    }
                                }
                            }
                        }
                    }
                }

                // Extract references from these references and generate them
                foreach (EntityInfo entity in layoutApiReferences.AsEnumerable())
                {
                    if (entity.Id != null)
                    {
                        var dataModelTemplate = new DataModelTemplate(entity);

                        foreach (PropertyInfo property in
                            dataModelTemplate.getReferenceProperties(entity).AsEnumerable())
                        {
                            if (property.Parent != null
                                && property.Id != null
                                && !references
                                    .AsEnumerable()
                                    .Contains((EntityInfo)property.Parent))
                            {
                                var parent = (EntityInfo)property.Parent;
                                references.Add(parent);
                                TransformDataModel(parent);
                            }

                            if (property.Target != null
                                && !references
                                    .AsEnumerable()
                                    .Contains(property.Target))
                            {
                                references.Add(property.Target);
                                TransformDataModel(property.Target);
                            }
                        }
                    }
                }

                // Generate base references
                foreach (EntityInfo entity in layoutApiReferences.AsEnumerable())
                {
                    if (entity.Id != null
                        && !references
                            .AsEnumerable()
                            .Contains(entity))
                    {
                        references.Add(entity);
                        TransformDataModel(entity);
                    }
                }
            }
        }

        /// <summary>
        /// Generating a typescript model. 
        /// </summary>
        /// <param name="entity">An entity.</param>
        private void TransformDataModel(EntityInfo entity)
        {
            if (entity != null
                && entity.Id != null)
            {
                var fileToWritePath = "";
                var textToWrite = "";

                if (entity.IsEnum)
                {
                    var enumTemplate = new EnumTemplate(entity);
                    var enumDirectoryPath = enumTemplate.OutputPath;
                    var enumFilename = $"{TextConverter.CamelCase(entity.Id)}Enum.ts";

                    fileToWritePath = Path.Combine(
                        _context.BasePath,
                        enumDirectoryPath,
                        enumFilename);

                    textToWrite = enumTemplate.TransformText();
                }
                else
                {
                    var dataModelTemplate = new DataModelTemplate(entity);
                    var dataModelDirectoryPath = dataModelTemplate.OutputPath;
                    var dataModelFilename = $"{TextConverter.CamelCase(entity.Id)}Model.ts";

                    fileToWritePath = Path.Combine(
                        _context.BasePath,
                        dataModelDirectoryPath,
                        dataModelFilename);

                    textToWrite = dataModelTemplate.TransformText();
                }

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        #endregion
    }
}
