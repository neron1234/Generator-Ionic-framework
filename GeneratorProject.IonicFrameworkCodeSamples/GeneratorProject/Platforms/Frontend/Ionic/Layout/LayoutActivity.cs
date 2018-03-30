using Mobioos.Scaffold.Core.Runtime.Activities;
using System.IO;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using Mobioos.Foundation.Jade.Models;
using System.Linq;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Prompts.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Activity(Order = 3)]
    public class LayoutActivity : GeneratorActivity
    {   
        public LayoutActivity(string name, string basePath)
            : base(name, basePath)
        { 
        }

        #region GeneratorActivity Methods

        /// <summary>
        /// Initializing task in the Scaffold runtime.
        /// </summary>
        /// <param name="activityContext">The activityContext which contains the SmartApp's manifeste.</param>
        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            await base.Initializing(activityContext);
        }

        /// <summary>
        /// Prompting users with questions. Responses given will help
        /// the activity bringing more spectifications.
        /// </summary>
        //[Task(2)]
        public override Task Prompting()
        {
            return base.Prompting();
        }

        /// <summary>
        /// Method invoked when prompting user is done and
        /// answers are given.
        /// </summary>
        /// <param name="questions">A list of questions answered.</param>
        protected override void ActivityPrompt_Completed(IEnumerable<IQuestion> questions)
        {
            base.ActivityPrompt_Completed(questions);
        }

        /// <summary>
        /// Writing task in the Scaffold runtime.
        /// </summary>
        [Task(Order = 2)]
        public async override Task Writing()
        {
            if (null == Context.Context.Manifest)
                throw new ArgumentNullException(nameof(Context.Context.Manifest));

            SmartAppInfo smartApp = Context.Context.Manifest;
            TransformLayouts(smartApp);
            await base.Writing();
        }

        #endregion

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
                                // smartApp.Languages can be null
                                TransformLayoutModule(concern.Id, layout, smartApp.Languages, smartApp.Api);
                                TransformLayoutComponent(concern, layout, smartApp.Languages, smartApp.Api);
                                TransformLayoutView(smartApp.Title, concern, layout, smartApp.Languages);
                                // TransformLayoutStyle(concern.Id, layout);
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
            // languages can be null
            if (concernId != null && layout != null && layout.Id != null && api != null)
            {
                LayoutModuleTemplate layoutModuleTemplate = new LayoutModuleTemplate(concernId, layout, languages, api);

                string layoutModuleDirectoryPath = Path.Combine(layoutModuleTemplate.OutputPath, CamelCase(concernId), CamelCase(layout.Id));
                string layoutModuleFilename = CamelCase(concernId) + "-" + CamelCase(layout.Id) + ".module.ts";

                string fileToWritePath = Path.Combine(BasePath, layoutModuleDirectoryPath, layoutModuleFilename);
                string textToWrite = layoutModuleTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
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
            // languages can be null
            if (concern != null && concern.Id != null && layout != null && layout.Id != null && api != null)
            {
                LayoutComponentTemplate layoutComponentTemplate = new LayoutComponentTemplate(concern, layout, languages, api);

                string layoutComponentDirectoryPath = Path.Combine(layoutComponentTemplate.OutputPath, CamelCase(concern.Id), CamelCase(layout.Id));
                string layoutComponentFilename = CamelCase(concern.Id) + "-" + CamelCase(layout.Id) + ".ts";

                string fileToWritePath = Path.Combine(BasePath, layoutComponentDirectoryPath, layoutComponentFilename);
                string textToWrite = layoutComponentTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
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

                string layoutViewDirectoryPath = Path.Combine(layoutViewTemplate.OutputPath, CamelCase(concern.Id), CamelCase(layout.Id));
                string layoutViewFilename = CamelCase(concern.Id) + "-" + CamelCase(layout.Id) + ".html";

                string fileToWritePath = Path.Combine(BasePath, layoutViewDirectoryPath, layoutViewFilename);
                string textToWrite = layoutViewTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
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

                string layoutStyleDirectoryPath = Path.Combine(layoutStyleTemplate.OutputPath, CamelCase(concernId), CamelCase(layout.Id));
                string layoutStyleFilename = CamelCase(concernId) + "-" + CamelCase(layout.Id) + ".scss";

                string fileToWritePath = Path.Combine(BasePath, layoutStyleDirectoryPath, layoutStyleFilename);
                string textToWrite = layoutStyleTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
            }
        }

        /// <summary>
        /// Convert a string to CamelCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string CamelCase(string word)
        {
            string result = "";
            word = word.Trim();
            if (word.Length > 0)
            {
                char[] separators = new char[] {
                    ' ',
                    '-',
                    '_',
                    '/'
                };
                string[] splittedString = word.Split(separators);

                splittedString[0] = Regex.Replace(splittedString[0], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                splittedString[0] = splittedString[0].Replace(" ", string.Empty);
                splittedString[0] = splittedString[0].Substring(0, 1).ToLower() + splittedString[0].Substring(1);
                result += splittedString[0];

                for (int i = 1; i < splittedString.Count(); i++)
                {
                    splittedString[i] = Regex.Replace(splittedString[i], "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
                    splittedString[i] = splittedString[i].Replace(" ", string.Empty);
                    splittedString[i] = splittedString[i].Substring(0, 1).ToUpper() + splittedString[i].Substring(1);
                    result += splittedString[i];
                }
            }
            return result;
        }

        #endregion
    }
}
