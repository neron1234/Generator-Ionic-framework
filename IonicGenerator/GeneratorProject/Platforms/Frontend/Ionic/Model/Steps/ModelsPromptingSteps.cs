using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class ModelsPromptingSteps :  StepBodyAsync
    {
        private readonly IPrompting _promptingService;

        public ModelsPromptingSteps(IPrompting promptingService)
        {
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Queue<Question>();

            prompts.Enqueue(new Question()
            {
                Name = "ModelSuffix",
                Message = "Enter suffix for data model",
                Type = QuestionType.Text
            });

            await _promptingService.Prompts(nameof(ModelsPromptingSteps), prompts, "Ionic framework: questions for model suffix");
            
            return ExecutionResult.Next();
        }
    }
}
