using Mobioos.Scaffold.Core.Runtime.Activities;
using System.IO;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using Mobioos.Foundation.Jade.Models;
using System.Linq;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using System.Collections.Generic;
using Mobioos.Foundation.Prompts.Interfaces;
using System.Text.RegularExpressions;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Activity(Order = 6)]
    public class ApiActivity : GeneratorActivity
    {
        private string _currentDirectoryPath;
        private string _apiTemplates;

        private string _apiTemplatesDirectoryPath;

        public ApiActivity(string name, string basePath)
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
            _currentDirectoryPath = activityContext.Context.GeneratorPath;
            _apiTemplates = "Platforms\\Frontend\\Ionic\\API\\Templates";
            _apiTemplatesDirectoryPath = Path.Combine(_currentDirectoryPath, _apiTemplates);
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
            TransformApi(smartApp, _apiTemplatesDirectoryPath);
            await base.Writing();
        }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Start function for the generation of all apis.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformApi(SmartAppInfo smartApp, string apiTemplatesDirectoryPath)
        {
            if (smartApp != null && smartApp.Api.AsEnumerable() != null)
            {
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    ApiTemplate apiTemplate = new ApiTemplate(api);

                    string apiDirectoryPath = apiTemplate.OutputPath;
                    string apiFilename = CamelCase(api.Id) + ".service.ts";

                    string fileToWritePath = Path.Combine(BasePath, apiDirectoryPath, apiFilename);
                    string textToWrite = apiTemplate.TransformText();

                    WriteFile(fileToWritePath, textToWrite);
                }
                CopyDirectory(apiTemplatesDirectoryPath, BasePath);
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
