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
    
    #line 1 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class PageSpec : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"

    var model = (SmartAppInfo)Model;

            
            #line default
            #line hidden
            this.Write("import { CUSTOM_ELEMENTS_SCHEMA } from \'@angular/core\';\r\nimport { async, Componen" +
                    "tFixture, TestBed } from \'@angular/core/testing\';\r\n\r\nimport { ");
            
            #line 8 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Page } from \'./");
            
            #line 8 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(@".page';
import { IonicModule } from '@ionic/angular';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Store } from '@ngrx/store';
import { StoreModule } from '@ngrx/store';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Actions } from '@ngrx/effects';

describe('");
            
            #line 19 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Page\', () => {\r\n  let component: ");
            
            #line 20 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Page;\r\n  let fixture: ComponentFixture<");
            
            #line 21 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Page>;\r\n\r\n  beforeEach(async(() => {\r\n    TestBed.configureTestingModule({\r\n     " +
                    " declarations: [ ");
            
            #line 25 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(@"Page ],
      imports: [
        IonicModule.forRoot(),
        StoreModule.forRoot({}),
        CommonModule,
        FormsModule,
        HttpClientTestingModule,
        RouterTestingModule,
        ReactiveFormsModule,
      ],
      providers: [Store, StatusBar, Actions],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(");
            
            #line 42 "D:\Mobioos_Ver_2.0 --10.11.19\IonicGenerator\IonicGenerator\GeneratorProject\Platforms\Frontend\Ionic\Pages\Templates\PageSpec.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_concern.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Page);\r\n    component = fixture.componentInstance;\r\n    fixture.detectChanges();\r" +
                    "\n  });\r\n\r\n  it(\'should create\', () => {\r\n    expect(component).toBeTruthy();\r\n  " +
                    "});\r\n});");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
