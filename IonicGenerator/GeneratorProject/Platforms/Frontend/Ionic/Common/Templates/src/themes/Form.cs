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
    
    #line 1 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\themes\Form.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Form : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(".error-message {\r\n    padding: 8px 0;\r\n    font-size: 13px;\r\n    line-height: 16p" +
                    "x;\r\n    font-weight: 300;\r\n  \r\n    &.danger {\r\n      background-color: rgba(var(" +
                    "--ion-color-danger-rgb), 0.1);\r\n      color: var(--ion-color-danger);\r\n    }\r\n  " +
                    "}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
