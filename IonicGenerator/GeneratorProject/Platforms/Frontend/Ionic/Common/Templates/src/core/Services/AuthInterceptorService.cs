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
    
    #line 1 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Common\Templates\src\core\Services\AuthInterceptorService.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AuthInterceptorService : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"import {Injectable, Injector} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import {OidcSecurityService} from '../../shared/services/auth-client/oidc-security.service';

@Injectable()

export class AuthInterceptorService implements HttpInterceptor {

  private oidcSecurityService: OidcSecurityService;

  constructor(private injector: Injector) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let requestToForward = req;

    if (this.oidcSecurityService === undefined) {
      this.oidcSecurityService = this.injector.get(OidcSecurityService);
    }

    if (this.oidcSecurityService !== undefined) {
      const token = this.oidcSecurityService.getToken();
      if (token !== '') {
        const tokenValue = 'Bearer ' + token;
        requestToForward = req.clone({setHeaders: {Authorization: tokenValue}});
      }
    } else {
      console.log('SecurityService undefined: NO auth header!');
    }

    return next.handle(requestToForward);
  }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}