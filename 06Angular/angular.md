# Angular

## What is angular?
Angular is a front end web application framework/platform that enables us to create single page web applications in an architectural style that allows us to scale and maintain with ease.
It utilizes the module and class feature from ES2015+

## What is Single Page Application?
Single page application is a type of web application where we receive the entire html/css/js to render an app in the first GET request.
Unlike static websites where we get html pages served by a server, we instead receive json data from the server and render as needed.
The "change in the view" is done by swapping various html elements depending on the condition/user interactions - via JS manipulating the DOM
This means that once the SPA loads, there is no refresh.

## Advantages of SPA
- Once the app loads, the application in general is faster because it's not receiving entire html pages from the server
- Because we use AJAX to receive data, our application will stay responsive and not freeze on us (which means, if we happen to be waiting for a huge data that takes a lot of time to load, instead of freezing, we can do things like, displaying the loading bar or spinner)

## Disadvantages of SPA
- overhead to configure and learn a particular framework
- the initial request can be slower than static webpages

## Initialize angular application
- ```npm install -g @angular/cli```
- ```ng new <your-app-name>```

## To Serve your app
- ```ng serve```
    - by default, it will open at localhost:4200
- ```ng serve --open```
    - This opens the browser for you

## Modules
Angular uses ES2015 module system to practice separation of concerns
It works kind of like namespaces in C#
Modules are decorated with @ngModule decorator to let the angular compiler know that it is angular module with addition metadata about it
Before we can use any components, we need to have them belong somewhere, by registering them to a module, by including the component name in declaration section of ngModule decoration
If you want to use components from a different module, we first need to import the module that has that particular component, in the imports section.
We separate modules by features
In order to generate modules, use ```ng g module <module-name>```

## Components
Components are the reusable pieces of view that is bundled with its own logic, styles, and tests.
They are one of the core parts of angular application and mainly handles user interactions and view display.
In order to generate components, we use ```ng g component <component-name>``` 
By default, components contain 4 file - html, css, ts, spec.ts (for unit testing)
However, only html and ts file is necessary to really render a component
Even then, you can have html included in the @component decorator as template instead of having its own separate html file.
