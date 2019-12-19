using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseGenerators.Extensions;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Workflow(Id = "SharedWorkflowId", Order = 4)]
    public class SharedWorkflow : IWorkflow
    {
        public string Id => "SharedWorkflowId";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.AddApiSuffixQuestion()
                 .Then<ServicesWritingSteps>()
                 .Then<WorkflowEndStepBase>();
        }
    }
}
