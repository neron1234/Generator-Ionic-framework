using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using Mobioos.Foundation.Prompt;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class ModelsWritingSteps: StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public ModelsWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
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

            _workflowNotifier.Notify(nameof(ModelsWritingSteps), NotificationType.GeneralInfo, "Generating Ionic models");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformDataModel(smartApp);
                TransformUserModel(smartApp);
            }
            return Task.FromResult(ExecutionResult.Next());
        }

        private string GetModelSuffix()
        {
            var modelSuffix = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ModelSuffix") ? _context.DynamicContext.ModelSuffix as List<Answer> : new List<Answer>();

            return (modelSuffix != null && modelSuffix.Count > 0) ? modelSuffix.FirstOrDefault().Value : "Model";

        }

        private void TransformUserModel(SmartAppInfo manifest)
        {
            if (manifest != null)
            {
                string modelSuffix = GetModelSuffix();

                UserModel userModel = new UserModel(manifest, manifest.Id, modelSuffix);
                _writingService.WriteFile(Path.Combine(_context.BasePath, userModel.OutputPath), userModel.TransformText());
            }
        }

        private void TransformDataModel(SmartAppInfo manifest)
        {
            string modelSuffix = GetModelSuffix();

            var entities = manifest.DataModel.Entities;

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (!entity.IsEnum)
                    {
                        DataModel template = new DataModel(entity, manifest.Id, modelSuffix);
                        _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, entity.Id.ToCamelCase() + "." + modelSuffix.ToLower() + ".ts"), template.TransformText());

                    }
                    else
                    {
                        Enum Enum = new Enum(entity, modelSuffix);
                        _writingService.WriteFile(Path.Combine(_context.BasePath, Enum.OutputPath, entity.Id.ToCamelCase() + "." + modelSuffix.ToLower() + ".ts"), Enum.TransformText());
                    }
                }
            }
        }
    }
}
