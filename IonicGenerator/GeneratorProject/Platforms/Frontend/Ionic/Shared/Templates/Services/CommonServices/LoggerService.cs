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
    
    #line 1 "D:\New folder\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Shared\Templates\Services\CommonServices\LoggerService.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class LoggerService : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

export class LoggerService {

    user:any = {};
    private TOKEN_KEY = 'token';

    get token() {
        return localStorage.getItem(this.TOKEN_KEY);
    }

    setCurrentUser(currentUser){
        this.user=currentUser;
    }

    getCurrentUser(){    
        return this.user;
    }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
