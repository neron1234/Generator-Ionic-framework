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
    using Mobioos.Scaffold.TextTemplating;
    using Mobioos.Scaffold.Generators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\Index.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Index : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 2 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\Index.tt"

    SmartAppInfo smartApp = (SmartAppInfo)Model;
    if (smartApp != null && smartApp.Title != null)
    {

            
            #line default
            #line hidden
            this.Write(@"<!DOCTYPE html>
<!--
  You should add your licence here, here is an example :

  SonarQube, open source software quality management tool.
  Copyright (C) 2008-2013 SonarSource
  mailto:contact AT sonarsource DOT com

  SonarQube is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 3 of the License, or (at your option) any later version.
 
  SonarQube is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.
 
  You should have received a copy of the GNU Lesser General Public License
  along with this program; if not, write to the Free Software Foundation,
  Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
-->
<html lang=""en"" dir=""ltr"">
<head>
  <meta charset=""UTF-8"">
  <title>");
            
            #line 32 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\Index.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Title));
            
            #line default
            #line hidden
            this.Write(@"</title>
  <meta name=""viewport""
        content=""viewport-fit=cover,
                 width=device-width,
                 initial-scale=1.0,
                 minimum-scale=1.0,
                 maximum-scale=1.0,
                 user-scalable=no"">
  <meta name=""format-detection"" content=""telephone=no"">
  <meta name=""msapplication-tap-highlight"" content=""no"">
  <link rel=""icon"" type=""image/x-icon"" href=""assets/icon/favicon.ico"">
  <link rel=""manifest"" href=""manifest.json"">
  <meta name=""theme-color"" content=""#4e8ef7"">
  <meta name=""apple-mobile-web-app-capable"" content=""yes"">
  <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
  <script src=""cordova.js""></script>
  <link href=""build/main.css"" rel=""stylesheet"">
</head>
<body>
  <ion-app></ion-app>
  <script src=""build/polyfills.js""></script>
  <script src=""build/vendor.js""></script>
  <script src=""build/main.js""></script>
</body>
</html>
");
            
            #line 57 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\Index.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
