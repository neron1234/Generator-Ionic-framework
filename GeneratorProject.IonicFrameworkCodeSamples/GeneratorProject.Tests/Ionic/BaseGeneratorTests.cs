using Mobioos.Scaffold.Core.Runtime;
using Mobioos.Scaffold.Infrastructure.Runtime;
using Mobioos.Foundation.Jade;
using System.Dynamic;
using System.IO;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Tests.Generators.Frontend.Ionic
{
    public class BaseGeneratorTests
    {
        protected string _smartAppPath { get; set; }
        protected IActivityContext _context { get; set; }

        public BaseGeneratorTests()
        {
            _smartAppPath = Path.Combine(Directory.GetCurrentDirectory(), "Manifest");
            _context = new ActivityContext(new ExpandoObject(), null, null);
            _context.DynamicContext.Manifest = JadeEngine.Parse(_smartAppPath);
            _context.DynamicContext.GeneratorPath = Directory.GetCurrentDirectory();
            _context.DynamicContext.Theme = "light";
            _context.DynamicContext.ViewModelSuffix = "ViewModel";
            _context.DynamicContext.ApiSuffix = "Service";

            TransformSuffixes();
        }

        public void TransformSuffixes()
        {
            TransformViewModelSuffixes();
            TransformServicesSuffixes();
        }

        public void TransformViewModelSuffixes()
        {
            for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Api.Count; i++)
            {
                (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Id += _context.DynamicContext.ApiSuffix;

                for (int j = 0; j < (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions.Count; j++)
                {
                    if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].ReturnType != null)
                        (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].ReturnType.Id += _context.DynamicContext.ViewModelSuffix;

                    for (int k = 0; k < (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].Parameters.Count; k++)
                    {
                        if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].Parameters[k].DataModel != null)
                        {
                            (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].Parameters[k].Type += _context.DynamicContext.ViewModelSuffix;
                            (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Actions[j].Parameters[k].DataModel.Id += _context.DynamicContext.ViewModelSuffix;
                        }
                    }
                }
            }
        }

        public void GetApis()
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Api != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Api.Count; i++)
                {
                    (_context.DynamicContext.Manifest as SmartAppInfo).Api[i].Id += _context.DynamicContext.ApiSuffix;

                    GetApisActions(i);
                }
            }
        }

        public void GetApisActions(int indexApi)
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions.Count; i++)
                {
                    if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[i].ReturnType != null)
                        (_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[i].ReturnType.Id += _context.DynamicContext.ViewModelSuffix;

                    GetApisActionsParameters(indexApi, i);
                }
            }
        }
        
        public void GetApisActionsParameters(int indexApi, int indexAction)
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[indexAction].Parameters != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[indexAction].Parameters.Count; i++)
                {
                    if ((_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[indexAction].Parameters[i].DataModel != null)
                    {
                        (_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[indexAction].Parameters[i].Type += _context.DynamicContext.ViewModelSuffix;
                        (_context.DynamicContext.Manifest as SmartAppInfo).Api[indexApi].Actions[indexAction].Parameters[i].DataModel.Id += _context.DynamicContext.ViewModelSuffix;
                    }
                }
            }
        }

        public void TransformServicesSuffixes()
        {
            GetConcerns();
        }

        public void GetConcerns()
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Concerns.Count; i++)
                {
                    GetLayouts(i);
                }
            }
        }

        public void GetLayouts(int indexConcern)
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts.Count; i++)
                {
                    GetLayoutsActions(indexConcern, i);
                }
            }
        }

        public void GetLayoutsActions(int indexConcern, int indexLayout)
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions != null)
            {
                for (int i = 0; i < (_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions.Count; i++)
                {
                    TransformOneSeviceSuffix(indexConcern, indexLayout, i);
                }
            }
        }

        public void TransformOneSeviceSuffix(int indexConcern, int indexLayout, int indexAction)
        {
            if ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions[indexAction].Type != null)
            {
                switch ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions[indexAction].Type.ToLower())
                {
                    case "dataget":
                    case "datalist":
                    case "datacreate":
                    case "datadelete":
                    case "dataupdate":
                        if ((_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions[indexAction].Api != null)
                        {
                            char delimiter = '.';
                            string[] actionSplitted = (_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions[indexAction].Api.Split(delimiter);
                            string apiService = actionSplitted[0] + _context.DynamicContext.ApiSuffix;
                            string apiAction = actionSplitted[1];
                            (_context.DynamicContext.Manifest as SmartAppInfo).Concerns[indexConcern].Layouts[indexLayout].Actions[indexAction].Api = apiService + "." + apiAction;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        protected void Clear()
        {
            var directoryPath = Path.Combine(Path.GetTempPath(), _context.DynamicContext.Manifest.Id);
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }
    }
}
