using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(
        Id = "IonicViewModelWorkflow",
        Order = 6)]
    public class ViewModelWorkflow : IWorkflow
    {
        public string Id
        => "IonicViewModelWorkflow";

        public int Version
        => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<ViewModelWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
