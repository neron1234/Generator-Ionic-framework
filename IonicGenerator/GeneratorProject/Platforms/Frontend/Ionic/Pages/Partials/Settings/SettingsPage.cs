﻿using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using Mobioos.Foundation.Jade.Models;

namespace GeneratorProject.Platforms.Frontend.Ionic
{
    public partial class SettingsPage: TemplateBase
    {
        public SettingsPage(SmartAppInfo smartApp) : base(smartApp)
        {
            
        }
        public override string OutputPath => "src\\app\\pages\\appsettings\\app-settings.page.ts";
    }
}
