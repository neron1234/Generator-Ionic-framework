// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
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
    using Mobioos.Scaffold.BaseGenerators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AppComponentSpecTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 2 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

    if (_smartApp != null && _smartApp.Id != null)
    {
        bool isLanguages = false;
        if (_smartApp.Languages.AsEnumerable() != null && _smartApp.Languages.AsEnumerable().Count() > 0)
        {
            isLanguages = true;
        }

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("import { LanguagePageModule } from \'../pages/language/language.module\';\r\nimport {" +
                    " TranslateModule, TranslateService } from \'@ngx-translate/core\';\r\nimport { Trans" +
                    "lateServiceMock } from \'../../test-config/mocks/translateServiceMock\';\r\n");
            
            #line 17 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"import { ComponentFixture, async, TestBed, fakeAsync, flushMicrotasks } from '@angular/core/testing';
import { IonicModule, Platform, NavController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Title } from '@angular/platform-browser';

import { ");
            
            #line 26 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" } from \'./app.component\';\r\n");
            
            #line 27 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (_smartApp.Concerns.AsEnumerable() != null && _rootLayout != null && _rootLayout.Id != null && _rootConcern != null && _rootConcern.Id != null)
        {
            string concern = TextConverter.PascalCase(_rootConcern.Id);
            string layout = TextConverter.PascalCase(_rootLayout.Id);
            string layoutComponent = concern + layout;
            string layoutComponentToLower = TextConverter.CamelCase(concern) + "-" + TextConverter.CamelCase(layout);

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 35 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write("PageModule } from \'../pages/");
            
            #line 35 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(concern)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 35 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(layout)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 35 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponentToLower));
            
            #line default
            #line hidden
            this.Write(".module\';\r\nimport { ");
            
            #line 36 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write(" } from \'../pages/");
            
            #line 36 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(concern)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 36 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(layout)));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 36 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponentToLower));
            
            #line default
            #line hidden
            this.Write("\';\r\n");
            
            #line 37 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"import { PlatformMock } from '../../test-config/mocks/platformMock';
import { StatusBarMock } from '../../test-config/mocks/statusBarMock';
import { SplashScreenMock } from '../../test-config/mocks/splashScreenMock';
import { NavMock } from '../../test-config/mocks/navMock';
import { TitleMock } from '../../test-config/mocks/titleMock';

describe('");
            
            #line 46 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component\', () => {\r\n  let fixture: ComponentFixture<");
            
            #line 47 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(">;\r\n  let component: ");
            
            #line 48 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n  let spy: jasmine.Spy;\r\n\r\n  beforeEach(async(() => {\r\n    TestBed.configure" +
                    "TestingModule({\r\n      declarations: [");
            
            #line 54 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("],\r\n      imports: [\r\n");
            
            #line 56 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("        LanguagePageModule,\r\n        TranslateModule.forChild(),\r\n");
            
            #line 62 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            
            #line 65 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (_smartApp.Concerns.AsEnumerable() != null && _rootLayout != null && _rootLayout.Id != null && _rootConcern != null && _rootConcern.Id != null)
        {
            string concern = TextConverter.PascalCase(_rootConcern.Id);
            string layout = TextConverter.PascalCase(_rootLayout.Id);
            string layoutComponent = concern + layout;
            string layoutComponentToLower = TextConverter.CamelCase(concern) + "-" + TextConverter.CamelCase(layout);

            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 73 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write("PageModule,\r\n");
            
            #line 74 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("        IonicModule.forRoot(");
            
            #line 77 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(")\r\n      ],\r\n      providers: [\r\n        { provide: Platform, useClass: PlatformM" +
                    "ock },\r\n        { provide: StatusBar, useClass: StatusBarMock },\r\n        { prov" +
                    "ide: SplashScreen, useClass: SplashScreenMock },\r\n");
            
            #line 83 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("        { provide: TranslateService, useClass: TranslateServiceMock },\r\n");
            
            #line 88 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("        { provide: NavController, useClass: NavMock },\r\n        { provide: Title," +
                    " useClass: TitleMock }\r\n      ]\r\n    }).compileComponents();\r\n  }));\r\n\r\n  before" +
                    "Each(async() => {\r\n    fixture = TestBed.createComponent(");
            
            #line 98 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(");\r\n    component = fixture.componentInstance;\r\n  });\r\n  \r\n  afterEach(() => {\r\n " +
                    "   fixture.destroy();\r\n    component = null;\r\n  });\r\n\r\n  it(\'");
            
            #line 107 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: platform should be ready\', fakeAsync(() => {\r\n    spy = spyOn(compone" +
                    "nt._platform, \'ready\').and.callThrough();\r\n    var app = new ");
            
            #line 109 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 110 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 115 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 122 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalled();
    spy.calls.mostRecent().returnValue.then((result) => {
      expect(result).toEqual('READY');
    });
  }));

  it('");
            
            #line 138 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should set default style statusBar\', fakeAsync(() => {\r\n    spy = spy" +
                    "On(component._statusBar, \'styleDefault\').and.callThrough();\r\n    var app = new ");
            
            #line 140 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 141 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 146 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 153 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalled();
    var result = spy.calls.mostRecent().returnValue;
    expect(result).toBeUndefined();
  }));

  it('");
            
            #line 168 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should hide splashscreen\', fakeAsync(() => {\r\n    spy = spyOn(compone" +
                    "nt._splashScreen, \'hide\').and.callThrough();\r\n    var app = new ");
            
            #line 170 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 171 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 176 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 183 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalled();
    var result = spy.calls.mostRecent().returnValue;
    expect(result).toBeUndefined();
  }));

  it('");
            
            #line 198 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should set navigation root page\', fakeAsync(() => {\r\n    spy = spyOn(" +
                    "component._nav, \'setRoot\').and.callThrough();\r\n    var app = new ");
            
            #line 200 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 201 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 206 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 213 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("      component._platform,\r\n      component._statusBar,\r\n      component._splashS" +
                    "creen,\r\n      component._title\r\n    );\r\n    app._nav = component._nav;\r\n    flus" +
                    "hMicrotasks();\r\n    expect(spy).toHaveBeenCalledWith(\r\n");
            
            #line 224 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (_smartApp.Concerns.AsEnumerable() != null && _rootLayout != null && _rootLayout.Id != null && _rootConcern != null && _rootConcern.Id != null)
        {
            string concern = TextConverter.PascalCase(_rootConcern.Id);
            string layout = TextConverter.PascalCase(_rootLayout.Id);
            string layoutComponent = concern + layout;
            string layoutComponentToLower = TextConverter.CamelCase(concern) + "-" + TextConverter.CamelCase(layout);

            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 232 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(layoutComponent));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 233 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("    );\r\n    spy.calls.mostRecent().returnValue.then((result) => {\r\n      expect(r" +
                    "esult).toBe(true);\r\n    });\r\n  }));\r\n\r\n  it(\'");
            
            #line 242 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should set default language\', fakeAsync(() => {\r\n    spy = spyOn(comp" +
                    "onent._translateService, \'setDefaultLang\').and.callThrough();\r\n    var app = new" +
                    " ");
            
            #line 244 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 245 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 250 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 257 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalled();
    var result = spy.calls.mostRecent().returnValue;
    expect(result).toBeUndefined();
  }));

  it('");
            
            #line 272 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should use a language\', fakeAsync(() => {\r\n    spy = spyOn(component." +
                    "_translateService, \'use\').and.callThrough();\r\n    var app = new ");
            
            #line 274 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 275 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 280 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 287 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalled();
    spy.calls.mostRecent().returnValue.subscribe((result) => {
      expect(result).toBeDefined();
    });
  }));

  it('");
            
            #line 303 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should translate applicationTitle to test\', fakeAsync(() => {\r\n    sp" +
                    "y = spyOn(component._translateService, \'get\').and.callThrough();\r\n    var app = " +
                    "new ");
            
            #line 305 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 306 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 311 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 318 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalledWith('applicationTitle');
    spy.calls.mostRecent().returnValue.subscribe((result) => {
      expect(result).toEqual('test');
    });
  }));

  it('");
            
            #line 334 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should set translated title\', fakeAsync(() => {\r\n    spy = spyOn(comp" +
                    "onent._title, \'setTitle\').and.callThrough();\r\n    var app = new ");
            
            #line 336 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 337 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        if (isLanguages)
        {

            
            #line default
            #line hidden
            this.Write("      component._translateService,\r\n");
            
            #line 342 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

        if (_isMenu)
        {

            
            #line default
            #line hidden
            this.Write("      component._events,\r\n");
            
            #line 349 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write(@"      component._platform,
      component._statusBar,
      component._splashScreen,
      component._title
    );
    app._nav = component._nav;
    flushMicrotasks();
    expect(spy).toHaveBeenCalledWith('test');
    var result = spy.calls.mostRecent().returnValue;
    expect(result).toBeUndefined();
  }));

  it('");
            
            #line 364 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(" Component: should be created\', fakeAsync(() => {\r\n    flushMicrotasks();\r\n    ex" +
                    "pect(component instanceof ");
            
            #line 366 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(").toBeTruthy();\r\n  }));\r\n\r\n  it(\'");
            
            #line 369 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_smartApp.Id)));
            
            #line default
            #line hidden
            this.Write(@" Component: should set root on test route', fakeAsync(() => {
    spy = spyOn(component, 'selected').and.callThrough();
    component.selected('test');
    flushMicrotasks();
    expect(spy).toHaveBeenCalledWith('test');
    spy = spyOn(component._nav, 'setRoot').and.callThrough();
    component.selected('test');
    flushMicrotasks();
    expect(spy).toHaveBeenCalledWith('test');
    spy.calls.mostRecent().returnValue.then((result) => {
      expect(result).toBe(true);
    });
  }));
});
");
            
            #line 383 "C:\Users\Temoe\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\AppComponentSpecTemplate.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
