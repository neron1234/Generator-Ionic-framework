using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [WorkFlow(Id = "IonicApiWorkflow", Order = 2)]
    public class ApiWorkflow : IWorkflow
    {
        public string Id => "IonicApiWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<ApiWritingStep>()
                   .Then<WorkFlowEndStepBase>();
        }
    }
}
