using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using Mobioos.Foundation.Prompt;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class PagesWritingSteps: StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public PagesWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            SmartAppInfo smartApp = _context.Manifest;

            _workflowNotifier.Notify(nameof(PagesWritingSteps), NotificationType.GeneralInfo, "Generating IOnic pages and  components");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformFeatureModules(smartApp);
                TransformFeatures(smartApp);
                TransformTabsModule(smartApp);
                TransformSettingsModule(smartApp);
            }
            return Task.FromResult(ExecutionResult.Next());
        }
        private void TransformFeatureModules(SmartAppInfo smartApp)
        {
            if (smartApp.Concerns != null && smartApp.Concerns.Count > 0)
            {
                foreach (var concern in smartApp.Concerns)
                {
                    Page page = new Page(smartApp, concern);
                    PageSpec pageSpec = new PageSpec(smartApp, concern);
                    PageView pageView = new PageView(smartApp, concern);
                    PageStyleSheet pageStyleSheet = new PageStyleSheet(smartApp, concern);
                    PageModule pageModule = new PageModule(smartApp, concern);
                   
                    _writingService.WriteFile(Path.Combine(_context.BasePath, page.OutputPath, concern.Id.ToCamelCase(), concern.Id.ToCamelCase() + ".page.ts"), page.TransformText());
                    _writingService.WriteFile(Path.Combine(_context.BasePath, pageSpec.OutputPath, concern.Id.ToCamelCase(), concern.Id.ToCamelCase() + "-page.spec.ts"), pageSpec.TransformText());
                    _writingService.WriteFile(Path.Combine(_context.BasePath, pageView.OutputPath, concern.Id.ToCamelCase(), concern.Id.ToCamelCase() + ".page.html"), pageView.TransformText());
                    _writingService.WriteFile(Path.Combine(_context.BasePath, pageStyleSheet.OutputPath, concern.Id.ToCamelCase(), concern.Id.ToCamelCase() + ".page.scss"), pageStyleSheet.TransformText());
                    _writingService.WriteFile(Path.Combine(_context.BasePath, pageModule.OutputPath, concern.Id.ToCamelCase(), concern.Id.ToCamelCase() + ".module.ts"), pageModule.TransformText());
                   
                }
            }
        }

        private void TransformFeatures(SmartAppInfo smartApp)
        {
            if (smartApp.Concerns != null && smartApp.Concerns.Count > 0)
            {
                string apiSuffix = GetApiSuffix();
                string viewModelSuffix = GetViewModelSuffix();

                foreach (var concern in smartApp.Concerns)
                {
                    foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                    {
                         PageComponent pageComponent = new PageComponent(smartApp, concern, layout, smartApp.Languages, smartApp.Api, apiSuffix, viewModelSuffix);
                        PageComponentSpec pageComponentSpec = new PageComponentSpec(smartApp, concern, layout);
                        PageComponentView pageComponentView = new PageComponentView(smartApp, smartApp.Title, concern, layout, smartApp.Languages);
                        PageComponentStyleSheet pageComponentStyleSheet = new PageComponentStyleSheet(smartApp, concern, layout);

                        string path = Path.Combine(_context.BasePath, pageComponent.OutputPath, concern.Id.ToCamelCase(), layout.Id.ToCamelCase());
                        string filename = concern.Id.ToCamelCase() + "-" + layout.Id.ToCamelCase() + ".component";

                        _writingService.WriteFile(Path.Combine(path, filename + ".ts"), pageComponent.TransformText());
                        _writingService.WriteFile(Path.Combine(path, filename + ".spec.ts"), pageComponentSpec.TransformText());
                        _writingService.WriteFile(Path.Combine(path, filename + ".html"), pageComponentView.TransformText());
                        _writingService.WriteFile(Path.Combine(path, filename + ".scss"), pageComponentStyleSheet.TransformText());
         
                    }
                }
            }
        }

        private void TransformTabsModule(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                TabsPage tabsPage = new TabsPage(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tabsPage.OutputPath), tabsPage.TransformText());

                TabsPageSpec tabsPageSpec = new TabsPageSpec(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tabsPageSpec.OutputPath), tabsPageSpec.TransformText());

                TabsModule tabsModule = new TabsModule(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tabsModule.OutputPath), tabsModule.TransformText());

                TabsPageStyleSheet tabsPageStyleSheet = new TabsPageStyleSheet(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tabsPageStyleSheet.OutputPath), tabsPageStyleSheet.TransformText());

                TabsPageView tabsPageView = new TabsPageView(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tabsPageView.OutputPath), tabsPageView.TransformText());
            }
        }

        private void TransformSettingsModule(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                SettingsPage settingsPage = new SettingsPage(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, settingsPage.OutputPath), settingsPage.TransformText());

                SettingsPageSpec settingsPageSpec = new SettingsPageSpec(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, settingsPageSpec.OutputPath), settingsPageSpec.TransformText());

                SettingsModule settingsModule = new SettingsModule(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, settingsModule.OutputPath), settingsModule.TransformText());

                SettingsStyleSheet settingsStyleSheet = new SettingsStyleSheet(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, settingsStyleSheet.OutputPath), settingsStyleSheet.TransformText());

                SettingsView settingsView = new SettingsView(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, settingsView.OutputPath), settingsView.TransformText());
            }
        }

        private string GetViewModelSuffix()
        {
            var viewmodel = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ViewModelSuffix") ? _context.DynamicContext.ViewModelSuffix as List<Answer> : new List<Answer>();

            return (viewmodel != null && viewmodel.Count > 0) ? viewmodel.FirstOrDefault().Value : "ViewModel";
        }

        private string GetApiSuffix()
        {
            var service = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ApiSuffix") ? _context.DynamicContext.ApiSuffix as List<Answer> : new List<Answer>();

            return (service != null && service.Count > 0) ? service.FirstOrDefault().Value : "API";
        }
    }
}
