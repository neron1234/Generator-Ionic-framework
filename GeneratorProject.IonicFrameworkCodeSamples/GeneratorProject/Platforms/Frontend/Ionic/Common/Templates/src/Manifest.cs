// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a �t� g�n�r� par un outil.
//     Version du runtime�: 15.0.0.0
//  
//     Les changements apport�s � ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est r�g�n�r�.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Scaffold.TextTemplating;
    using Mobioos.Foundation.Jade.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Manifest : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"
/*
 * You should add your licence here, here is an example :
 *
 * SonarQube, open source software quality management tool.
 * Copyright (C) 2008-2013 SonarSource
 * mailto:contact AT sonarsource DOT com
 *
 * SonarQube is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * SonarQube is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
");
            
            #line 22 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"

    SmartAppInfo smartApp = (SmartAppInfo)Model;
    if (smartApp != null && smartApp.Title != null)
    {

            
            #line default
            #line hidden
            this.Write("{\r\n  \"name\": \"");
            
            #line 28 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.Title));
            
            #line default
            #line hidden
            this.Write("\",\r\n");
            
            #line 29 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"

      if (smartApp.SmallTitle != null)
      {

            
            #line default
            #line hidden
            this.Write("  \"short_name\": \"");
            
            #line 33 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(smartApp.SmallTitle));
            
            #line default
            #line hidden
            this.Write("\",\r\n");
            
            #line 34 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"

      }

            
            #line default
            #line hidden
            this.Write("  \"start_url\": \"index.html\",\r\n  \"display\": \"standalone\"\r\n}\r\n");
            
            #line 40 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\Common\Templates\src\Manifest.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
