using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [WorkFlow(Id = "IonicCommonWorkflow", Order = 1)]
    public class CommonWorkflow : IWorkflow
    {
        public string Id => "IonicCommonWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<CommonPromptingStep>()
                   .WaitForAnswers(nameof(CommonPromptingStep))
                   .Then<CommonWritingStep>()
                   .Then<WorkFlowEndStepBase>();
        }
    }
}
