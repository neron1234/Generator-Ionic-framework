# Ionic Frontend Generator

## Technologies & Dependencies

### Dependencies

- @angular/common: 5.2.9
- @angular/compiler: 5.2.9
- @angular/compiler-cli: 5.2.9
- @angular/core: 5.2.9
- @angular/forms: 5.2.9
- @angular/http: 5.2.9
- @angular/platform-browser: 5.2.9
- @angular/platform-browser-dynamic: 5.2.9
- @ionic-native/core: 4.6.0
- @ionic-native/splash-screen: 4.6.0
- @ionic-native/status-bar: 4.6.0
- @ngx-translate/core: 9.1.1
- @ngx-translate/http-loader: 2.0.1
- ionic-angular: 3.9.2
- ionicons: 3.0.0
- rxjs: 5.5.7
- sw-toolbox: 3.6.0
- zone.js: 0.8.26

### DevDependencies

- @angular/cli: 1.6.0
- @ionic/app-scripts: 3.1.11
- @types/jasmine: 2.8.6
- @types/node: 9.6.4
- angular2-template-loader: 0.6.2
- fork-ts-checker-webpack-plugin: 0.4.9
- html-loader: 0.5.1
- jasmine: 2.5.3
- karma: 3.0.0
- karma-chrome-launcher: 2.2.0
- karma-jasmine: 1.1.1
- karma-jasmine-html-reporter: 0.2.2
- karma-mocha-reporter: 2.2.5
- karma-sourcemap-loader: 0.3.7
- karma-webpack: 2.0.3
- null-loader: 0.1.1
- ts-loader: 3.0.3
- ts-node: 5.0.1
- tslint: 5.9.1
- tslint-eslint-rules: 5.1.0
- typescript: 2.4.2

## Generated code's architecture

### Generated Ionic project's structure

- General project structure :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/GeneralProjectStructure.jpg "General project's structure")

- Pages :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/Pages.jpg "Pages")

- Models :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/Models.jpg "Models")

- ViewModels :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/ViewModels.jpg "ViewModels")

- Services :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/Services.jpg "Services")

- Tests :

![alt text](https://github.com/Mobioos/Ionic-framework/raw/Release1/docs/images/Tests.jpg "Tests")

### Generated Ionic project's specifications

- Project architecture : MVC
- Web services : REST
- Internationalization : Initialization based on described languages in
  the Forge modelization's metadatas.
- Unit tests : Basic tests and environment setup.
- Available themes : Dark, Light

### Remarks on generated code's possibilities

- You can build a basic menu if in the modelization you have at least one layout described with IsVisibleInMenu attribute to true.
- Forge modelization's description have a strong impact on the generated code, particularly from DataModels, Layouts, Apis and SmartApp metadatas.

## Interview's Questions

- Theming : There is one question about choosing between available themes. Modelization themes metadatas are ignored.