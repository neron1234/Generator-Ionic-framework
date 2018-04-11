// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Mobioos.Scaffold.Generators.Platforms.Frontend.Ionic
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Scaffold.TextTemplating;
    using Mobioos.Scaffold.Generators.Helpers;
    using Mobioos.Foundation.Jade.Models;
    using Mobioos.Foundation.Jade.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ViewModelTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            this.Write(@"/*
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
            
            #line 24 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

    if (_dataModel != null && _dataModel.Id != null)
    {
        List<string> alreadyImported = new List<string>();
        if (_constructorParametersObj.AsEnumerable() != null)
        {
            foreach (PropertyInfo property in _constructorParametersObj.AsEnumerable())
            {
                if (property.Target != null && property.Type != null && !alreadyImported.AsEnumerable().Contains(property.Type))
                {
                    alreadyImported.Add(property.Type);
                    if (property.Target.IsEnum)
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 38 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(property.Type)));
            
            #line default
            #line hidden
            this.Write("Enum } from \'../models/");
            
            #line 38 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Type)));
            
            #line default
            #line hidden
            this.Write("Enum\';\r\n");
            
            #line 39 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                    else
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 44 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(property.Type)));
            
            #line default
            #line hidden
            this.Write("Model } from \'../models/");
            
            #line 44 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Type)));
            
            #line default
            #line hidden
            this.Write("Model\';\r\n");
            
            #line 45 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                }
            }
        }

        if (_dataModel.References.AsEnumerable() != null)
        {
            foreach (ReferenceInfo reference in _dataModel.References.AsEnumerable())
            {
                if (reference.Target != null && reference.Type != null && !alreadyImported.AsEnumerable().Contains(reference.Type))
                {
                    alreadyImported.Add(reference.Type);
                    if (reference.Target.IsEnum)
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 61 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(reference.Type)));
            
            #line default
            #line hidden
            this.Write("Enum } from \'../models/");
            
            #line 61 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Type)));
            
            #line default
            #line hidden
            this.Write("Enum\';\r\n");
            
            #line 62 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                    else
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 67 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(reference.Type)));
            
            #line default
            #line hidden
            this.Write("Model } from \'../models/");
            
            #line 67 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Type)));
            
            #line default
            #line hidden
            this.Write("Model\';\r\n");
            
            #line 68 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                }
            }
        }

            
            #line default
            #line hidden
            this.Write("/**\r\n * class: ");
            
            #line 75 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_dataModel.Id)));
            
            #line default
            #line hidden
            this.Write("\r\n * You should add a description of your entity here.\r\n * This viewModel is a re" +
                    "ference used in Concerns or\r\n * in APIs\' parameters or return types.\r\n * This mo" +
                    "del is generated from ViewModel domain.\r\n */\r\nexport class ");
            
            #line 81 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(_dataModel.Id)));
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 82 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

        if (_dataModel.Properties.AsEnumerable() != null)
        {
            foreach (PropertyInfo property in _dataModel.Properties.AsEnumerable())
            {
                if (property.Id != null && property.TypeScriptType() != null && property.IsCollection)
                {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * property.\r\n   * isCollection.\r\n   */\r\n  public ");
            
            #line 94 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 94 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.TypeScriptType()));
            
            #line default
            #line hidden
            this.Write("[];\r\n");
            
            #line 95 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                }
                else if (property.Id != null && property.TypeScriptType() != null)
                {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * property.\r\n   */\r\n  public ");
            
            #line 103 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 103 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.TypeScriptType()));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 104 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                }
            }
        }

        if (_dataModel.References.AsEnumerable() != null)
        {
            foreach (ReferenceInfo reference in _dataModel.References.AsEnumerable())
            {
                if (reference.Id != null && reference.Target != null && reference.Target.IsEnum)
                {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   * isEnum.\r\n   */\r\n  public ");
            
            #line 120 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Id)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 120 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(reference.TypeScriptType())));
            
            #line default
            #line hidden
            this.Write("Enum;\r\n");
            
            #line 121 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                }
                else if (reference.Id != null && reference.TypeScriptType() != null && reference.IsCollection)
                {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   * isCollection.\r\n   */\r\n  public ");
            
            #line 130 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Id)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 130 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(reference.TypeScriptType())));
            
            #line default
            #line hidden
            this.Write("Model[];\r\n");
            
            #line 131 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                }
                else if (reference.Id != null && reference.TypeScriptType() != null)
                {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   */\r\n  public ");
            
            #line 139 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Id)));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 139 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.PascalCase(reference.TypeScriptType())));
            
            #line default
            #line hidden
            this.Write("Model;\r\n");
            
            #line 140 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                }
            }
        }

            
            #line default
            #line hidden
            this.Write("  constructor(\r\n");
            
            #line 146 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

            if (_constructorParametersObj.AsEnumerable() != null && _constructorParametersObj.AsEnumerable().Count() > 0)
            {
                int lastIndex = _constructorParametersObj.AsEnumerable().Count() - 1;
                int index = 0;
                Dictionary<string, int> countConstructor = new Dictionary<string, int>();
                foreach (PropertyInfo property in _constructorParametersObj.AsEnumerable())
                {
                    if (property.Id != null && property.TypeScriptType() != null)
                    {
                        string propertyIsModel = IsModel(property);
                        if (!countConstructor.ContainsKey(property.Id))
                            countConstructor.Add(property.Id, 1);
                        else
                            countConstructor[property.Id] = countConstructor[property.Id] + 1;
                        string type =  property.TypeScriptType();
                        if (!propertyIsModel.Equals(""))
                        {
                            type = TextConverter.PascalCase(type);
                        }
                        if (property.IsCollection && index == lastIndex)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 169 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id) + countConstructor[property.Id]));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 169 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type + propertyIsModel));
            
            #line default
            #line hidden
            this.Write("[]\r\n");
            
            #line 170 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                        }
                        else if (index == lastIndex)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 175 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id) + countConstructor[property.Id]));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 175 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type + propertyIsModel));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 176 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                        }
                        else if (property.IsCollection)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 181 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id) + countConstructor[property.Id]));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 181 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type + propertyIsModel));
            
            #line default
            #line hidden
            this.Write("[],\r\n");
            
            #line 182 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                        }
                        else
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 187 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id) + countConstructor[property.Id]));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 187 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(type + propertyIsModel));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 188 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                        }
                    }
                    index++;
                }
            }

            
            #line default
            #line hidden
            this.Write("  ) {\r\n");
            
            #line 196 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

            Dictionary<string, int> countObj = new Dictionary<string, int>();
            if (_dataModel.Properties.AsEnumerable() != null)
            {
                foreach (PropertyInfo property in _dataModel.Properties.AsEnumerable())
                {
                    if (property.Id != null)
                    {
                        if (!countObj.ContainsKey(property.Id))
                            countObj.Add(property.Id, 1);
                        else
                            countObj[property.Id] = countObj[property.Id] + 1;

            
            #line default
            #line hidden
            this.Write("    this.");
            
            #line 209 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id)));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 209 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(property.Id) + countObj[property.Id]));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 210 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                }
            }

            if (_dataModel.References.AsEnumerable() != null)
            {
                foreach (ReferenceInfo reference in _dataModel.References.AsEnumerable())
                {
                    if (reference.Id != null)
                    {
                        if (!countObj.ContainsKey(reference.Id))
                            countObj.Add(reference.Id, 1);
                        else
                            countObj[reference.Id] = countObj[reference.Id] + 1;

            
            #line default
            #line hidden
            this.Write("    this.");
            
            #line 226 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Id)));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 226 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TextConverter.CamelCase(reference.Id) + countObj[reference.Id]));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 227 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

                    }
                }
            }

            
            #line default
            #line hidden
            this.Write("  }\r\n}\r\n");
            
            #line 234 "C:\Users\PC\Documents\Gits\Scaffold-v3\src\Generators\Mobioos.Scaffold.Generators\Platforms\Frontend\Ionic\ViewModel\Templates\ViewModelTemplate.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
