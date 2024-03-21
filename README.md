# Prerequisites:  
.NET 8.0 installed (if not present install and don't forget to restart your computer):  
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

# How to run:  
1. Open Windows Terminal and navigate to directory with Homework.Api.csproj file (git-repo-location\src\Homework.Api\)  
2. Run command: "dotnet run --environment Development --launch-profile https"

The application will start, and you will be greeted with a message saying which ports the application listens to for HTTP and HTTPS traffic.  
Example: "https://localhost:7100" or "http://localhost:5172"

Copy this URL and add "/swagger" at the end if you want to use that. For that you need to have "--environment Development" specified.  
Example: "https://localhost:7100/swagger" or "http://localhost:5172/swagger"
