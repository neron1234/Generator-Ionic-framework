using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [WorkFlow(Id = "IonicUnitTestsWorkflow", Order = 7)]
    public class UnitTestsWorkflow : IWorkflow
    {
        public string Id => "IonicUnitTestsWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<UnitTestsWritingStep>()
                   .Then<WorkFlowEndStepBase>();
        }
    }
}
