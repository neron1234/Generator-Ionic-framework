﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime : 15.0.0.0
//  
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace GeneratorProject.Platforms.Frontend.Ionic
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Scaffold.BaseGenerators.TextTemplating;
    using Mobioos.Scaffold.BaseGenerators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Language\Templates\LanguageComponentTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class LanguageComponentTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n/*\r\n * You should add your licence here, here is an example :\r\n *\r\n * SonarQube" +
                    ", open source software quality management tool.\r\n * Copyright (C) 2008-2013 Sona" +
                    "rSource\r\n * mailto:contact AT sonarsource DOT com\r\n *\r\n * SonarQube is free soft" +
                    "ware; you can redistribute it and/or\r\n * modify it under the terms of the GNU Le" +
                    "sser General Public\r\n * License as published by the Free Software Foundation; ei" +
                    "ther\r\n * version 3 of the License, or (at your option) any later version.\r\n *\r\n " +
                    "* SonarQube is distributed in the hope that it will be useful,\r\n * but WITHOUT A" +
                    "NY WARRANTY; without even the implied warranty of\r\n * MERCHANTABILITY or FITNESS" +
                    " FOR A PARTICULAR PURPOSE.  See the GNU\r\n * Lesser General Public License for mo" +
                    "re details.\r\n *\r\n * You should have received a copy of the GNU Lesser General Pu" +
                    "blic License\r\n * along with this program; if not, write to the Free Software Fou" +
                    "ndation,\r\n * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA." +
                    "\r\n */\r\nimport { Component } from \'@angular/core\';\r\nimport { IonicPage, NavContro" +
                    "ller } from \'ionic-angular\';\r\nimport { TranslateService } from \'@ngx-translate/c" +
                    "ore\';\r\n\r\n/**\r\n * class: LanguagePage.\r\n * That page is used to change the global" +
                    "\r\n * language inside the application.\r\n * This is the component of the internati" +
                    "onalization\r\n * inside the application.\r\n * That component is generated from Sma" +
                    "rtApp domain.\r\n */\r\n@IonicPage()\r\n@Component({\r\n  selector: \'page-language\',\r\n  " +
                    "templateUrl: \'language.html\',\r\n})\r\nexport class LanguagePage {\r\n  constructor(pu" +
                    "blic _navCtrl: NavController, public _translateService: TranslateService) {}\r\n\r\n" +
                    "  /**\r\n   * method: changeLanguage.\r\n   * That method enables to change the glob" +
                    "al\r\n   * language inside the application.\r\n   * @param language Should be a lang" +
                    "uage \r\n   *        described in the HTML.\r\n   */\r\n  changeLanguage(language: str" +
                    "ing){\r\n    this._translateService.use(language);\r\n    this._navCtrl.pop();\r\n  }\r" +
                    "\n\r\n  /**\r\n   * method: onLanguage.\r\n   * That method enables to quit the languag" +
                    "e\r\n   * page with the same button as in other html.\r\n   */\r\n  onLanguage() {\r\n  " +
                    "  this._navCtrl.pop();\r\n  }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
