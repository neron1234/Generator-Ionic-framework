using GeneratorProject.Platforms.Frontend.Ionic;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseGenerators.Testing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace GeneratorProject.Tests
{
    public class GeneratorTest
    {
        [Fact]
        public async Task Test()
        {
            var generatorTest = new GeneratorTestBuilder()
                .InitializeContext(
                    Path.GetDirectoryName(
                        Assembly
                            .GetExecutingAssembly()
                            .Location),
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Manifest"),
                    Path.Combine(
                        Path.GetDirectoryName(
                            Assembly
                                .GetExecutingAssembly()
                                .Location),
                        "Result"),
                    "Ionic")
                .AddAnswer(
                    "Themes",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "dark",
                            Type = AnswerType.Choice,
                            Value = "dark"
                        }
                    })
                .RegisterStep<ApiWritingStep>()
                .RegisterStep<CommonPromptingStep>()
                .RegisterStep<CommonWritingStep>()
                .RegisterStep<DataModelWritingStep>()
                .RegisterStep<LanguageWritingStep>()
                .RegisterStep<LayoutWritingStep>()
                .RegisterStep<UnitTestsWritingStep>()
                .RegisterStep<ViewModelWritingStep>()
                .Build();

            generatorTest.RegisterWorkflow<CommonWorkflow>("IonicCommonWorkflow");
            generatorTest.RegisterWorkflow<ApiWorkflow>("IonicApiWorkflow");
            generatorTest.RegisterWorkflow<LayoutWorkflow>("IonicLayoutWorkflow");
            generatorTest.RegisterWorkflow<LanguageWorkflow>("IonicLanguageWorkflow");
            generatorTest.RegisterWorkflow<DataModelWorkflow>("IonicDataModelWorkflow");
            generatorTest.RegisterWorkflow<ViewModelWorkflow>("IonicViewModelWorkflow");
            generatorTest.RegisterWorkflow<UnitTestsWorkflow>("IonicUnitTestsWorkflow");

            await generatorTest.Start();
        }
    }
}
