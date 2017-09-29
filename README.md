# WebApiAngularV2
First project based on WebAPI + Angular2

This project is based on Angular CLI - https://cli.angular.io/
Setup was done according to instructions from:
https://medium.com/@levifuller/building-an-angular-application-with-asp-net-core-in-visual-studio-2017-visualized-f4b163830eaa


After downloading this repo, you need to set it up for development.
Setup process:
Visual Studio (I used 2017) and npm
1. Clone repo
2. Using npm, install Angular CLI: npm install @angular/cli --global
3. Install packages: Navigate to WebApiAngularV2 folder (the application folder) and from command line run: npm install
   This will install all the dependencies required for the solution to build
4. From same command line, run ng build
   This builds the solution to wwwroot folder and angular app is now ready to serve
5. For complete WEB Api projekt, run it from Visual Studio (refresh the cache in broser!)
6. Angular can be run solo, from the WebApiAngularV2 folder run ng serve


On to some specific cases from solution. 
Since I did Typescript last time, they switched from namespaces to modules. Each .ts file is it's own module. 
So now I'm bundling modules in another file before importing them where I need them. Need to find a better solution still. 
https://stackoverflow.com/questions/21706455/how-do-i-split-my-module-across-multiple-files-in-typescript-with-node-js

https://benetis.me/post/creating-shopping-cart-with-product-list-in-angular2/
https://www.sitepoint.com/understanding-component-architecture-angular/
https://www.npmjs.com/package/angular-cli#usage

Managed to get SingletonContext used through UnitOfWork. 

The key points are:
   Register context as singleton in startup
   Create GenericRepository class receiving context through injection
   Create UnitOfWork class also receiving context through injection
   Services have to be able to have UnitOfWork injected as well
   
Handling DbContext:
   https://www.benday.com/2017/02/17/ef-core-migrations-without-hard-coding-a-connection-string-using-idbcontextfactory/
   https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
   
Handling Config:
   https://stackoverflow.com/questions/34269106/read-connectionstring-outside-startup-from-appsetting-json-in-vnext
   
Adding Identity to project:

   http://www.blinkingcaret.com/2016/11/30/asp-net-identity-core-from-scratch/
   Basically, just add the NuGet packages and extend the DbContext and ApplicationUser
   After that, just register the service
   
Follow this after it: 
   https://fullstackmark.com/post/9/get-started-with-angular-2-and-aspnet-core-in-visual-studio-code
   https://fullstackmark.com/post/10/user-authentication-with-angular-and-asp-net-core
   
Toastr:
   http://jasonwatmore.com/post/2017/06/25/angular-2-4-alert-toaster-notifications
   http://www.codershood.info/2017/04/14/showing-notification-using-toaster-angular-2/
   https://www.npmjs.com/package/ng2-toastr
