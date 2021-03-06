# Ionic-framework

Generators are built with **T4 Text Templating**, and in particular, with [preprocessed T4 Text Templating](https://docs.microsoft.com/en-us/visualstudio/modeling/run-time-text-generation-with-t4-text-templates) (T4 Runtime text templates). [Ionic framework](https://ionicframework.com/) is a cross-platform framework based on [Cordova](https://cordova.apache.org/) and [Angular](https://angular.io/) frameworks enabling iOS, Android and Web applications builds from an unique source code. Let's see examples of usages of T4 templates which produce source codes for the Ionic framework. Managing [manifest metadatas](https://github.com/Mobioos/Forge-Documentation), output of **Mobioos.Forge modelization**, and **interview's answers**, in order to create **SmartApp** applications, targetting a **specific technology** is the main goal to be compliant with the context of **Mobioos**.

## Requirements

- **C#** programming language (see: [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide))
- **T4 Text templating** (see: [T4 Text Templating Documentation](https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates))
- **Visual studio 2017** ([Community Edition](https://www.visualstudio.com/fr/downloads/) is enough)
- **Mobioos Forge Scaffold generators** documentation (see: [Mobioos Forge Scaffold generators documentation](https://github.com/Mobioos/Common-Scaffold))

In order to see and download Mobioos NuGet packages, you will need to add a new source of packages in your NuGet package manager under Visual Studio. Under **Tools -> Options** see **NuGet Package Manager**, go to **Package Sources** and add a new source like it.

![alt text](https://github.com/Mobioos/Ionic-framework/raw/master/docs/images/Mobioos_packages_source.jpg "Mobioos packages source")

## Getting started

In order to get in easier, we made a specific explanation of how the Ionic framework generator implements Angular components code generation :

- [Example - Angular components](https://github.com/Mobioos/Ionic-framework/wiki/Example-Angular-Components)
- [Imports](https://github.com/Mobioos/Ionic-framework/wiki/Imports)
- [Layout](https://github.com/Mobioos/Ionic-framework/wiki/Layout)
- [Menus](https://github.com/Mobioos/Ionic-framework/wiki/Menus)
- [Migration from Activities to Workflows](https://github.com/Mobioos/Ionic-framework/wiki/Migration)
---