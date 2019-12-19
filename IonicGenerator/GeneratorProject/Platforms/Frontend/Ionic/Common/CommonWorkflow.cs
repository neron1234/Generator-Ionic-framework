using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "CommonWorkflowId", Order = 1)]
    public class CommonWorkflow : IWorkflow
    {
        public string Id => "CommonWorkflowId";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
                builder.StartWith<CommonPromptingSteps>()
                    .WaitFor(
                       nameof(CommonPromptingSteps),
                       data => nameof(CommonPromptingSteps))
                    .Then<CommonWritingSteps>()
                    .Then<WorkflowEndStepBase>();
        }

    }
}
