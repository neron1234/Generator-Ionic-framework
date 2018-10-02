using GeneratorProject.Platforms.Frontend.Ionic;
using Microsoft.Extensions.DependencyInjection;
using Mobioos.Foundation.Jade;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Unity;
using Xunit;

namespace GeneratorProject.Tests
{
    public class Tests
    {
        private IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private IUnityServiceProvider _unityServiceProvider;
        private IUnityContainer _container;
        private IPersistenceProvider _persistenceProvider;
        private IWorkflowHost _workflowHost;

        public Tests()
        {
            _services = new ServiceCollection();
            _services.AddLogging();
            _services.AddWorkflow();
            _services.AddSingleton<IUnityServiceProvider, UnityServiceProvider>();
            _services.AddSingleton<IUnityContainer, UnityContainer>();
            _serviceProvider = _services.BuildServiceProvider();
            _unityServiceProvider = _serviceProvider.GetService<IUnityServiceProvider>();
            _container = _serviceProvider.GetService<IUnityContainer>();
            _container.AddExtension(new UnityFallbackProviderExtension(_serviceProvider));
            _workflowHost = _unityServiceProvider.GetService<IWorkflowHost>();
            _persistenceProvider = _unityServiceProvider.GetService<IPersistenceProvider>();

            var context = new SessionContext();
            context.DynamicContext = new ExpandoObject();

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            context.BasePath = Path.Combine(basePath, "GeneratedCode");

            var manifestPath = Path.Combine(basePath, "Manifest");
            context.Manifest = JadeEngine.Parse(manifestPath);

            context.GeneratorPath = basePath;

            var writingService = new WritingService();
            var workflowNotifier = new WorkflowNotifier();
            var workflowEndService = new WorkflowEndService();

            _container.RegisterInstance<IWorkflowEnd>(workflowEndService);
            _container.RegisterInstance<IWorkflowNotifier>(workflowNotifier);
            _container.RegisterInstance<IWriting>(writingService);
            _container.RegisterInstance<ISessionContext>(context);

            // Layout
            _workflowHost.RegisterWorkflow<LayoutWorkflow>();
            _container.RegisterType<LayoutWritingStep>();

            // API
            _workflowHost.RegisterWorkflow<ApiWorkflow>();
            _container.RegisterType<ApiWritingStep>();

            // Common
            _workflowHost.RegisterWorkflow<CommonWorkflow>();
            _container.RegisterType<CommonWritingStep>();
            var answers = new List<Answer>();
            answers.Add(new Answer()
            {
                Name = "Dark",
                Type = AnswerType.Choice,
                Value = "dark"
            });
            ((IDictionary<string, object>)context.DynamicContext).Add("Themes", answers);

            // DataModel
            _workflowHost.RegisterWorkflow<DataModelWorkflow>();
            _container.RegisterType<DataModelWritingStep>();

            // Language
            _workflowHost.RegisterWorkflow<LanguageWorkflow>();
            _container.RegisterType<LanguageWritingStep>();

            // UnitTests
            _workflowHost.RegisterWorkflow<UnitTestsWorkflow>();
            _container.RegisterType<UnitTestsWritingStep>();

            // ViewModel
            _workflowHost.RegisterWorkflow<ViewModelWorkflow>();
            _container.RegisterType<ViewModelWritingStep>();

            _workflowHost.Start();
        }

        [Fact]
        public async Task Execute()
        {
            string workflowId = await _workflowHost.StartWorkflow("IonicLayoutWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
            workflowId = await _workflowHost.StartWorkflow("IonicCommonWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
            workflowId = await _workflowHost.StartWorkflow("IonicDataModelWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
            workflowId = await _workflowHost.StartWorkflow("IonicLanguageWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
            workflowId = await _workflowHost.StartWorkflow("IonicUnitTestsWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
            workflowId = await _workflowHost.StartWorkflow("IonicViewModelWorkflow", 1);
            WaitForWorkflowToComplete(workflowId, TimeSpan.FromSeconds(30));
        }

        private WorkflowStatus GetStatus(string workflowId)
        {
            var instance = _persistenceProvider.GetWorkflowInstance(workflowId).Result;
            return instance.Status;
        }

        private void WaitForWorkflowToComplete(string workflowId, TimeSpan timeOut)
        {
            var status = GetStatus(workflowId);
            var counter = 0;
            while ((status == WorkflowStatus.Runnable) && (counter < (timeOut.TotalMilliseconds / 100)))
            {
                Thread.Sleep(100);
                counter++;
                status = GetStatus(workflowId);
            }
        }

        private void Dispose()
        {
            _workflowHost.Stop();
        }
    }
}
