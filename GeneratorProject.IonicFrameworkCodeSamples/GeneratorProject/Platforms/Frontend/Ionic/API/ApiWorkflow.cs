using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicApiWorkflow",
        Order = 2)]
    public class ApiWorkflow : IWorkflow
    {
        public string Id
        => "IonicApiWorkflow";

        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<ApiWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
