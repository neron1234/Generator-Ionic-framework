using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicDataModelWorkflow",
        Order = 5)]
    public class DataModelWorkflow : IWorkflow
    {
        public string Id
        => "IonicDataModelWorkflow";
        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<DataModelWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}