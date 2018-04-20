using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompts.Interfaces;
using Mobioos.Scaffold.Core.Runtime.Activities;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Scaffold.Generators.Helpers;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    [Activity(Order = 7)]
    public class UnitTestsActivity : GeneratorActivity
    {
        private string _currentDirectoryPath;
        private string _unitTestsTemplates;

        private string _unitTestsTemplatesDirectoryPath;

        public UnitTestsActivity(string name, string basePath)
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
            _unitTestsTemplates = "Platforms\\Frontend\\Ionic\\UnitTests\\Templates";
            _unitTestsTemplatesDirectoryPath = Path.Combine(_currentDirectoryPath, _unitTestsTemplates);
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
            TransformUnitTests(smartApp, _unitTestsTemplatesDirectoryPath);
            await base.Writing();
        }

        #endregion

        #region Writing Methods

        /// <summary>
        /// Generating unit tests.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        /// <param name="unitTestsTemplatesDirectoryPath">Path to common unit tests templates.</param>
        private void TransformUnitTests(SmartAppInfo smartApp, string unitTestsTemplatesDirectoryPath)
        {
            if (smartApp != null && unitTestsTemplatesDirectoryPath != null)
            {
                TransformServicesMocks(smartApp);
                TransformServicesSpecs(smartApp);
                TransformAppComponentSpec(smartApp);
                TransformComponentSpecs(smartApp);
                if (smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
                {
                    TransformLanguagePageSpec(smartApp);
                }
                CopyDirectory(unitTestsTemplatesDirectoryPath, BasePath);
            }
        }

        /// <summary>
        /// Transform each services into mocks form.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesMocks(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Api.AsEnumerable() != null)
            {
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    MocksTemplate mocksTemplate = new MocksTemplate(api);

                    string mocksDirectoryPath = mocksTemplate.OutputPath;
                    string mocksFilename = TextConverter.CamelCase(api.Id) + "Mock.ts";

                    string fileToWritePath = Path.Combine(BasePath, mocksDirectoryPath, mocksFilename);
                    string textToWrite = mocksTemplate.TransformText();

                    WriteFile(fileToWritePath, textToWrite);
                }
            }
        }

        /// <summary>
        /// Create a spec file for each service.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformServicesSpecs(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Api.AsEnumerable() != null)
            {
                foreach (ApiInfo api in smartApp.Api.AsEnumerable())
                {
                    ServiceSpecTemplate servicesSpecsTemplate = new ServiceSpecTemplate(api);

                    string servicesSpecsDirectoryPath = servicesSpecsTemplate.OutputPath;
                    string servicesSpecsFilename = TextConverter.CamelCase(api.Id) + ".spec.ts";

                    string fileToWritePath = Path.Combine(BasePath, servicesSpecsDirectoryPath, servicesSpecsFilename);
                    string textToWrite = servicesSpecsTemplate.TransformText();

                    WriteFile(fileToWritePath, textToWrite);
                }
            }
        }

        /// <summary>
        /// Create a spec file for app.component.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformAppComponentSpec(SmartAppInfo smartApp)
        {
            if (smartApp != null)
            {
                AppComponentSpecTemplate appComponentSpecTemplate = new AppComponentSpecTemplate(smartApp);

                string appComponentSpecDirectoryPath = appComponentSpecTemplate.OutputPath;
                string appComponentSpecFilename = "app.component.spec.ts";

                string fileToWritePath = Path.Combine(BasePath, appComponentSpecDirectoryPath, appComponentSpecFilename);
                string textToWrite = appComponentSpecTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
            }
        }

        /// <summary>
        /// Create a spec file for each component.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformComponentSpecs(SmartAppInfo smartApp)
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
                                ComponentSpecTemplate componentsSpecTemplate = new ComponentSpecTemplate(smartApp.Id, concern, layout, smartApp.Languages, smartApp.Api);

                                string componentsSpecDirectoryPath = Path.Combine(componentsSpecTemplate.OutputPath, TextConverter.CamelCase(concern.Id), TextConverter.CamelCase(layout.Id));
                                string componentsSpecFilename = TextConverter.CamelCase(concern.Id) + "-" + TextConverter.CamelCase(layout.Id) + ".spec.ts";

                                string fileToWritePath = Path.Combine(BasePath, componentsSpecDirectoryPath, componentsSpecFilename);
                                string textToWrite = componentsSpecTemplate.TransformText();

                                WriteFile(fileToWritePath, textToWrite);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create a spec file for the language page.
        /// </summary>
        /// <param name="smartApp">A SmartApp's manifeste.</param>
        private void TransformLanguagePageSpec(SmartAppInfo smartApp)
        {
            if (smartApp != null && smartApp.Id != null)
            {
                LanguagePageSpecTemplate languagePageSpecTemplate = new LanguagePageSpecTemplate(smartApp.Id);

                string languagePageSpecDirectoryPath = languagePageSpecTemplate.OutputPath;
                string languagePageSpecFilename = "language.spec.ts";

                string fileToWritePath = Path.Combine(BasePath, languagePageSpecDirectoryPath, languagePageSpecFilename);
                string textToWrite = languagePageSpecTemplate.TransformText();

                WriteFile(fileToWritePath, textToWrite);
            }
        }

        #endregion
    }
}
