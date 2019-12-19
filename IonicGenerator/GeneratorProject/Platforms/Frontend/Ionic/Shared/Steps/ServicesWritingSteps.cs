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
using System.Collections.Generic;
using System.Linq;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class ServicesWritingSteps : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public ServicesWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
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

            _workflowNotifier.Notify(nameof(ServicesWritingSteps), NotificationType.GeneralInfo, "Generating Ionic services");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformApiServices(smartApp);
                TransformCommonServices(smartApp);
                TransformAuthFiles(smartApp);
            }
            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformApiServices(SmartAppInfo smartApp)
        {
            var dynamicContext = ((IDictionary<string, object>)_context.DynamicContext);

            var viewmodel = dynamicContext.ContainsKey("ViewModelSuffix") ? _context.DynamicContext.ViewModelSuffix as List<Answer> : new List<Answer>();
            string viewModelSuffix = (viewmodel != null && viewmodel.Count > 0) ? viewmodel.FirstOrDefault().Value : "ViewModel";

            var service = dynamicContext.ContainsKey("ApiSuffix") ? _context.DynamicContext.ApiSuffix as List<Answer> : new List<Answer>();
            string apiSuffix = (service != null && service.Count > 0) ? service.FirstOrDefault().Value : "Api";

            if (smartApp != null && smartApp.Api != null)
            {
                foreach (var api in smartApp.Api)
                {
                    ApiServices apiService = new ApiServices(smartApp, api, apiSuffix, viewModelSuffix);

                    _writingService.WriteFile(Path.Combine(_context.BasePath, apiService.OutputPath, api.Id.ToCamelCase() + "." + "service.ts"), apiService.TransformText());
                }
            }
        }
        private void TransformCommonServices(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                LoadingService loadingService = new LoadingService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, loadingService.OutputPath), loadingService.TransformText());

                LoggerService loggerService = new LoggerService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, loggerService.OutputPath), loggerService.TransformText());

                FilteringService filteringService = new FilteringService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, filteringService.OutputPath), filteringService.TransformText());

                SortingService sortingService = new SortingService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, sortingService.OutputPath), sortingService.TransformText());

            }
        }

        private void TransformAuthFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                OidcConfigurationService oidcConfigurationService = new OidcConfigurationService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, oidcConfigurationService.OutputPath), oidcConfigurationService.TransformText());

                OidcSecurityService oidcSecurityService = new OidcSecurityService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, oidcSecurityService.OutputPath), oidcSecurityService.TransformText());

            }
        }

    }
}
