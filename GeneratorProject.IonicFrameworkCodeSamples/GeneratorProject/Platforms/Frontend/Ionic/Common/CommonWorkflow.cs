using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicCommonWorkflow",
        Order = 1)]
    public class CommonWorkflow : IWorkflow
    {
        public string Id
        => "IonicCommonWorkflow";

        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<CommonPromptingStep>()
                  .WaitFor(
                      nameof(CommonPromptingStep),
                      data => nameof(CommonPromptingStep))
                  .Then<CommonWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
