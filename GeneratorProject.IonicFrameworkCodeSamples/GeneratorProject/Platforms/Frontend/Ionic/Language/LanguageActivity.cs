using Mobioos.Scaffold.Core.Runtime.Activities;
using System.IO;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Linq;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Prompts.Interfaces;
using System.Text.RegularExpressions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Activity(Order = 4)]
    public class LanguageActivity : GeneratorActivity
    {
        public LanguageActivity(string name, string basePath)
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
            if (null == Context.DynamicContext.Manifest)
                throw new ArgumentNullException(nameof(Context.DynamicContext.Manifest));

            SmartAppInfo smartApp = Context.DynamicContext.Manifest;
            TransformLanguage(smartApp);
            await base.Writing();
        }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Start function for the generation of languages functionnalities.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformLanguage(SmartAppInfo smartApp)
        {
            if(smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                TransformJsonTemplate(smartApp);
                TransformLanguageComponentTemplate();
                TransformLanguageModuleTemplate();
                // TransformLanguageStyleTemplate();
                TransformLanguageViewTemplate(smartApp);
            }
        }

        /// <summary>
        /// Generating a JSON file for the configuration of internationalization
        /// for each languages described in the manifeste.
        /// </summary>
        /// <param name="smartApp">A SmartApp manifeste.</param>
        public void TransformJsonTemplate(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                foreach (LanguageInfo languageInfo in smartApp.Languages.AsEnumerable())
                {
                    JsonTemplate jsonTemplate = new JsonTemplate(smartApp, languageInfo.Id);
                    string jsonDirectoryPath = Path.Combine(jsonTemplate.OutputPath);
                    string enJsonFile = PascalCase(languageInfo.Id) + ".json";

                    string fileToWritePath = Path.Combine(BasePath, jsonDirectoryPath, enJsonFile);
                    string textToWrite = jsonTemplate.TransformText();

                    WriteFile(fileToWritePath, textToWrite);
                }
            }
        }

        /// <summary>
        /// Generating an angular component giving the ability to change
        /// language in the generated application.
        /// Integrated in the application as a page.
        /// </summary>
        public void TransformLanguageComponentTemplate()
        {
            LanguageComponentTemplate languageComponentTemplate = new LanguageComponentTemplate();

            string fileToWritePath = Path.Combine(BasePath, languageComponentTemplate.OutputPath);
            string textToWrite = languageComponentTemplate.TransformText();

            WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating an angular module which integrates the language page
        /// in the routing of the application.
        /// </summary>
        public void TransformLanguageModuleTemplate()
        {
            LanguageModuleTemplate languageModuleTemplate = new LanguageModuleTemplate();

            string fileToWritePath = Path.Combine(BasePath, languageModuleTemplate.OutputPath);
            string textToWrite = languageModuleTemplate.TransformText();

            WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating a SCSS file containing the language page's
        /// graphics specifications for the view. 
        /// </summary>
        public void TransformLanguageStyleTemplate()
        {
            LanguageStyleTemplate languageStyleTemplate = new LanguageStyleTemplate();

            string fileToWritePath = Path.Combine(BasePath, languageStyleTemplate.OutputPath);
            string textToWrite = languageStyleTemplate.TransformText();

            WriteFile(fileToWritePath, textToWrite);
        }

        /// <summary>
        /// Generating a HTML file for the declaration of the view
        /// of the language page.
        /// </summary>
        /// <param name="smartApp">A SmartApp manifeste.</param>
        public void TransformLanguageViewTemplate(SmartAppInfo smartApp)
        {
            // smartApp.Concerns can be null
            if (smartApp != null && smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
            {
                LanguageViewTemplate languageViewTemplate = new LanguageViewTemplate(smartApp.Concerns, smartApp.Languages);

                string fileToWritePath = Path.Combine(BasePath, languageViewTemplate.OutputPath);
                string textToWrite = languageViewTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
            }
        }

        /// <summary>
        /// Convert a string to PascalCase.
        /// </summary>
        /// <param name="word">A word to convert.</param>
        public static string PascalCase(string word)
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
                splittedString[0] = splittedString[0].Substring(0, 1).ToUpper() + splittedString[0].Substring(1);
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
