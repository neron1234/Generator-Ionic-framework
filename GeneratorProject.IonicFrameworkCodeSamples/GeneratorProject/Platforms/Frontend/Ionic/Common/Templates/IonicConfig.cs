// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a �t� g�n�r� par un outil.
//     Version du runtime�: 16.0.0.0
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
    using Mobioos.Foundation.Jade.Models;
    using Common.Generator.Framework.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class IonicConfig : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 2 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"

    var smartApp = (SmartAppInfo)Model;

    if (smartApp != null
        && smartApp.Title != null
        && smartApp.Id != null)
    {

            
            #line default
            #line hidden
            this.Write("{\r\n  \"name\": \"");
            
            #line 8 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Title));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"app_id\": \"");
            
            #line 9 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Id));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"type\": \"ionic-angular\"\r\n}\r\n");
            
            #line 12 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
