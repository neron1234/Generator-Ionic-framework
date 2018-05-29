// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a �t� g�n�r� par un outil.
//     Version du runtime�: 15.0.0.0
//  
//     Les changements apport�s � ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est r�g�n�r�.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace GeneratorProject.Platforms.Frontend.Ionic
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Foundation.Jade.Models;
    using Mobioos.Scaffold.Generators.Helpers;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AppComponent : AppBaseClass
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"/*
 * You should add your licence here, here is an example :
 *
 * SonarQube, open source software quality management tool.
 * Copyright (C) 2008-2013 SonarSource
 * mailto:contact AT sonarsource DOT com
 *
 * SonarQube is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * SonarQube is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
");
            
            #line 29 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

    SmartAppInfo smartApp = (SmartAppInfo)Model;
    if (smartApp != null && smartApp.Id != null)
    {

            
            #line default
            #line hidden
            this.Write("import { Component, ViewChild } from \'@angular/core\';\r\nimport { Platform, NavCont" +
                    "roller");
            
            #line 35 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
 if (_isMenu) { 
            
            #line default
            #line hidden
            this.Write(", Events ");
            
            #line 35 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" } from \'ionic-angular\';\r\nimport { StatusBar } from \'@ionic-native/status-bar\';\r\n" +
                    "import { SplashScreen } from \'@ionic-native/splash-screen\';\r\nimport { Title } fr" +
                    "om \'@angular/platform-browser\';\r\n\r\n");
            
            #line 40 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Concerns.AsEnumerable() != null && _rootLayout != null && _rootLayout.Id != null && _rootConcern != null && _rootConcern.Id != null)
      {
        string concern = TextConverter.PascalCase(_rootConcern.Id);
        string layout = TextConverter.PascalCase(_rootLayout.Id);
        string layoutComponent = concern + layout;
        string layoutComponentToLower = TextConverter.CamelCase(concern) + "-" + TextConverter.CamelCase(layout);

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write(" } from \'../pages/");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(concern)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(layout)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponentToLower));
            
            #line default
            #line hidden
            this.Write("\';\r\n");
            
            #line 49 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 53 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
      {

            
            #line default
            #line hidden
            this.Write("import { TranslateService } from \'@ngx-translate/core\';\r\n");
            
            #line 58 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write("/**\r\n * class: ");
            
            #line 62 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(".\r\n");
            
            #line 63 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Description != null)
      {

            
            #line default
            #line hidden
            this.Write(" * ");
            
            #line 67 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Description));
            
            #line default
            #line hidden
            this.Write(".\r\n * This is the main component of the application.\r\n * This component is genera" +
                    "ted from multiple domains.\r\n");
            
            #line 70 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }
      else
      {

            
            #line default
            #line hidden
            this.Write(" * This is the main component of the application.\r\n * This component is generated" +
                    " from multiple domains.\r\n");
            
            #line 77 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write(" */\r\n@Component({\r\n  templateUrl: \'app.html\'\r\n})\r\nexport class ");
            
            #line 84 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 85 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Concerns.AsEnumerable() != null)
      {

            
            #line default
            #line hidden
            this.Write("  @ViewChild(\'nav\') public _nav: NavController;\r\n");
            
            #line 90 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("  public _menu;\r\n");
            
            #line 95 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

        }
      }

            
            #line default
            #line hidden
            this.Write("  constructor(\r\n");
            
            #line 100 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
      {

            
            #line default
            #line hidden
            this.Write("    public _translateService: TranslateService,\r\n");
            
            #line 105 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            
            #line 108 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (_isMenu)
      {

            
            #line default
            #line hidden
            this.Write("    public _events: Events,\r\n");
            
            #line 113 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write(@"    public _platform: Platform,
    public _statusBar: StatusBar,
    public _splashScreen: SplashScreen,
    public _title: Title
   ) {
    this._platform.ready().then(() => {
      this._statusBar.styleDefault();
      this._splashScreen.hide();
");
            
            #line 124 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Concerns.AsEnumerable() != null && _rootLayout != null && _rootLayout.Id != null && _rootConcern != null && _rootConcern.Id != null)
      {
        string concern = TextConverter.PascalCase(_rootConcern.Id);
        string layout = TextConverter.PascalCase(_rootLayout.Id);
        string layoutComponent = concern + layout;

            
            #line default
            #line hidden
            this.Write("      this._nav.setRoot(");
            
            #line 131 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 132 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      this._events.subscribe(\'menu\', (menu => this._menu = menu));\r\n");
            
            #line 137 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

        }
      }

      if (smartApp.Languages.AsEnumerable() != null && smartApp.Languages.AsEnumerable().Count() > 0)
      {

            
            #line default
            #line hidden
            this.Write("      this._translateService.setDefaultLang(\'");
            
            #line 144 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(smartApp.Languages[0].Id)));
            
            #line default
            #line hidden
            this.Write("\');\r\n      this._translateService.use(\'");
            
            #line 145 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(smartApp.Languages[0].Id)));
            
            #line default
            #line hidden
            this.Write("\');\r\n      this._translateService.get(\'applicationTitle\').subscribe(name => {\r\n  " +
                    "      this._title.setTitle(name);\r\n      });\r\n");
            
            #line 149 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write("    });\r\n  }\r\n\r\n");
            
            #line 155 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      if (smartApp.Concerns.AsEnumerable() != null)
      {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * method: selected.\r\n   * That method enables to change page\r\n   * thro" +
                    "ugh the global menu.\r\n   * @param route `string`.\r\n   */\r\n  selected(route: stri" +
                    "ng) {\r\n    this._nav.setRoot(route);\r\n  }\r\n");
            
            #line 168 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

      }

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 172 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\app\AppComponent.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
