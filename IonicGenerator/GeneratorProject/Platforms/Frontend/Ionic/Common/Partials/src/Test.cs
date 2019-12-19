﻿using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class Test: TemplateBase
    {
        public Test(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\test.ts";
    }
}