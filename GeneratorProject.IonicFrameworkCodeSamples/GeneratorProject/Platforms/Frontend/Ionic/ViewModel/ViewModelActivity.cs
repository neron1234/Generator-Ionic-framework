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
    [Activity(Order = 2)]
    public class ViewModelActivity : GeneratorActivity
    {   
        public ViewModelActivity(string name, string basePath)
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
            TransformViewModels(smartApp);
            await base.Writing();
        }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Start function on generation of layout's viewmodels
        /// </summary>
        /// <param name="smartApp">SmartApp manifeste.</param>
        private void TransformViewModels(SmartAppInfo smartApp)
        {
            List<EntityInfo> alreadyCreated = new List<EntityInfo>();
            if (smartApp != null && smartApp.Version != null)
            {
                //if (smartApp.Concerns.AsEnumerable() != null)
                //{
                //    foreach (ConcernInfo concern in smartApp.Concerns.AsEnumerable())
                //    {
                //        if (concern.Layouts.AsEnumerable() != null)
                //        {
                //            foreach (LayoutInfo layout in concern.Layouts.AsEnumerable())
                //            {
                //                if (layout.DataModel != null && !alreadyCreated.AsEnumerable().Contains(layout.DataModel))
                //                {
                //                    alreadyCreated.Add(layout.DataModel);
                //                    TransformViewModel(layout.DataModel);
                //                }
                //            }
                //        }
                //    }
                //}

                if (smartApp.Api.AsEnumerable() != null)
                {
                    foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                    {
                        if (api.Actions.AsEnumerable() != null)
                        {
                            foreach (ApiActionInfo apiAction in api.Actions.AsEnumerable())
                            {
                                if (apiAction.Parameters.AsEnumerable() != null)
                                {
                                    foreach (ApiParameterInfo apiParameter in apiAction.Parameters.AsEnumerable())
                                    {
                                        if (apiParameter.DataModel != null && !alreadyCreated.AsEnumerable().Contains(apiParameter.DataModel))
                                        {
                                            alreadyCreated.Add(apiParameter.DataModel);
                                            TransformViewModel(apiParameter.DataModel);
                                        }
                                    }
                                }

                                if (apiAction.ReturnType != null && !alreadyCreated.AsEnumerable().Contains(apiAction.ReturnType))
                                {
                                    alreadyCreated.Add(apiAction.ReturnType);
                                    TransformViewModel(apiAction.ReturnType);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generating typescript models containing the
        /// definition of the viewmodel for the current layout.
        /// </summary>
        /// <param name="layout">A layout.</param>
        private void TransformViewModel(EntityInfo dataModel)
        {
            if (dataModel != null && dataModel.Id != null)
            {
                ViewModelTemplate viewModelTemplate = new ViewModelTemplate(dataModel);

                string viewModelDirectoryPath = viewModelTemplate.OutputPath;
                string viewModelFilename = CamelCase(dataModel.Id) + ".ts";

                string fileToWritePath = Path.Combine(BasePath, viewModelDirectoryPath, viewModelFilename);
                string textToWrite = viewModelTemplate.TransformText();

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
