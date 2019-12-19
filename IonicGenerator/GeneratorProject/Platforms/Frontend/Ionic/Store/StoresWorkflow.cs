using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "StoresWorkflowId", Order = 5)]
    public class StoresWorkflow : IWorkflow
    {
        public string Id => "StoresWorkflowId";
        public int Version => 1;
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<StoresWritingSteps>()
                   .Then<WorkflowEndStepBase>();
        }
    }
}
