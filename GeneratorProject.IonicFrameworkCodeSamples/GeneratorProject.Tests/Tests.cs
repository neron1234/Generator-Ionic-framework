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
using System.Linq;
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
            _context.DynamicContext = new ExpandoObject();

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            _context.BasePath = Path.Combine(basePath, "GeneratedCode");

            var manifestPath = Path.Combine(basePath, "Manifest");
            _context.Manifest = JadeEngine.Parse(manifestPath);

            _context.GeneratorPath = basePath;

            var writingService = new WritingService();
            var workflowNotifier = new WorkflowNotifier();
            var workflowEndService = new WorkflowEndService();

            _container.RegisterInstance<IWorkflowEnd>(workflowEndService);
            _container.RegisterInstance<IWorkflowNotifier>(workflowNotifier);
            _container.RegisterInstance<IWriting>(writingService);
            _container.RegisterInstance<ISessionContext>(_context);

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
            ((IDictionary<string, object>)_context.DynamicContext).Add("Themes", answers);
            SetViewModelSuffixes("ViewModel", "Controller");
            SetApiSuffixes("Controller");

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
            workflowId = await _workflowHost.StartWorkflow("IonicApiWorkflow", 1);
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

        private void SetViewModelSuffixes(string suffix, string apiSuffix)
        {
            (_context.Manifest).Api?.Select(x => { x.Id += apiSuffix; return x.Actions; }).
                  SelectMany(x => x).
                  Where(x => x.ReturnType != null).
                  Select(x => { x.ReturnType.Id += suffix; return x; }).ToList();

            (_context.Manifest).Api?.Select(x => { return x.Actions; }).
                  SelectMany(x => x).
                  Where(x => x.Parameters != null && x.Parameters.Count > 0).
                  SelectMany(x => x.Parameters).Where(x => x.DataModel != null).
                  Select(x => { x.Type += suffix; x.DataModel.Id += suffix; return x; }).ToList();
        }

        private void SetApiSuffixes(string apiSuffix)
        {
            (_context.Manifest).Concerns?.SelectMany(x => x.Layouts).
                    SelectMany(x => x.Actions).Where(x => x.Type != null).
                    Select(x =>
                    {
                        switch (x.Type.ToLower())
                        {
                            case "dataget":
                            case "datalist":
                            case "datacreate":
                            case "datadelete":
                            case "dataupdate":
                                if (x.Api != null)
                                {
                                    char delimiter = '.';
                                    string[] actionSplitted = x.Api.Split(delimiter);
                                    string apiService = actionSplitted[0] + apiSuffix;
                                    string apiAction = actionSplitted[1];
                                    x.Api = apiService + "." + apiAction;
                                }
                                break;
                            default:
                                break;
                        }
                        return x;
                    }).ToList();
        }
    }
}
