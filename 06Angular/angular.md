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
Modules are decorated with @ngModule decorator to let the angular compiler know that it is angular module with additional metadata about it
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

## Decorators
Decorators tell angular that it is of a certain type (such as @ngModule or @Component) Angular takes the metadata that's been passed inside the decorator, and then adds them to the object. (the module/class)

## Services
Services are reusable pieces of logic that can be shared across components.
They are handled by angular's dependency injection, and are decorated with @injectable decorator.
Create services with ```ng g service <service-name>```

## Dependency Injection
After we import our modules and register our services, we can utilize angular dependency injection to let it handle the deps that our components and services need. Declare your deps in the constructor of your class (service/classes, etc). Once you have it injected, use them by ```this.<dep-name>```

## Lifecycle hooks
Angular provides us with various lifecycle hooks to take actions depending on the lifecycle of the component. For example, we can tell it to execute a certain action when the component loads, by placing the logic in ngOnInit(). Also, if we have resources that we need to dispose of, we can do so during ngOnDestory()
(there are more)

## Directives
Angular Directives provide additional functionality to the html pages/view.
Two types: Structural, and attribute directives
structural directives change the structure of dom/html page
    - so things like ngIf, ngFor, anything that adds or removes html elements are structural directives
Attribute directives changes the look and feel of elements
    - like ngStyle

## JS Events
- JS events occur in 3 phases
    - Capture phase: the event travels from window object to the event target
    - Event target: the event reaches the target element and the event listener responds
    - Bubbling: the event travels back up from the target element to the window
    - to prevent the event from bubbling further, we use event.stopPropagation() method

## Authentication vs Authorization
Authentication is verifying somebody's identity (who are you?)
    We achieve authentication usually via log in
Authorization is verifying if they can access this particular resource and/or take a certain action. (Are you allowed to do this?)

auth0 provides both authentication and authorization ability to our application (which means, we can create roles in auth0 to assign to users)

## Data binding
- {{}}: Interpolation
- []: Property Binding, from ts to view
- (): Event binding, from view to ts
- ```[()]```: Two-way binding

## Promises vs Observables

Both of them represent async operations that result in some form of return. Promises are closed after the result has been returned. Once it is fulfilled it's done. Observables use publisher/subscriber model and whenever there are any changes, all subscribers are notified of them.

## Routes
- create a router module and configure your routes via array that holds route objects. 
- pattern matches
- you can use params via syntax like this /path/to/:param
- query params are not declared in routes array but instead passed when navigating to it
- subscribe to the current route and gain access to its params and query params by using ActivatedRoute
- ```<router-outlet>``` tag acts as a placeholder for the views you want to present depending on your routes.
- different ways to navigate routes: RouterLink (as attributes in your html elements) and using router service, ```router.navigate(['path','names'], routeExtra here like queryParams)```
- you can also directly access the path/component via url ```<a href="path/to/component">Link</a>```

## Other Topics of Interest
- How to pass data between components
    - @Input (From parent to child)
    - @Output: EventEmitter (from child to parent)
    - @ViewChild: When you need access to child's HTML element itself
    - Query Params/params
    - utilizing service
- Pipes
    - We use pipes to transform data from one format to another, usually to the ones that can be displayed on the view 
    - We used async pipe to unwrap data from observables, but there are many other pipes
    - date, json, currency, etc..
    - you can create your own as well!
