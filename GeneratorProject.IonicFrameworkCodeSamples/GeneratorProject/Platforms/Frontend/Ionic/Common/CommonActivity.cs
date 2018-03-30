using Mobioos.Scaffold.Core.Runtime.Activities;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Prompts.Interfaces;
using System.Collections.Generic;
using Mobioos.Foundation.Prompts;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Activity(Order = 1)]
    public class CommonActivity : GeneratorActivity
    {   
        private string _currentDirectoryPath;
        private string _commonTemplates;
        private string _commonTemplatesDirectoryPath;

        
        public CommonActivity(string name, string basePath)
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
            _commonTemplates = "Platforms\\Frontend\\Ionic\\Common\\Templates";
            _commonTemplatesDirectoryPath = Path.Combine(_currentDirectoryPath, _commonTemplates);
            
            await base.Initializing(activityContext);
        }

        /// <summary>
        /// Prompting users with questions. Responses given will help
        /// the activity bringing more spectifications.
        /// </summary>
        [Task(Order = 2)]
        public override Task Prompting()
        {
            var prompts = new List<IQuestion>();
            var choices = new List<IChoice>();
            choices.Add(new Choice { Key = "light", Name = "light", Value = "Light theme" });
            choices.Add(new Choice { Key = "dark", Name = "dark", Value = "Dark theme" });

            prompts.Add(new ChoiceQuestion()
            {
                Id = Guid.NewGuid(),
                Name = "themes",
                Message = "Select a theme",
                Type = QuestionType.Choice,
                Choices = choices
            });

            Prompt(prompts, this, true);
            return base.Prompting();
        }

        /// <summary>
        /// Method invoked when prompting user is done and
        /// answers are given.
        /// </summary>
        /// <param name="questions">A list of questions answered.</param>
        protected override void ActivityPrompt_Completed(IEnumerable<IQuestion> questions)
        {
            string theme = null;

            foreach (var question in questions)
            {
                foreach (var answer in question.Answers)
                {
                    theme = answer.Value;
                }
            }

            Context.Context.Theme = theme;
            base.ActivityPrompt_Completed(questions);
        }

        /// <summary>
        /// Writing task in the Scaffold runtime.
        /// </summary>
        [Task(Order = 3)]
        public async override Task Writing()
        {
            if (null == Context.Context.Manifest)
                throw new ArgumentNullException(nameof(Context.Context.Manifest));

            SmartAppInfo smartApp = Context.Context.Manifest;
            string theme = Context.Context.Theme;
            TransformCommon(smartApp, _commonTemplatesDirectoryPath);
            TransformSimpleTheme(theme);
            await base.Writing();
        }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Generating common components required by Ionic 2 applications' minimal
        /// specifications in order to be compiled.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="commonTemplatesDirectoryPath">Path to common activity templates.</param>
        private void TransformCommon(SmartAppInfo smartApp, string commonTemplatesDirectoryPath)
        {
            if (smartApp != null && commonTemplatesDirectoryPath != null)
            {
                ExecuteTemplates(Constants.CommonActivityName, BasePath, smartApp, Assembly.GetExecutingAssembly());
                CopyDirectory(commonTemplatesDirectoryPath, BasePath);
            }
        }

        /// <summary>
        /// Generating a simple theme selection between dark and light
        /// </summary>
        /// <param name="theme">A theme.</param>
        private void TransformSimpleTheme(string theme)
        {
            Variables variablesTemplate = new Variables(theme);

            string viewModelDirectoryPath = variablesTemplate.OutputPath;

            string fileToWritePath = Path.Combine(BasePath, viewModelDirectoryPath);
            string textToWrite = variablesTemplate.TransformText();

            WriteFile(fileToWritePath, textToWrite);
        }

        #endregion
    }
}
