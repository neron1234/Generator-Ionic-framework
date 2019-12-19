using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Mobioos.Scaffold.BaseGenerators.Testing;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;

using GeneratorProject.Platforms.Frontend.Ionic;
using Mobioos.Scaffold.Steps;

namespace IonicGenerator.Tests
{
    public class IonicGeneratorTest
    {
        [Fact]
        public async Task Test()
        {
            var generatorTest = new GeneratorTestBuilder()
                .InitializeContext(
                  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                  Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory,
                      "Manifest"),
                  Path.Combine(
                     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                      "GeneratedCode"),
                        "IonicGenerator")
                 .AddAnswer("Theme",
                  new List<Answer>
                  {
                      new Answer
                      {
                          Name = "light",
                          Type = AnswerType.Choice,
                          Value = "light"
                      }
                  })

                .AddAnswer("ModelSuffix",
                  new List<Answer>
                  {
                      new Answer
                      {
                         Name = "ModelSuffix",
                         Type = AnswerType.Text,
                         Value = "Model"
                      }
                  })

                .AddAnswer("ApiSuffix",
                  new List<Answer>
                  {
                      new Answer
                      {
                         Name = "ApiSuffix",
                         Type = AnswerType.Text,
                         Value = "Api"
                      }
                  })

                 .AddAnswer("ViewModelSuffix",
                  new List<Answer>
                  {
                      new Answer
                      {
                         Name = "ViewModelSuffix",
                         Type = AnswerType.Text,
                         Value = "ViewModel"
                      }
                  })

                .RegisterStep<PromptingViewModelsSuffixStep>()
                .RegisterStep<WritingViewModelsSuffixStep>()
                .RegisterStep<PromptingApiSuffixStep>()
                .RegisterStep<WritingApiSuffixStep>()
                .RegisterStep<CommonPromptingSteps>()
                .RegisterStep<CommonWritingSteps>()
                .RegisterStep<ModelsPromptingSteps>()
                .RegisterStep<ModelsWritingSteps>()
                .RegisterStep<ViewModelWritingSteps>()
                .RegisterStep<ServicesWritingSteps>()
                .RegisterStep<StoresWritingSteps>()
                .RegisterStep<PagesWritingSteps>()
                .Build();

            generatorTest.RegisterWorkflow<CommonWorkflow>("CommonWorkflowId");
            generatorTest.RegisterWorkflow<ModelsWorkflow>("ModelWorkflowId");
            generatorTest.RegisterWorkflow<ViewModelWorkflow>("ViewModelWorkflowId");
            generatorTest.RegisterWorkflow<SharedWorkflow>("SharedWorkflowId");
            generatorTest.RegisterWorkflow<StoresWorkflow>("StoresWorkflowId");
            generatorTest.RegisterWorkflow<PagesWorkflow>("PagesWorkflowId");

            await generatorTest.Start();
        }
    }
}
