# Prerequisites:  
- .NET 8.0 installed (if not present, install and don't forget to restart your computer):  
https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- Internet access during build in order for NuGet package manager to restore used NuGet packages

# How to run:  
1. Open Windows Terminal and navigate to the directory with Homework.Api.csproj file (git-repo-location\src\Homework.Api\)  
   ```PS C:\GitPrivate\Homework-Notes\src\Homework.Api> dotnet run --environment Development --launch-profile https```
3. Run command: ```dotnet run --environment Development --launch-profile https```

## Easy run (Windows)
1. Run ```run.cmd``` script. It will build and run application

## Open Swagger
The application will start, and you will be greeted with a message saying which ports the application listens to for HTTP and HTTPS traffic.  
Example: ```https://localhost:7100``` or ```http://localhost:5172```

Copy this URL and add "/swagger" at the end if you want to use that. For that, you need to have "--environment Development" specified.  
Example: ```https://localhost:7100/swagger``` or ```http://localhost:5172/swagger```

# Documentation:
Due to the simplicity of this application, I believe that Swagger is enough to document the behavior of this application.  
For request schemas, please visit ```/swagger``` endpoint in API while running under the Development environment

Here is list of endpoints:  
- ```POST``` ```/notes``` - Creates a new note with Content from body
- ```PUT``` ```/notes/{noteId}``` - Updates note with given noteId with Content from body
- ```DELETE``` ```/notes/{noteId}```- Deletes note with given noteId
- ```GET``` ```/notes/{noteId}``` - Retrieves note with given noteId
- ```GET``` ```/notes/{pageNumber}/{pageSize}``` - Retrieves paginated list of notes

# Notes
- Unit tests are not written for all cases and classes. What is written is for general idea on how I create them.
- This project could be written as a small, one project with few files as "Minimal API", but I wanted to demonstrate an understanding of design patterns and software architecture.
- If those were the only and closed requirements for simple service, I would instead write a small, easily maintainable project. No need to overcomplicate simple (and closed) projects.
