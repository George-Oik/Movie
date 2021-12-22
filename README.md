# Movie
Movie test demo

NOTES:

-. I used the below command in cmd to create a database in a linux container with docker: 
  docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=admin!@#123" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

I USED:

-. Docker for creating the linux repository.
-. .NET Core 5.0
-. Entity Framework
-. .NET Core ASP.NET MVC for web API
-. .NET Core c# library for the services library.
-. Azure Data Studio for the SQL database.
-. LinQ and Entity Framework for quering the database. Decided it would be better that writing stored procedures and functions because of the simplicity of the requests.
-. HTML, CSS and Javascript for the front end. Used BOOTSTRAP with HTML and jQuery in JavaScript for Ajax web requests.
-. Did implementation of services object-oriented, used Interfaces to group them.

FUTURE WORK:

-. Connection string is hardcoded for now in both the library (DbContext) and the web project (Startup - for the dependency injection). There is nothing else connecting the       database to the web API but the connection string also has to be read from a safer place.

-. Although the back end checks and returns info for successful and failed executions, the front end does not yet convey a message to the user. Also there is no implementation in Javascript and HTML for alerts and dynamic input information checking.

-. The implementation for a search bar is not done yet, but searching services exist in the back end.

-. The implementation for updating a movie's info is not done yet, but updating services exists in the back end and also the logic behind an Update request is very similar to the Post one shown in Javascript.

-. A project for unit testing is not implemented yet.
