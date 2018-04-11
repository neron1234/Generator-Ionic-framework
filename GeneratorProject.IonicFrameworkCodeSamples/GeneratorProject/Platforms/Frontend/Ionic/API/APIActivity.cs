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
using Mobioos.Scaffold.Generators.Helpers;

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
            _currentDirectoryPath = activityContext.DynamicContext.GeneratorPath;
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
            if (null == Context.DynamicContext.Manifest)
                throw new ArgumentNullException(nameof(Context.DynamicContext.Manifest));

            SmartAppInfo smartApp = Context.DynamicContext.Manifest;
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
                    string apiFilename = TextConverter.CamelCase(api.Id) + ".service.ts";

                    string fileToWritePath = Path.Combine(BasePath, apiDirectoryPath, apiFilename);
                    string textToWrite = apiTemplate.TransformText();

                    WriteFile(fileToWritePath, textToWrite);
                }
                CopyDirectory(apiTemplatesDirectoryPath, BasePath);
            }
        }

        #endregion
    }
}
