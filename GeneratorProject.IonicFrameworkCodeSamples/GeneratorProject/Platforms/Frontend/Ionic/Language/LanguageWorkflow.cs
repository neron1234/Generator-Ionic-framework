using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [WorkFlow(Id = "IonicLanguageWorkflow", Order = 4)]
    public class LanguageWorkflow : IWorkflow
    {
        public string Id => "IonicLanguageWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<LanguageWritingStep>()
                   .Then<WorkFlowEndStepBase>();
        }
    }
}
