using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public class LayoutWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public LayoutWritingStep(
            ISessionContext context,
            IWriting writingService,
            IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (_context.Manifest == null)
            {
                throw new ArgumentNullException(nameof(_context.Manifest));
            }

            var smartApp = _context.Manifest;

            _workflowNotifier.Notify(
                nameof(LayoutWritingStep),
                NotificationType.GeneralInfo,
                "Generating ionic views");

            if (_context.BasePath != null)
            {
                TransformLayouts(smartApp);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Start function on generation of all concerns' layouts.
        /// </summary>
        /// <param name="smartApp">SmartApp manifeste.</param>
        private void TransformLayouts(SmartAppInfo smartApp)
        {
            var layouts = smartApp.GetLayouts();

            foreach (var layout in layouts.AsEnumerable())
            {
                TransformLayoutModule(
                    ((ConcernInfo)layout.Parent).Id,
                    layout,
                    smartApp.Languages,
                    smartApp.Api);

                TransformLayoutComponent(
                    ((ConcernInfo)layout.Parent),
                    layout,
                    smartApp.Languages,
                    smartApp.Api);

                TransformLayoutView(
                    smartApp.Title,
                    ((ConcernInfo)layout.Parent),
                    layout,
                    smartApp.Languages);
            }
        }

        /// <summary>
        /// Generating an angular module containing the configuration
        /// required to get the page integrated in the Ionic 2 navigation.
        /// Ionic 2 recommends a module for each page. One page = one layout.
        /// </summary>
        /// <param name="concernId">A concern Id.</param>
        /// <param name="layout">A layout.</param>
        /// <param name="languages">A list of languages. (can be null)</param>
        /// <param name="api">A lit of apis.</param>
        public void TransformLayoutModule(
            string concernId,
            LayoutInfo layout,
            LanguageList languages,
            ApiList api)
        {
            if (concernId != null
                && layout != null
                && layout.Id != null
                && api != null)
            {
                var layoutModuleTemplate = new LayoutModuleTemplate(
                    concernId,
                    layout,
                    languages,
                    api);

                var layoutModuleDirectoryPath = Path.Combine(
                    layoutModuleTemplate.OutputPath,
                    concernId.ToCamelCase(),
                    layout.Id.ToCamelCase());

                var layoutModuleFilename =
                    $"{concernId.ToCamelCase()}-{layout.Id.ToCamelCase()}.module.ts";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    layoutModuleDirectoryPath,
                    layoutModuleFilename);

                var textToWrite = layoutModuleTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        /// <summary>
        /// Generating an angular component containing routing definition
        /// and controls for the current layout.
        /// Ionic 2 recommends a component for each page. One page = one layout.
        /// </summary>
        /// <param name="concern">A concern.</param>
        /// <param name="layout">A layout.</param>
        /// <param name="languages">A list of languages. (can be null)</param>
        /// <param name="api">A list of apis.</param>
        public void TransformLayoutComponent(
            ConcernInfo concern,
            LayoutInfo layout,
            LanguageList languages,
            ApiList api)
        {
            if (concern != null
                && concern.Id != null
                && layout != null
                && layout.Id != null
                && api != null)
            {
                var layoutComponentTemplate = new LayoutComponentTemplate(
                    concern,
                    layout,
                    languages,
                    api);

                var layoutComponentDirectoryPath = Path.Combine(
                    layoutComponentTemplate.OutputPath,
                    concern.Id.ToCamelCase(),
                    layout.Id.ToCamelCase());

                var layoutComponentFilename =
                    $"{concern.Id.ToCamelCase()}-{layout.Id.ToCamelCase()}.ts";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    layoutComponentDirectoryPath,
                    layoutComponentFilename);

                var textToWrite = layoutComponentTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        /// <summary>
        /// Generating a HTML file containing the view description for the
        /// current layout.
        /// Ionic 2 recommends a HTML file for each page. One page = one layout.
        /// </summary>
        /// <param name="smartAppTitle">A SmartApp title.</param>
        /// <param name="concern">A concern.</param>
        /// <param name="layout">A layout.</param>
        /// <param name="languages">A list of languages. (can be null)</param>
        public void TransformLayoutView(
            string smartAppTitle,
            ConcernInfo concern,
            LayoutInfo layout,
            LanguageList languages)
        {
            // languages can be null
            if (smartAppTitle != null
                && concern != null
                && concern.Id != null 
                && layout != null
                && layout.Id != null)
            {
                var layoutViewTemplate = new LayoutViewTemplate(
                    smartAppTitle,
                    concern,
                    layout,
                    languages);

                var layoutViewDirectoryPath = Path.Combine(
                    layoutViewTemplate.OutputPath,
                    concern.Id.ToCamelCase(),
                    layout.Id.ToCamelCase());

                var layoutViewFilename =
                    $"{concern.Id.ToCamelCase()}-{layout.Id.ToCamelCase()}.html";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    layoutViewDirectoryPath,
                    layoutViewFilename);

                var textToWrite = layoutViewTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        /// <summary>
        /// Generating a SCSS file containing layout's
        /// graphics specifications for the view.
        /// Ionic 2 recommends a SCSS file for each page. One page = one layout.
        /// </summary>
        /// <param name="concernId">A concern Id.</param>
        /// <param name="layout">A layout.</param>
        public void TransformLayoutStyle(
            string concernId,
            LayoutInfo layout)
        {
            if (concernId != null
                && layout != null
                && layout.Id != null)
            {
                var layoutStyleTemplate = new LayoutStyleTemplate(concernId, layout);

                var layoutStyleDirectoryPath = Path.Combine(
                    layoutStyleTemplate.OutputPath,
                    concernId.ToCamelCase(),
                    layout.Id.ToCamelCase());

                var layoutStyleFilename =
                    $"{concernId.ToCamelCase()}-{layout.Id.ToCamelCase()}.scss";

                var fileToWritePath = Path.Combine(
                    _context.BasePath,
                    layoutStyleDirectoryPath,
                    layoutStyleFilename);

                var textToWrite = layoutStyleTemplate.TransformText();

                _writingService.WriteFile(
                    fileToWritePath,
                    textToWrite);
            }
        }

        #endregion
    }
}
