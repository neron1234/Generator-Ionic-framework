using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class CommonWritingSteps: StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public CommonWritingSteps(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
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
            string theme = GetTheme();

            _workflowNotifier.Notify(nameof(CommonWritingSteps), NotificationType.GeneralInfo, "Generating ionic common files");

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                TransformAssets(smartApp);
                TransformAppFiles(smartApp);
                TransformCoreModuleServicesFiles(smartApp);
                TransformEnvironmentsFiles(smartApp);
                TransformThemeFiles(smartApp);
                TransformCommonFiles(smartApp, theme);
                TransformCustomThemeFile(smartApp, theme);

            }
            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformAssets(SmartAppInfo smartApp)
        {
            var commonTemplates = "Platforms\\Frontend\\Angular\\Common\\Templates";
            if (smartApp != null)
            {
                var assetsPath = Path.Combine(_context.GeneratorPath, commonTemplates, "src");
                _writingService.CopyDirectory(assetsPath, _context.BasePath);
            }
        }

        private void TransformAppFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                AppComponent appComponent = new AppComponent(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appComponent.OutputPath), appComponent.TransformText());

                AppComponentSpec appComponentSpec = new AppComponentSpec(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appComponentSpec.OutputPath), appComponentSpec.TransformText());

                AppModule appModule = new AppModule(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appModule.OutputPath), appModule.TransformText());

                AppRoutingModule appRoutingModule = new AppRoutingModule(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appRoutingModule.OutputPath), appRoutingModule.TransformText());

                AppStyleSheet appStyleSheet = new AppStyleSheet(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appStyleSheet.OutputPath), appStyleSheet.TransformText());

                AppView appView = new AppView(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, appView.OutputPath), appView.TransformText());
            }
        }

         private void TransformCoreModuleServicesFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                ApiBaseService apiBaseService = new ApiBaseService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, apiBaseService.OutputPath), apiBaseService.TransformText());

                AuthInterceptorService authInterceptorService = new AuthInterceptorService(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, authInterceptorService.OutputPath), authInterceptorService.TransformText());

                AuthorizationGuard authorizationGuard = new AuthorizationGuard(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, authorizationGuard.OutputPath), authorizationGuard.TransformText());
            }
        }

        private void TransformEnvironmentsFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                Environment environment = new Environment(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, environment.OutputPath), environment.TransformText());

                EnvironmentProd environmentProd = new EnvironmentProd(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, environmentProd.OutputPath), environmentProd.TransformText());
            }
        }

        private void TransformThemeFiles(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                Form form = new Form(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, form.OutputPath), form.TransformText());

                Variables variables = new Variables(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, variables.OutputPath), variables.TransformText());
             }
        }

        private void TransformCustomThemeFile(SmartAppInfo smartApp, string theme)
        {
            if (smartApp != null && theme.ToLower() != "dark" && theme.ToLower() != "light")
            {
                Theme customTheme = new Theme(smartApp, theme);
                    _writingService.WriteFile(Path.Combine(_context.BasePath, customTheme.OutputPath), customTheme.TransformText());
            }
        }

        private void TransformCommonFiles(SmartAppInfo smartApp, string theme)
        {
            if (smartApp != null)
            {
                GlobalCss globalCss = new GlobalCss(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, globalCss.OutputPath), globalCss.TransformText());

                Index index = new Index(smartApp, theme);
                _writingService.WriteFile(Path.Combine(_context.BasePath, index.OutputPath), index.TransformText());

                KarmaConf karmaConf = new KarmaConf(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, karmaConf.OutputPath), karmaConf.TransformText());

                Main main = new Main(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, main.OutputPath), main.TransformText());

                Polyfills polyfills = new Polyfills(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, polyfills.OutputPath), polyfills.TransformText());

                Test test = new Test(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, test.OutputPath), test.TransformText());

                TSConfigApp tSConfigApp = new TSConfigApp(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tSConfigApp.OutputPath), tSConfigApp.TransformText());

                TSConfigAppSpec tSConfigAppSpec = new TSConfigAppSpec(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tSConfigAppSpec.OutputPath), tSConfigAppSpec.TransformText());

                TSLintJson tSLintJson = new TSLintJson(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tSLintJson.OutputPath), tSLintJson.TransformText());

                ZoneFlags zoneFlags = new ZoneFlags(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, zoneFlags.OutputPath), zoneFlags.TransformText());

                IonicConfig ionicConfig = new IonicConfig(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, ionicConfig.OutputPath), ionicConfig.TransformText());

                AngularJson angularJson = new AngularJson(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, angularJson.OutputPath), angularJson.TransformText());

                PackageJson packageJson = new PackageJson(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, packageJson.OutputPath), packageJson.TransformText());

                TSConfig tSConfig = new TSConfig(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tSConfig.OutputPath), tSConfig.TransformText());

                TSLint tSLint = new TSLint(smartApp);
                _writingService.WriteFile(Path.Combine(_context.BasePath, tSLint.OutputPath), tSLint.TransformText());
            }
        }

        private string GetTheme()
        {
            var theme = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("Theme") ? _context.DynamicContext.Theme as List<Answer> : new List<Answer>();

            return (theme != null && theme.Count > 0) ? theme.FirstOrDefault().Value : "light";

        }

    }
}
