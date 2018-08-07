using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.Helpers;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
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

        public LayoutWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            SmartAppInfo smartApp = _context.Manifest;
            TransformLayouts(smartApp);
            return Task.FromResult(ExecutionResult.Next());
        }

        #region Writing Methods

        /// <summary>
        /// Start function on generation of all concerns' layouts.
        /// </summary>
        /// <param name="smartApp">SmartApp manifeste.</param>
        private void TransformLayouts(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Concerns.AsEnumerable() != null && smartApp.Version != null)
            {
                foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                {
                    if (concern != null && concern.Id != null && concern.Layouts.AsEnumerable() != null)
                    {
                        foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                        {
                            if (layout != null)
                            {
                                TransformLayoutModule(concern.Id, layout, smartApp.Languages, smartApp.Api);
                                TransformLayoutComponent(concern, layout, smartApp.Languages, smartApp.Api);
                                TransformLayoutView(smartApp.Title, concern, layout, smartApp.Languages);
                            }
                        }
                    }
                }
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
        public void TransformLayoutModule(string concernId, LayoutInfo layout, LanguageList languages, ApiList api)
        {
            if (concernId != null && layout != null && layout.Id != null && api != null)
            {
                LayoutModuleTemplate layoutModuleTemplate = new LayoutModuleTemplate(concernId, layout, languages, api);

                string layoutModuleDirectoryPath = Path.Combine(layoutModuleTemplate.OutputPath, TextConverter.CamelCase(concernId), TextConverter.CamelCase(layout.Id));
                string layoutModuleFilename = TextConverter.CamelCase(concernId) + "-" + TextConverter.CamelCase(layout.Id) + ".module.ts";

                string fileToWritePath = Path.Combine(_context.BasePath, layoutModuleDirectoryPath, layoutModuleFilename);
                string textToWrite = layoutModuleTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
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
        public void TransformLayoutComponent(ConcernInfo concern, LayoutInfo layout, LanguageList languages, ApiList api)
        {
            if (concern != null && concern.Id != null && layout != null && layout.Id != null && api != null)
            {
                LayoutComponentTemplate layoutComponentTemplate = new LayoutComponentTemplate(concern, layout, languages, api);

                string layoutComponentDirectoryPath = Path.Combine(layoutComponentTemplate.OutputPath, TextConverter.CamelCase(concern.Id), TextConverter.CamelCase(layout.Id));
                string layoutComponentFilename = TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id) + ".ts";

                string fileToWritePath = Path.Combine(_context.BasePath, layoutComponentDirectoryPath, layoutComponentFilename);
                string textToWrite = layoutComponentTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
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
        public void TransformLayoutView(string smartAppTitle, ConcernInfo concern, LayoutInfo layout, LanguageList languages)
        {
            // languages can be null
            if (smartAppTitle != null && concern != null && concern.Id != null && layout != null && layout.Id != null)
            {
                LayoutViewTemplate layoutViewTemplate = new LayoutViewTemplate(smartAppTitle, concern, layout, languages);

                string layoutViewDirectoryPath = Path.Combine(layoutViewTemplate.OutputPath, TextConverter.CamelCase(concern.Id), TextConverter.CamelCase(layout.Id));
                string layoutViewFilename = TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id) + ".html";

                string fileToWritePath = Path.Combine(_context.BasePath, layoutViewDirectoryPath, layoutViewFilename);
                string textToWrite = layoutViewTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        /// <summary>
        /// Generating a SCSS file containing layout's
        /// graphics specifications for the view.
        /// Ionic 2 recommends a SCSS file for each page. One page = one layout.
        /// </summary>
        /// <param name="concernId">A concern Id.</param>
        /// <param name="layout">A layout.</param>
        public void TransformLayoutStyle(string concernId, LayoutInfo layout)
        {
            if (concernId != null && layout != null && layout.Id != null)
            {
                LayoutStyleTemplate layoutStyleTemplate = new LayoutStyleTemplate(concernId, layout);

                string layoutStyleDirectoryPath = Path.Combine(layoutStyleTemplate.OutputPath, TextConverter.CamelCase(concernId), TextConverter.CamelCase(layout.Id));
                string layoutStyleFilename = TextConverter.CamelCase(concernId) + "-" + TextConverter.CamelCase(layout.Id) + ".scss";

                string fileToWritePath = Path.Combine(_context.BasePath, layoutStyleDirectoryPath, layoutStyleFilename);
                string textToWrite = layoutStyleTemplate.TransformText();

                _writingService.WriteFile(fileToWritePath, textToWrite);
            }
        }

        #endregion
    }
}
