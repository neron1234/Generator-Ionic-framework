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
    using Mobioos.Scaffold.BaseGenerators.TextTemplating;
    using Mobioos.Scaffold.BaseGenerators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Package : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 2 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"

    SmartAppInfo smartApp = (SmartAppInfo)Model;
    if (smartApp != null && smartApp.Title != null && smartApp.Version != null)
    {

            
            #line default
            #line hidden
            this.Write("{\r\n  \"name\": \"");
            
            #line 8 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Id.ToLower()));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"displayName\": \"");
            
            #line 9 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Title));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"version\": \"");
            
            #line 10 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_version));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"private\": true,\r\n");
            
            #line 12 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"

      if (smartApp.Description != null)
      {

            
            #line default
            #line hidden
            this.Write("  \"description\": \"");
            
            #line 16 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Description));
            
            #line default
            #line hidden
            this.Write("\",\r\n");
            
            #line 17 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"

      }

            
            #line default
            #line hidden
            this.Write("  \"dependencies\": {\r\n    \"@angular/common\": \"^5.2.9\",\r\n    \"@angular/compiler\": \"" +
                    "^5.2.9\",\r\n    \"@angular/compiler-cli\": \"^5.2.9\",\r\n    \"@angular/core\": \"^5.2.9\"," +
                    "\r\n    \"@angular/forms\": \"^5.2.9\",\r\n    \"@angular/http\": \"^5.2.9\",\r\n    \"@angular" +
                    "/platform-browser\": \"^5.2.9\",\r\n    \"@angular/platform-browser-dynamic\": \"^5.2.9\"" +
                    ",\r\n    \"@ionic-native/core\": \"^4.6.0\",\r\n    \"@ionic-native/splash-screen\": \"^4.6" +
                    ".0\",\r\n    \"@ionic-native/status-bar\": \"^4.6.0\",\r\n    \"@ngx-translate/core\": \"^9." +
                    "1.1\",\r\n    \"@ngx-translate/http-loader\": \"^2.0.1\",\r\n    \"ionic-angular\": \"^3.9.2" +
                    "\",\r\n    \"ionicons\": \"^3.0.0\",\r\n    \"rxjs\": \"^5.5.7\",\r\n    \"sw-toolbox\": \"^3.6.0\"" +
                    ",\r\n    \"zone.js\": \"^0.8.26\"\r\n  },\r\n  \"devDependencies\": {\r\n    \"@angular/cli\": \"" +
                    "^1.6.0\",\r\n    \"@ionic/app-scripts\": \"3.1.4\",\r\n    \"@types/jasmine\": \"^2.8.6\",\r\n " +
                    "   \"@types/node\": \"^9.6.4\",\r\n    \"angular2-template-loader\": \"^0.6.2\",\r\n    \"htm" +
                    "l-loader\": \"^0.5.1\",\r\n    \"jasmine\": \"^2.5.3\",\r\n    \"karma\": \"^2.0.0\",\r\n    \"kar" +
                    "ma-chrome-launcher\": \"^2.2.0\",\r\n    \"karma-jasmine\": \"^1.1.1\",\r\n    \"karma-jasmi" +
                    "ne-html-reporter\": \"^0.2.2\",\r\n    \"karma-mocha-reporter\": \"^2.2.5\",\r\n    \"karma-" +
                    "sourcemap-loader\": \"^0.3.7\",\r\n    \"karma-webpack\": \"^2.0.3\",\r\n    \"null-loader\":" +
                    " \"^0.1.1\",\r\n    \"ts-loader\": \"^3.0.3\",\r\n    \"ts-node\": \"^5.0.1\",\r\n    \"tslint\": " +
                    "\"^5.9.1\",\r\n    \"tslint-eslint-rules\": \"^5.1.0\",\r\n    \"typescript\": \"^2.4.2\"\r\n  }" +
                    ",\r\n  \"scripts\": {\r\n    \"clean\": \"ionic-app-scripts clean\",\r\n    \"build\": \"ionic-" +
                    "app-scripts build\",\r\n    \"ionic:build\": \"ionic-app-scripts build\",\r\n    \"ionic:s" +
                    "erve\": \"ionic-app-scripts serve\",\r\n    \"test\": \"karma start ./test-config/karma." +
                    "conf.js\",\r\n    \"test-ci\": \"karma start ./test-config/karma.conf.js --single-run\"" +
                    ",\r\n    \"test-coverage\": \"karma start ./test-config/karma.conf.js --coverage\"\r\n  " +
                    "}\r\n}\r\n");
            
            #line 72 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\Package.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
