using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class CommonPromptingSteps : StepBodyAsync
    {
        private readonly IPrompting _promptingService;
        private readonly ISessionContext _context;
        public CommonPromptingSteps(IPrompting promptingService, ISessionContext context)
        {
            _promptingService = promptingService;
            _context = context;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            SmartAppInfo smartApp = _context.Manifest;
            var prompts = new Queue<Question>();
            var choices = new List<Choice>();

            if (smartApp.Themes != null && smartApp.Themes.Count > 0)
            {
                foreach (ThemeInfo theme in smartApp.Themes)
                {
                    choices.Add(new Choice { Key = theme.Id, Name = theme.Id, Value = theme.Id });
                }
            }

            prompts.Enqueue(new ChoiceQuestion()
            {
                Name = "Theme",
                Message = "Select a theme",
                Type = QuestionType.Choice,
                Choices = choices
            });

            await _promptingService.Prompts(nameof(CommonPromptingSteps), prompts, "Ionic framework: questions for common files");

            return ExecutionResult.Next();
        }
    }
}
