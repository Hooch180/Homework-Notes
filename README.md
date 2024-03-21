# Prerequisites:  
.NET 8.0 installed (if not present, install and don't forget to restart your computer):  
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

# How to run:  
1. Open Windows Terminal and navigate to the directory with Homework.Api.csproj file (git-repo-location\src\Homework.Api\)  
2. Run command: ```dotnet run --environment Development --launch-profile https```

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
