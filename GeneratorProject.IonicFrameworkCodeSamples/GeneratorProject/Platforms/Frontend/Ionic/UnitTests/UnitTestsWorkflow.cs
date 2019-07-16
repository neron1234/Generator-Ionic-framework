using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicUnitTestsWorkflow",
        Order = 7)]
    public class UnitTestsWorkflow : IWorkflow
    {
        public string Id
        => "IonicUnitTestsWorkflow";

        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<UnitTestsWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
