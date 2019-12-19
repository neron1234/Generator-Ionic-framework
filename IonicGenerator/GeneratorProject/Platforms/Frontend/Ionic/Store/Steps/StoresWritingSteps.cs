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
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class StoresWritingSteps: StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public StoresWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
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

            _workflowNotifier.Notify(nameof(ModelsWritingSteps), NotificationType.GeneralInfo, "Generating Angular Ngrx Store");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformStoreFiles(smartApp);
                TransformStoresFeatures(smartApp);

            }
            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformStoreFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                RootIndex rootIndex = new RootIndex(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, rootIndex.OutputPath), rootIndex.TransformText());

                RootState rootState = new RootState(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, rootState.OutputPath), rootState.TransformText());

                RootStoreModule rootStoreModule = new RootStoreModule(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, rootStoreModule.OutputPath), rootStoreModule.TransformText());
            }
        }

        private void TransformStoresFeatures(SmartAppInfo manifest)
        {
            string modelSuffix = GetModelSuffix();
            string apiSuffix = GetApiSuffix();
            string viewModelSuffix = GetViewModelSuffix();

            if (manifest.Api != null)
            {
                foreach (var api in manifest.Api)
                {
                    TransformStoresFeatureActions(manifest, api, apiSuffix, viewModelSuffix);
                    TransformStoresFeatureReducers(manifest, api, apiSuffix, viewModelSuffix);
                    TransformStoresFeatureEffects(manifest, api, apiSuffix, viewModelSuffix);
                    TransformStoresFeatureState(manifest, api, apiSuffix, modelSuffix, viewModelSuffix);
                    TransformStoresFeatureSelectors(manifest, api);
                    TransformStoresFeatureStoreModule(manifest, api, apiSuffix);
                    TransformStoresFeatureIndex(manifest, api, apiSuffix);
                }
            }
        }

        private void TransformStoresFeatureActions(SmartAppInfo manifest, ApiInfo api, string apiSuffix, string viewModelSuffix)
        {
            FeatureActions featureActions = new FeatureActions(manifest, api, apiSuffix, viewModelSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureActions.OutputPath), featureActions.TransformText());
        }

        private void TransformStoresFeatureReducers(SmartAppInfo manifest, ApiInfo api, string apiSuffix, string viewModelSuffix)
        {
            FeatureReducers featureReducers = new FeatureReducers(manifest, api, apiSuffix, viewModelSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureReducers.OutputPath), featureReducers.TransformText());
        }

        private void TransformStoresFeatureEffects(SmartAppInfo manifest, ApiInfo api, string apiSuffix, string viewModelSuffix)
        {
            FeatureEffects featureEffects = new FeatureEffects(manifest, api, apiSuffix, viewModelSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureEffects.OutputPath), featureEffects.TransformText());
        }

        private void TransformStoresFeatureState(SmartAppInfo manifest, ApiInfo api, string apiSuffix, string modelSuffix, string viewModelSuffix)
        {
            FeatureState featureState = new FeatureState(manifest, api, apiSuffix, modelSuffix, viewModelSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureState.OutputPath), featureState.TransformText());
        }

        private void TransformStoresFeatureSelectors(SmartAppInfo manifest, ApiInfo api)
        {
            FeatureSelectors featureSelectors = new FeatureSelectors(manifest, api);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureSelectors.OutputPath), featureSelectors.TransformText());
        }

        private void TransformStoresFeatureStoreModule(SmartAppInfo manifest, ApiInfo api, string apiSuffix)
        {
            FeatureStoreModule featureStoreModule = new FeatureStoreModule(manifest, api, apiSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureStoreModule.OutputPath), featureStoreModule.TransformText());
        }

        private void TransformStoresFeatureIndex(SmartAppInfo manifest, ApiInfo api, string apiSuffix)
        {
            FeatureIndex featureIndex = new FeatureIndex(manifest, api, apiSuffix);
            _writingService.WriteFile(Path.Combine(_context.BasePath, featureIndex.OutputPath), featureIndex.TransformText());
        }

        private string GetModelSuffix()
        {
            var modelSuffix = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ModelSuffix") ? _context.DynamicContext.ModelSuffix as List<Answer> : new List<Answer>();

            return (modelSuffix != null && modelSuffix.Count > 0) ? modelSuffix.FirstOrDefault().Value : "Model";

        }

        private string GetApiSuffix()
        {
            var apiSuffix = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ApiSuffix") ? _context.DynamicContext.ApiSuffix as List<Answer> : new List<Answer>();

            return (apiSuffix != null && apiSuffix.Count > 0) ? apiSuffix.FirstOrDefault().Value : "Service";


        }
        private string GetViewModelSuffix()
        {
            var viewmodel = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("ViewModelSuffix") ? _context.DynamicContext.ViewModelSuffix as List<Answer> : new List<Answer>();

            return (viewmodel != null && viewmodel.Count > 0) ? viewmodel.FirstOrDefault().Value : "ViewModel";
        }
    }
}
