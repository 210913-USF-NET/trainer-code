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