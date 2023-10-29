# ASP.NET Core RazorPages

The folder contains an ASP.NET Core project scaffolded with the ```dotnet-aspnet-codegenerator``` and ```dotnet-ef``` tools.

The implementations for the ```Create``` and ```Delete``` page models are missing and your challenge is to comlete them.

## Create Movie

If you look at the ```./Pages/Movies/Create.cshtml.cs``` RazorPage you can see that the page model must implement an HTTP Post method.  You can also examine the ```./Data/MovieContext.cs``` class.

## Delete Movie

If you look at the ```./Pages/Movies/Delete.cshtml.cs``` RazorPage you can see that the page model must implement an HTTP Post method and pass the ```Movie.Id``` as an argument.

## Hints 

The DbContext is conventionally passed via constructor injection.

## Result

Once you have implemented both OnPostAsync methods, if you have access to a browser and the localhost you can execute ```dotnet run``` and open a browser to the correct address and you will see this page.

![./index.png](Index Page)

If you don't have access to a browser and localhost you can still test your implementation by executing ```dotnet test --filter MotionPictures.Tests.UnitTests``` and you should see no failing tests.