using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseGenerators.Extensions;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "ViewModelWorkflowId", Order = 3)]
    public class ViewModelWorkflow: IWorkflow
    {
        public string Id => "ViewModelWorkflowId";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.AddViewModelsSuffixQuestion()
                 .Then<ViewModelWritingSteps>()
                .Then<WorkflowEndStepBase>();
        }
    }
}
