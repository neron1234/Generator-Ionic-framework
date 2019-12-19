using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "PagesWorkflowId", Order = 6)]
    public class PagesWorkflow: IWorkflow
    {
        public string Id => "PagesWorkflowId";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<PagesWritingSteps>()
                .Then<WorkflowEndStepBase>();
        }
    }
}
