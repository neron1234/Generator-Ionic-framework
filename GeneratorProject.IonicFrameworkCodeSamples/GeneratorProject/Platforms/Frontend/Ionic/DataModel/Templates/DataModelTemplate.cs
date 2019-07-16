﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime : 16.0.0.0
//  
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
    
    #line 1 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class DataModelTemplate : TemplateBase
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
            
            #line 23 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

    if (Entity != null)
    {
        if (Entity.Extends != null)
        {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 29 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Extends.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model } from \'./");
            
            #line 29 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Extends.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Model\';\r\n");
            
            #line 30 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

        }

        var alreadyImported = new List<string>();

        if (ConstructorParametersObj.AsEnumerable() != null)
        {
            foreach (var property in ConstructorParametersObj.AsEnumerable())
            {
                if (property.Target != null
                    && property.Type != null
                    && !alreadyImported.AsEnumerable().Contains(property.Type))
                {
                    alreadyImported.Add(property.Type);

                    if (property.Target.IsEnum)
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Type.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Enum } from \'./");
            
            #line 48 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Type.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Enum\';\r\n");
            
            #line 49 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                    else
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 54 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Type.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model } from \'./");
            
            #line 54 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Type.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Model\';\r\n");
            
            #line 55 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }
        }

        if (Entity.References.AsEnumerable() != null)
        {
            foreach (var reference in Entity.References.AsEnumerable())
            {
                if (reference.Target != null
                    && reference.Type != null
                    && !alreadyImported.AsEnumerable().Contains(reference.Type))
                {
                    alreadyImported.Add(reference.Type);

                    if (reference.Target.IsEnum)
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 74 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Type.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Enum } from \'./");
            
            #line 74 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Type.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Enum\';\r\n");
            
            #line 75 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                    else
                    {

            
            #line default
            #line hidden
            this.Write("import { ");
            
            #line 80 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Type.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model } from \'./");
            
            #line 80 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Type.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Model\';\r\n");
            
            #line 81 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }
        }

        if (Entity.Id != null)
        {

            
            #line default
            #line hidden
            this.Write("/**\r\n * class: ");
            
            #line 91 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(".\r\n * You should add a description of your entity here.\r\n * This model is a refer" +
                    "ence used in viewModels or\r\n * in another referenced model.\r\n * This model is ge" +
                    "nerated from DataModel domain.\r\n */\r\nexport ");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
 if (Entity.IsAbstract) {
            
            #line default
            #line hidden
            this.Write("abstract ");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("class ");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Id.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
 if (Entity.Extends != null) {
            
            #line default
            #line hidden
            this.Write(" extends ");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Entity.Extends.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model");
            
            #line 97 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 98 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
 
            if (Entity.Properties.AsEnumerable() != null)
            {
                foreach (var property in Entity.Properties.AsEnumerable())
                {
                    if (property.Id != null
                        && property.TypeScriptType() != null
                        && property.IsCollection)
                    {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * property.\r\n   * isCollection.\r\n   */\r\n  public ");
            
            #line 112 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 112 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.TypeScriptType()));
            
            #line default
            #line hidden
            this.Write("[];\r\n");
            
            #line 113 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                    else if (property.Id != null
                            && property.TypeScriptType() != null)
                    {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * property.\r\n   */\r\n  public ");
            
            #line 122 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 122 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.TypeScriptType()));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 123 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }

            if (Entity.References.AsEnumerable() != null)
            {
                foreach (var reference in Entity.References.AsEnumerable())
                {
                    if (reference.Id != null
                        && reference.Target != null
                        && reference.Target.IsEnum)
                    {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   * isEnum.\r\n   */\r\n  public ");
            
            #line 141 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 141 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.TypeScriptType().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Enum;\r\n");
            
            #line 142 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                    else if (reference.Id != null 
                            && reference.TypeScriptType() != null
                            && reference.IsCollection)
                    {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   * isCollection.\r\n   */\r\n  public ");
            
            #line 153 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 153 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.TypeScriptType().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model[];\r\n");
            
            #line 154 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                    else if (reference.Id != null
                            && reference.TypeScriptType() != null)
                    {

            
            #line default
            #line hidden
            this.Write("  /**\r\n   * reference.\r\n   */\r\n  public ");
            
            #line 163 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 163 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.TypeScriptType().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Model;\r\n");
            
            #line 164 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }

            
            #line default
            #line hidden
            this.Write("  constructor(\r\n");
            
            #line 170 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

            if (ConstructorParametersObj.AsEnumerable() != null
                && ConstructorParametersObj.AsEnumerable().Count() > 0)
            {
                var lastIndex = ConstructorParametersObj.AsEnumerable().Count() - 1;
                var index = 0;
                var countConstructor = new Dictionary<string, int>();

                foreach (var property in ConstructorParametersObj.AsEnumerable())
                {
                    if (property.Id != null
                        && property.TypeScriptType() != null)
                    {
                        var propertyIsModel = IsModelOrEnum(property);

                        if (!countConstructor.ContainsKey(property.Id))
                        {
                            countConstructor.Add(property.Id, 1);
                        }
                        else
                        {
                            countConstructor[property.Id] = countConstructor[property.Id] + 1;
                        }

                        var type =  property.TypeScriptType();

                        if (!propertyIsModel.Equals(""))
                        {
                            type = type.ToPascalCase();
                        }

                        if (property.IsCollection
                            && index == lastIndex)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 205 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countConstructor[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 205 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{type}{propertyIsModel}"));
            
            #line default
            #line hidden
            this.Write("[]\r\n");
            
            #line 206 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                        else if (index == lastIndex)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 211 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countConstructor[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 211 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{type}{propertyIsModel}"));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 212 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                        else if (property.IsCollection)
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 217 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countConstructor[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 217 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{type}{propertyIsModel}"));
            
            #line default
            #line hidden
            this.Write("[],\r\n");
            
            #line 218 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                        else
                        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 223 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countConstructor[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 223 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{type}{propertyIsModel}"));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 224 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                    }

                    index++;
                }
            }

            
            #line default
            #line hidden
            this.Write("  ) {\r\n");
            
            #line 233 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

            var countObj = new Dictionary<string, int>();

            if (SuperPropertiesObj.AsEnumerable() != null
                && SuperPropertiesObj.AsEnumerable().Count() > 0)
            {

            
            #line default
            #line hidden
            this.Write("    super(\r\n");
            
            #line 241 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                var lastIndex = SuperPropertiesObj.AsEnumerable().Count() - 1;
                var index = 0;
                
                foreach (var property in SuperPropertiesObj.AsEnumerable())
                {
                    if (property.Id != null)
                    {
                        if (!countObj.ContainsKey(property.Id))
                        {
                            countObj.Add(property.Id, 1);
                        }
                        else
                        {
                            countObj[property.Id] = countObj[property.Id] + 1;
                        }

                        if (index == lastIndex)
                        {

            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 261 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countObj[property.Id]}"));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 262 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                        else
                        {

            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 267 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countObj[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 268 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                        }
                    }

                    index++;
                }

            
            #line default
            #line hidden
            this.Write("    );\r\n");
            
            #line 276 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

            }

            if (Entity.Properties.AsEnumerable() != null)
            {
                foreach (var property in Entity.Properties.AsEnumerable())
                {
                    if (property.Id != null)
                    {
                        if (!countObj.ContainsKey(property.Id))
                        {
                            countObj.Add(property.Id, 1);
                        }
                        else
                        {
                            countObj[property.Id] = countObj[property.Id] + 1;
                        }

            
            #line default
            #line hidden
            this.Write("    this.");
            
            #line 294 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 294 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{property.Id.ToCamelCase()}{countObj[property.Id]}"));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 295 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }

            if (Entity.References.AsEnumerable() != null)
            {
                foreach (var reference in Entity.References.AsEnumerable())
                {
                    if (reference.Id != null)
                    {
                        if (!countObj.ContainsKey(reference.Id))
                        {
                            countObj.Add(reference.Id, 1);
                        }
                        else
                        {
                            countObj[reference.Id] = countObj[reference.Id] + 1;
                        }

            
            #line default
            #line hidden
            this.Write("    this.");
            
            #line 315 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.Id.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 315 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{reference.Id.ToCamelCase()}{countObj[reference.Id]}"));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 316 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

                    }
                }
            }

            
            #line default
            #line hidden
            this.Write("  }\r\n}\r\n");
            
            #line 323 "C:\Users\PC\Documents\Gits\Ionic-framework\GeneratorProject.IonicFrameworkCodeSamples\GeneratorProject\Platforms\Frontend\Ionic\DataModel\Templates\DataModelTemplate.tt"

        }
    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
