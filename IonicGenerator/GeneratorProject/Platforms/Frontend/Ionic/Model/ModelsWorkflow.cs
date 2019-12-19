using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "ModelWorkflowId", Order = 2)]
    public class ModelsWorkflow: IWorkflow
    {
        public string Id => "ModelWorkflowId";
        public int Version => 1;
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<ModelsPromptingSteps>()
                .WaitFor(
                   nameof(ModelsPromptingSteps),
                   data => nameof(ModelsPromptingSteps))
                .Then<ModelsWritingSteps>()
                .Then<WorkflowEndStepBase>();
        }
    }
}
