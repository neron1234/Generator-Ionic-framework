using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [PromptingStep]
    public class CommonPromptingStep : StepBodyAsync
    {
        private readonly IPrompting _promptingService;

        public CommonPromptingStep(IPrompting promptingService)
        {
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Stack<Question>();
            var choices = new List<Choice>();
            choices.Add(new Choice { Key = "light", Name = "Light", Value = "light" });
            choices.Add(new Choice { Key = "dark", Name = "Dark", Value = "dark" });

            prompts.Push(new ChoiceQuestion()
            {
                Name = "Themes",
                Message = "Select a theme",
                Type = QuestionType.Choice,
                Choices = choices
            });

            await _promptingService.Prompts(nameof(CommonPromptingStep), prompts, "Common questions related to ionic");
            return ExecutionResult.Next();
        }
    }
}
