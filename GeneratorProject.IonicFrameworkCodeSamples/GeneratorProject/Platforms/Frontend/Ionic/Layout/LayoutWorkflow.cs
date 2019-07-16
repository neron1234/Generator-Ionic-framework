using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicLayoutWorkflow",
        Order = 3)]
    public class LayoutWorkflow : IWorkflow
    {
        public string Id
        => "IonicLayoutWorkflow";

        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<LayoutWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
