﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    
    #line 1 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class IonicConfig : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"

    var smartApp = (SmartAppInfo)Model;

            
            #line default
            #line hidden
            
            #line 5 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"

    if (smartApp != null && smartApp.Id != null)
    {

            
            #line default
            #line hidden
            this.Write("{\r\n  \"name\": \"");
            
            #line 10 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Id));
            
            #line default
            #line hidden
            this.Write("\",\r\n  \"integrations\": {},\r\n  \"type\": \"angular\"\r\n}\r\n");
            
            #line 14 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\IonicConfig.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}