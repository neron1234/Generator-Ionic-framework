using GeneratorProject.Platforms.Frontend.Ionic;
using Microsoft.Extensions.DependencyInjection;
using Mobioos.Foundation.Jade;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
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
        private SessionContext _context;

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
            _context = new SessionContext();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            _context.BasePath = Path.Combine(basePath, "GeneratedCode");
            _context.DynamicContext = new ExpandoObject();
            var manifestPath = Path.Combine(basePath, "Manifest");
            _context.Manifest = JadeEngine.Parse(manifestPath);
            var writingService = new WritingService();
            var workflowNotifier = new WorkflowNotifier();
            _container.RegisterInstance<IWorkflowNotifier>(workflowNotifier);
            _container.RegisterInstance<IWriting>(writingService);
            _container.RegisterInstance<ISessionContext>(_context);
            _workflowHost.RegisterWorkflow<LayoutWorkflow>();
            _container.RegisterType<LayoutWritingStep>();
            _workflowHost.Start();
        }

        [Fact]
        public async Task Execute()
        {
            string workflowId = await _workflowHost.StartWorkflow("IonicLayoutWorkflow", 1);
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
