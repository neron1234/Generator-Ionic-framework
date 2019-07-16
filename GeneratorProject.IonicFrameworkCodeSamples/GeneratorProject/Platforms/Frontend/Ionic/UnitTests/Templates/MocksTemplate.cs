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
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class MocksTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n\r\nimport { Observable } from \'rxjs\';\r\n");
            
            #line 4 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

    if (ViewModels.AsEnumerable() != null)
    {
        foreach(var viewModel in ViewModels.AsEnumerable())
        {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 10 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(viewModel.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(" } from \'../../src/viewModels/");
            
            #line 10 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(viewModel.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("\';\r\n");
            
            #line 11 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

        }
    }

    if (Api.Id != null)
    {

            
            #line default
            #line hidden
            this.Write("export class ");
            
            #line 18 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Api.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Mock {\r\n");
            
            #line 19 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

        if (Api.Actions.AsEnumerable() != null)
        {
            foreach (var action in Api.Actions.AsEnumerable())
            {
                if (action.Id != null
                    && action.Url != null
                    && action.Type != null)
                {

            
            #line default
            #line hidden
            this.Write("    public ");
            
            #line 29 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("(\r\n");
            
            #line 30 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

                    if (action.Parameters.AsEnumerable() != null
                        && action.Parameters.AsEnumerable().Count() > 0)
                    {
                        var last = action.Parameters.AsEnumerable().Last();

                        foreach (var apiParameter in action.Parameters.AsEnumerable())
                        {
                            if (apiParameter.Id != null)
                            {
                                var type = apiParameter.TypeScriptType();

                                if (apiParameter.Equals(last))
                                {

            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 45 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(apiParameter.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Param: ");
            
            #line 45 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 46 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

                                }
                                else
                                {

            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 51 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(apiParameter.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Param: ");
            
            #line 51 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 52 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

                                }
                            }
                        }
                    }

                    if (action.ReturnType != null
                        && action.ReturnType.Id != null)
                    {

            
            #line default
            #line hidden
            this.Write("    ): Observable<");
            
            #line 62 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action.ReturnType.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("> {\r\n      return Observable.of();\r\n    }\r\n\r\n");
            
            #line 66 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

                    }
                    else
                    {

            
            #line default
            #line hidden
            this.Write("    ): Observable<any> {\r\n      return Observable.of();\r\n    }\r\n\r\n");
            
            #line 75 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

                    }
                }
            }
        }

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 82 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\UnitTests\Templates\MocksTemplate.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
