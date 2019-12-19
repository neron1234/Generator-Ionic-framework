﻿using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class KarmaConf: TemplateBase
    {
        public KarmaConf(SmartAppInfo smartApp) : base(smartApp)
        {
        }
        public override string OutputPath => "src\\karma.conf.js";
    }
}
